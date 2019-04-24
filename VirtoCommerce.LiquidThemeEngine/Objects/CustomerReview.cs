using System;
using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    public class CustomerReview : Drop
    {
        public string Id { get; set; }
        public string AuthorNickname { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; }

        public string ProductId { get; set; }

        public int Rating { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }


        public DateTime CreatedDate { get; set; }

        public CustomerReviewEvaluation CurrentUserEvaluation { get; set; }

    }
}
