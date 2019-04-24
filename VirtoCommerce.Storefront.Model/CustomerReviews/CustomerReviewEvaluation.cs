using System;
using VirtoCommerce.Storefront.Model.Common;

namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    public class CustomerReviewEvaluation : Entity
    {

        public bool ReviewIsLiked { get; set; }

        public string CustomerReviewId { get; set; }

        public string CustomerId { get; set; }



        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }


    }
}
