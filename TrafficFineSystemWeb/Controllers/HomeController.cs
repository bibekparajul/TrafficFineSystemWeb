using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Diagnostics;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewBag.Drivers = _unitOfWork.DriversAdd.GetAll();
            //var count = ViewBag.Drivers.Count;
            IEnumerable<FineModel> fineList = _unitOfWork.FineAdd.GetAll(includeProperties: "DriversAdd,TrafficAdd");
            return View(fineList);
        }

        //[Authorize]

        public IActionResult Details(int fineId)
        {
         
            var fineFromDb = _unitOfWork.FineAdd.GetFirstorDefault(u => u.FineId == fineId, includeProperties: "DriversAdd,TrafficAdd");

            return View(fineFromDb);
        }

        //search here


        public ActionResult SearchFunc(string search)
        {
            IEnumerable<FineModel> fineList = _unitOfWork.FineAdd.GetAll(includeProperties: "DriversAdd,TrafficAdd");

            return View(fineList.Where(x => x.LicenseNumber.Contains(search) || search == null).ToList());
        }



        //search ends here


        //payment here


        public IActionResult Pay()
        {


            var domain = "https://localhost:7182/";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>(),

                Mode = "payment",
                SuccessUrl = domain + $"Landing/success",
                CancelUrl = domain + $"Home/cancel",
            };


            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(100),
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Fine",
                    },
                },
                Quantity = 1,
            };
            options.LineItems.Add(sessionLineItem);

            //  }

            var service = new SessionService();
            Session session = service.Create(options);
            _unitOfWork.Save();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

        }


        //payment done

        public IActionResult Success()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}