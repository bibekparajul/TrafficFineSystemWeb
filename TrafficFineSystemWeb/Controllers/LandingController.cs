using Microsoft.AspNetCore.Mvc;
using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Controllers
{
    public class LandingController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public LandingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public LandingController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexFine()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ButtonClick()
       
        {
    
            // Redirect to the OtherAction method
            return RedirectToAction("IndexFine");
        }

        [HttpPost]
       
        public IActionResult SeeFine(int fineId)
        {



            var fineFromDb = _unitOfWork.FineAdd.GetFirstorDefault(u => u.FineId == fineId, includeProperties: "DriversAdd,TrafficAdd");

            if (fineFromDb == null)
            {
                TempData["ErrorMessage"] = "Fine Id doesn't exists";
                return RedirectToAction("IndexFine", "Landing"); // Redirect to another action or view
            }

            return View(fineFromDb);

        }

        public IActionResult Success()
        {
            return View();
        }




        [HttpPost]
        public IActionResult ViewAdmin()
        {
            ViewBag.Drivers = _unitOfWork.DriversAdd.GetAll();
            ViewBag.Traffic = _unitOfWork.TrafficAdd.GetAll();
            IEnumerable<FineModel> fineList = _unitOfWork.FineAdd.GetAll(includeProperties: "DriversAdd,TrafficAdd");

            return View(fineList);
        }


        public IActionResult LoginAdmin()
        {
            return View();
        }
    }
}
