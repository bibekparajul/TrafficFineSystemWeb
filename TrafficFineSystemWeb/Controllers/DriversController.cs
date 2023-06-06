using Microsoft.AspNetCore.Mvc;
using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Controllers
{
    public class DriversController : Controller
    {

        private readonly IUnitOfWork _unitOfWork; //
        private readonly ApplicationDbContext _context;
        public DriversController(IUnitOfWork unitOfWork)    //
        {
            _unitOfWork = unitOfWork;
        }
        //the below is used to retrieve and display the data from database and show it to page 
        //configured in Index.cshtml 
        public IActionResult Index()
        {
            IEnumerable<DriversModel> objDriverList = _unitOfWork.DriversAdd.GetAll(); //   
            return View(objDriverList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }


        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Create(DriversModel obj)
        {

            //custom validation can be done as follows
            if (obj.Name == obj.LicenseNumber.ToString())
            {
                ModelState.AddModelError("name", "Name and License number cannot be same");
            }
            var checkVehicleNum = _unitOfWork.DriversAdd.GetFirstorDefault(x => x.VechileNumber == obj.VechileNumber);
            if (checkVehicleNum != null)
            {
                ModelState.AddModelError("name", "Vehicle Number ALready exists");

            }

            var checkLicenseNum = _unitOfWork.DriversAdd.GetFirstorDefault(x=> x.LicenseNumber == obj.LicenseNumber);

            if (checkLicenseNum!=null)
            {
                ModelState.AddModelError("licensenumber", "License Number Already exists");

            }

            //server side validation because name cannot be empty
            if (ModelState.IsValid )
            {

                _unitOfWork.DriversAdd.Add(obj);    //
                _unitOfWork.Save();      //
                TempData["success"] = "Drivers Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET(for Edit) (Validation remains same)
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //find incase of priimary key only if not below sabai bujhxa!!!
            var driverFromDbFirst = _unitOfWork.DriversAdd.GetFirstorDefault(u => u.VechileNumber == id);    //
            if (driverFromDbFirst == null)
            {
                return NotFound();
            }
            return View(driverFromDbFirst);
        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Edit(DriversModel obj)
        {

            //custom validation can be done as follows
            if (obj.Name == obj.LicenseNumber.ToString())
            {
                ModelState.AddModelError("name", "Name and License number cannot be same");
            }
            //server side validation because name cannot be empty
            if (ModelState.IsValid)
            {
                _unitOfWork.DriversAdd.Update(obj);   //
                _unitOfWork.Save();        //    
                TempData["success"] = "Driver Updated Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET(for Delete) 
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var driverFromDbFirst = _unitOfWork.DriversAdd.GetFirstorDefault(u => u.VechileNumber == id);
            if (driverFromDbFirst == null)
            {
                return NotFound();
            }
            return View(driverFromDbFirst);
        }

        //POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePOST(DriversModel obj)
        {

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.DriversAdd.Remove(obj);    
            _unitOfWork.Save();         
            TempData["success"] = "Drivers Deleted Successfully";

            return RedirectToAction("Index");


        }

    }
}
