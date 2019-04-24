using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

using PagedList.Core;
using VirtoCommerce.Storefront.AutoRestClients.CustomerReviewsModuleApi;
using VirtoCommerce.Storefront.Infrastructure;
using VirtoCommerce.Storefront.Model.Caching;
using VirtoCommerce.Storefront.Model.Common.Caching;
using VirtoCommerce.Storefront.Model.CustomerReviews;

namespace VirtoCommerce.Storefront.Domain.CustomerReviews
{
    /// <summary>
    /// Service for work with CustomerReviewsModule WebApi
    /// </summary>
    public class CustomerReviewService : ICustomerReviewService
    {


        private readonly ICustomerReviewsModule _customerReviewsApi;
        private readonly IStorefrontMemoryCache _memoryCache;
        private readonly IApiChangesWatcher _apiChangesWatcher;

        public CustomerReviewService(ICustomerReviewsModule customerReviewsApi, IStorefrontMemoryCache memoryCache, IApiChangesWatcher apiChangesWatcher)
        {
            _customerReviewsApi = customerReviewsApi;
            _memoryCache = memoryCache;
            _apiChangesWatcher = apiChangesWatcher;
        }

        public async Task<CustomerReview> CreateCustomerReviewAsync(CustomerReview review)
        {
            var reviewDto = review.ToCustomerReviewDto();
            var result = await _customerReviewsApi.CreateAsync(reviewDto);

            CustomerReviewCacheRegion.ExpireCustomerReview(review.ProductId);

            return result?.ToCustomerReview();
        }


        public async Task UpdateCustomerReviewAsync(CustomerReview review)
        {
            var dto = review.ToCustomerReviewDto();
            await _customerReviewsApi.UpdateAsync(new[] { dto });

            CustomerReviewCacheRegion.ExpireCustomerReview(review.ProductId);
        }

        public async Task DeleteCustomerReviewAsync(CustomerReview review)
        {
            await _customerReviewsApi.DeleteAsync(new[] { review.Id });

            CustomerReviewCacheRegion.ExpireCustomerReview(review.ProductId);
        }

        public async Task<CustomerReviewEvaluation> GetCustomerReviewEvaluationForCustomerAsync(string reviewId, string customerId)
        {
            var evaluationDto = await _customerReviewsApi.GetCustomerReviewEvaluationForCustomerAsync(reviewId, customerId);

            var result = evaluationDto?.ToEvaluation();
            return result;
        }

        public async Task<double?> GetProductRatingAsync(string productId)
        {

            var cacheKey = CacheKey.With(GetType(), nameof(GetProductRatingAsync), productId);

            return await _memoryCache.GetOrCreateExclusiveAsync(cacheKey, async (cacheEntry) =>
            {


                cacheEntry.AddExpirationToken(CustomerReviewCacheRegion.CreateChangeToken(productId));
                cacheEntry.AddExpirationToken(_apiChangesWatcher.CreateChangeToken());

                var productRatingDto = await _customerReviewsApi.GetProductRatingAsync(productId);
                var result = productRatingDto?.Rating.GetValueOrDefault();
                return result;
            });


        }

        public async Task SaveEvaluationAsync(string productId, CustomerReviewEvaluation evaluation)
        {
            var dto = evaluation.ToEvaluationDto();
            await _customerReviewsApi.SaveCustomerReviewEvaluationAsync(dto);

            CustomerReviewCacheRegion.ExpireCustomerReview(productId);
        }

        public IPagedList<CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria)
        {
            return SearchReviewsAsync(criteria).GetAwaiter().GetResult();
        }

        public async Task<IPagedList<CustomerReview>> SearchReviewsAsync(CustomerReviewSearchCriteria criteria)
        {
            var cacheKey = CacheKey.With(GetType(), nameof(SearchReviewsAsync), criteria.GetCacheKey());
            return await _memoryCache.GetOrCreateExclusiveAsync(cacheKey, async (cacheEntry) =>
            {
                foreach (var productId in criteria.ProductIds)
                {
                    cacheEntry.AddExpirationToken(CustomerReviewCacheRegion.CreateChangeToken(productId));
                }

                cacheEntry.AddExpirationToken(_apiChangesWatcher.CreateChangeToken());

                var searchResult = await _customerReviewsApi.SearchCustomerReviewsAsync(criteria.ToSearchCriteriaDto());
                var reviews = searchResult.Results.Select(x => x.ToCustomerReview());

                return new StaticPagedList<CustomerReview>(reviews, criteria.PageNumber, criteria.PageSize, searchResult.TotalCount.Value);
            });

        }


    }
}
