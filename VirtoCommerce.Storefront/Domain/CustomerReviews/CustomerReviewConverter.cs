using models = VirtoCommerce.Storefront.Model.CustomerReviews;
using platformDto = VirtoCommerce.Storefront.AutoRestClients.CustomerReviewsModuleApi.Models;

namespace VirtoCommerce.Storefront.Domain.CustomerReviews
{
    public static partial class CustomerReviewConverter
    {


        public static models.CustomerReviewEvaluation ToEvaluation(this platformDto.CustomerReviewEvaluation dto)
        {
            var result = new models.CustomerReviewEvaluation()
            {
                Id = dto.Id,
                CustomerReviewId = dto.CustomerReviewId,
                CustomerId = dto.CustomerId,
                ReviewIsLiked = dto.ReviewIsLiked.GetValueOrDefault()
            };
            return result;
        }


        public static platformDto.CustomerReviewEvaluation ToEvaluationDto(this models.CustomerReviewEvaluation dto)
        {
            var result = new platformDto.CustomerReviewEvaluation()
            {
                Id = dto.Id,
                CustomerReviewId = dto.CustomerReviewId,
                CustomerId = dto.CustomerId,
                ReviewIsLiked = dto.ReviewIsLiked
            };
            return result;
        }

        public static models.CustomerReview ToCustomerReview(this platformDto.CustomerReview dto)
        {
            var result = new models.CustomerReview()
            {
                Id = dto.Id,
                AuthorNickname = dto.AuthorNickname,
                Content = dto.Content,
                IsActive = dto.IsActive.GetValueOrDefault(),
                ProductId = dto.ProductId,
                Rating = dto.Rating.GetValueOrDefault(),
                LikeCount = dto.LikeCount.GetValueOrDefault(),
                DislikeCount = dto.DislikeCount.GetValueOrDefault(),
                CreatedDate = dto.CreatedDate.GetValueOrDefault(),
                ModifiedDate = dto.ModifiedDate,
                CreatedBy = dto.CreatedBy,
                ModifiedBy = dto.ModifiedBy

            };
            return result;
        }


        public static platformDto.CustomerReview ToCustomerReviewDto(this models.CustomerReview model)
        {
            var result = new platformDto.CustomerReview()
            {

                AuthorNickname = model.AuthorNickname,
                Content = model.Content,
                IsActive = model.IsActive,
                ProductId = model.ProductId,
                Rating = model.Rating,

            };

            return result;
        }

        public static platformDto.CustomerReviewSearchCriteria ToSearchCriteriaDto(this Model.CustomerReviews.CustomerReviewSearchCriteria criteria)
        {
            var result = new platformDto.CustomerReviewSearchCriteria()
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
