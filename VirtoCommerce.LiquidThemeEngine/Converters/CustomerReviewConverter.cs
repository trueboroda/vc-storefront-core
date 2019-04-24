using VirtoCommerce.LiquidThemeEngine.Objects;
using StorefrontModel = VirtoCommerce.Storefront.Model;

namespace VirtoCommerce.LiquidThemeEngine.Converters
{
    public static class CustomerReviewConverter
    {
        public static CustomerReview ToShopifyModel(this StorefrontModel.CustomerReviews.CustomerReview review)
        {
            var converter = new ShopifyModelConverter();
            return converter.ToLiquidCustomerReview(review);
        }
    }


    public partial class ShopifyModelConverter
    {
        public virtual CustomerReview ToLiquidCustomerReview(StorefrontModel.CustomerReviews.CustomerReview review)
        {
            CustomerReview result = null;

            if (review != null)
            {
                result = new CustomerReview()
                {
                    Id = review.Id,
                    AuthorNickname = review.AuthorNickname,
                    Content = review.Content,
                    IsActive = review.IsActive,
                    ProductId = review.ProductId,
                    CreatedDate = review.CreatedDate,

                    Rating = review.Rating,
                    LikeCount = review.LikeCount,
                    DislikeCount = review.DislikeCount


                };
                var evaluation = review.CurrentUserEvaluation;
                if (evaluation != null)
                {

                    result.CurrentUserEvaluation = new CustomerReviewEvaluation()
                    {
                        CustomerId = evaluation.CustomerId,
                        CustomerReviewId = evaluation.CustomerReviewId,
                        ReviewIsLiked = evaluation.ReviewIsLiked
                    };
                }

            }

            return result;
        }
    }
}
