using Excell_On_Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.BillingPortal;
using Stripe.Checkout;
using Stripe.FinancialConnections;
using System.Security.Claims;

namespace Excell_On_Services.Controllers
{



    public class WebsiteController : Controller
    {

        [BindProperty]

        public ClientServices ServiceOrder { get; set; }



        private readonly ApplicationDbContext _AppDbContext;
        public WebsiteController(ApplicationDbContext AppDb)
        {
            this._AppDbContext = AppDb;
        }

        public IActionResult Index()
        {
            ViewBag.Data = _AppDbContext.Service.ToList();
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact con)
        {
            _AppDbContext.Contacts.Add(con);
            _AppDbContext.SaveChanges();
            return RedirectToAction("Index", "Website");
            return View();
        }

        public IActionResult Service()
        {
            ViewBag.Data = _AppDbContext.Service.ToList();
            return View();
        }

        public IActionResult Summary(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ServiceOrder = new ClientServices()
            {


                appUser =_AppDbContext.AppUsers.FirstOrDefault(x => x.Id == claims.Value),
                Service = _AppDbContext.Service.FirstOrDefault(u => u.Service_Id == id),

                Services_Id = id,
                Client_Id = claims.Value
            };
            return View(ServiceOrder);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ServiceOrder.appUser = _AppDbContext.AppUsers.FirstOrDefault(x => x.Id == claims.Value);
            ServiceOrder.Id = 0;
            ServiceOrder.Service = _AppDbContext.Service.FirstOrDefault(u => u.Service_Id == ServiceOrder.Services_Id);

            ServiceOrder.Client_Id = claims.Value;
            ServiceOrder.OrderDate = DateTime.Now;

            _AppDbContext.ClientService.Add(ServiceOrder);
            _AppDbContext.SaveChanges();

            var domain = "https://localhost:7244/";
            //var options = new SessionCreateOptions
            //{
            //    PaymentMethodTypes = new List<string>
            //    {
            //        "card",
            //    },
            //    LineItems = new List<SessionLineItemOptions>(),
            //    Mode = "payment",
            //    SuccessUrl = domain + $"Website/Index",
            //    CancelUrl = domain + $"Website/Summary",
            //};

            //var SessionLineItem = new SessionLineItemOptions
            //{
            //    PriceData = new SessionLineItemPriceDataOptions
            //    {
            //        UnitAmount = (long)(ServiceOrder.Service.ServiceChargesPerMonth * 100),
            //        Currency = "$",
            //        ProductData = new SessionLineItemPriceDataProductDataOptions
            //        {
            //            Name = ServiceOrder.Service.Service_Name
            //        },
            //    },
            //    Quantity = 1
            //};

            //options.LineItems.Add(SessionLineItem);

            //var service = new SessionService();

            return View();
        }
    }
}
