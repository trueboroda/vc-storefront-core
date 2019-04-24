using System;
using System.Runtime.Serialization;
using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    [DataContract]
    public class CustomerReview : Drop
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string AuthorNickname { get; set; }

        public string Content { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public int LikeCount { get; set; }
        [DataMember]
        public int DislikeCount { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public CustomerReviewEvaluation CurrentUserEvaluation { get; set; }

    }
}
