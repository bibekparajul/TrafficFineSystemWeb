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

        [HttpPost]
       
        public IActionResult SeeFine(int fineId)
        {

            //if (FineId == null || FineId == 0)
            //{
            //    return NotFound();
            //}
            //var fineFromDb = _db.FineModels.Find(FineId);
            //if (fineFromDb == null)
            //{
            //    return NotFound();
            //}
            //return View(fineFromDb);


            //using unitofwork concept

            var fineFromDb = _unitOfWork.FineAdd.GetFirstorDefault(u => u.FineId == fineId, includeProperties: "DriversAdd,TrafficAdd");

            return View(fineFromDb);

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
