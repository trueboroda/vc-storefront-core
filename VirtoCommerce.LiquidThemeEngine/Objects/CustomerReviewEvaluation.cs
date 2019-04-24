using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    public class CustomerReviewEvaluation : Drop
    {
        public bool ReviewIsLiked { get; set; }

        public string CustomerReviewId { get; set; }

        public string CustomerId { get; set; }
    }
}
