using System;
using System.Runtime.Serialization;
using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    [DataContract]
    public class CustomerReviewEvaluation : Drop
    {
        [DataMember]
        public bool ReviewIsLiked { get; set; }
        [DataMember]
        public string CustomerReviewId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
}
