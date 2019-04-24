using System.Threading.Tasks;
using PagedList.Core;

namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    public interface ICustomerReviewService
    {
        IPagedList<CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria);

        Task<IPagedList<CustomerReview>> SearchReviewsAsync(CustomerReviewSearchCriteria criteria);

        Task<CustomerReview> CreateCustomerReviewAsync(CustomerReview review);

        Task UpdateCustomerReviewAsync(CustomerReview review);

        Task DeleteCustomerReviewAsync(CustomerReview review);

        Task<CustomerReviewEvaluation> GetCustomerReviewEvaluationForCustomerAsync(string reviewId, string customerId);

        Task SaveEvaluationAsync(string productId, CustomerReviewEvaluation evaluation);

        Task<double?> GetProductRatingAsync(string productId);
    }
}
