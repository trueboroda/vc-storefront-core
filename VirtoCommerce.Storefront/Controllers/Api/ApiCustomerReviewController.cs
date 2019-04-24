using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtoCommerce.Storefront.Infrastructure;
using VirtoCommerce.Storefront.Model;
using VirtoCommerce.Storefront.Model.Common;
using VirtoCommerce.Storefront.Model.CustomerReviews;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtoCommerce.Storefront.Controllers.Api
{
    [StorefrontApiRoute("customerreviews")]
    public class ApiCustomerReviewController : StorefrontControllerBase
    {

        private readonly ICustomerReviewService _customerReviewService;

        public ApiCustomerReviewController(IWorkContextAccessor workContextAccessor, IStorefrontUrlBuilder urlBuilder, ICustomerReviewService customerReviewService)
            : base(workContextAccessor, urlBuilder)
        {
            _customerReviewService = customerReviewService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CustomerReview>> CreateCustomerReview([FromBody]CustomerReview model)
        {
            if (!WorkContext.CurrentUser.IsRegisteredUser)
            {
                return Forbid();
            }
            var createdReview = await _customerReviewService.CreateCustomerReviewAsync(model);
            return Ok(createdReview);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteCustomerReview([FromBody]CustomerReview model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (model.CreatedBy != WorkContext.CurrentUser.Id)
            {
                return Forbid();
            }

            await _customerReviewService.DeleteCustomerReviewAsync(model);

            return Ok();

        }


        [HttpPut("evaluation")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ApplyCustomerReviewEvaluation([FromBody]CustomerReviewEvaluation evaluation)
        {
            if (!WorkContext.CurrentUser.IsRegisteredUser)
            {
                return Forbid();
            }
            await _customerReviewService.SaveEvaluationAsync(WorkContext.CurrentProduct.Id, evaluation);
            return Ok();
        }


    }
}
