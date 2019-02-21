using System.Collections.Generic;
using VirtoCommerce.Storefront.Model.Common;

namespace VirtoCommerce.Storefront.Model
{
    /// <summary>
    /// The form object is used within the form tag. It contains attributes of its parent form.
    /// </summary>
    /// <remarks>
    /// https://docs.shopify.com/themes/liquid-documentation/objects/form
    /// </remarks>
    public partial class Form : ValueObject
    {
        public Form()
        {
            PostedSuccessfully = true;
            Properties = new Dictionary<string, object>();
            Errors = new List<string>();
        }


        /// <summary>
        /// Returns an array of strings if the form was not submitted successfully.
        /// The strings returned depend on which fields of the form were left empty or contained errors.
        /// </summary>
        public IList<string> Errors { get; set; }

        /// <summary>
        /// Returns true if the form was submitted successfully, or false if the form contained errors.
        /// All forms but the address form set that property.
        /// The address form is always submitted successfully.
        /// </summary>
        public bool? PostedSuccessfully { get; set; }

        public IDictionary<string, object> Properties { get; set; }


    }
}