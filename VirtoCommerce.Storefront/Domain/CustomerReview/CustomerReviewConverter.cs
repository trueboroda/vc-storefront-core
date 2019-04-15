using dtoNamespace = VirtoCommerce.Storefront.AutoRestClients.CustomerReviewsModule.WebModuleApi.Models;


namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    public static partial class CustomerReviewConverter
    {

        public static Model.CustomerReviews.CustomerReview ToCustomerReview(this dtoNamespace.CustomerReview dtoItem)
        {
            var result = new Model.CustomerReviews.CustomerReview()
            {

                AuthorNickname = dtoItem.AuthorNickname,
                Content = dtoItem.Content,
                IsActive = dtoItem.IsActive,
                ProductId = dtoItem.ProductId,
                CreatedDate = dtoItem.CreatedDate,
                ModifiedDate = dtoItem.ModifiedDate,
                CreatedBy = dtoItem.CreatedBy,
                ModifiedBy = dtoItem.ModifiedBy
            };
            return result;
        }


        public static dtoNamespace.CustomerReviewSearchCriteria ToSearchCriteriaDto(this Model.CustomerReviews.CustomerReviewSearchCriteria criteria)
        {
            var result = new dtoNamespace.CustomerReviewSearchCriteria()
            {
                IsActive = criteria.IsActive,
                ProductIds = criteria.ProductIds,

                Skip = criteria.Start,
                Take = criteria.PageSize,
                Sort = criteria.Sort
            };

            return result;
        }

    }
}
