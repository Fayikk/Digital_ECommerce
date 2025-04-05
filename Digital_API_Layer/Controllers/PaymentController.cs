using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace Digital_API_Layer.Controllers
{

    public class Phones
    {
        public string Name { get; set; }
        public long Amount { get; set; }
    }


    public class PaymentRequest
    {
        public List<Phones> Phones { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentController()
        {
            StripeConfiguration.ApiKey = "sk_test_51MIUdEB01rwBMrJ2DnweLtJJc3ijAgmJIlBOqsMy0txUJH3B6D08q24NBJtxyQsc00wxssa8wj40bxHhiBm5lCBk00f3buKj5m";
        }

        [HttpPost("create-checkout-session")]
        public IActionResult CreateCheckoutSession([FromBody] PaymentRequest request)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                
                LineItems = request.Phones.Select(x => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "try",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = x.Name,
                        },
                        UnitAmount = x.Amount*100,
                    },
                    Quantity = 1,
                }).ToList(),


                Mode = "payment",
                SuccessUrl = request.SuccessUrl,
                CancelUrl = request.CancelUrl,
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Ok(new { url = session.Url });


        }
    }
}
