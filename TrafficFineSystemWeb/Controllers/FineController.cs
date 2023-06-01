using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Mail;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Models.ViewModel;
using TrafficFineSystemWeb.Repository.IRepository;

namespace TrafficFineSystemWeb.Controllers
{
    public class FineController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostEnvironment;


        public FineController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)    //
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        //GET


        //GET(for Edit) (Validation remains same)
        public IActionResult Upsert(int? fineId)
        {
            //ViewBag ra viewdata ko satta

            FineVM fineVM = new()
            {
                Fine = new(),
                DriverList = _unitOfWork.DriversAdd.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.VechileNumber.ToString()

                }),

                TrafficList = _unitOfWork.TrafficAdd.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.TrafficId.ToString()

                }),

            };

            if (fineId == null || fineId == 0)

            {

                return View(fineVM);
            }
            else
            {
                fineVM.Fine = _unitOfWork.FineAdd.GetFirstorDefault(u => u.FineId == fineId);

                return View(fineVM);

            }


        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Upsert(FineVM obj)
        {

            if (ModelState.IsValid)
            {


                if (obj.Fine.FineId == 0)
                {
                    _unitOfWork.FineAdd.Add(obj.Fine);

                }
                else
                {
                    _unitOfWork.FineAdd.Update(obj.Fine);


                }   //
                //for creating firstproduct
                _unitOfWork.Save();        //    
                TempData["success"] = "Fine Created Successfully";


                //smpt email sending after creating the ticket
                var fineFromDb = _unitOfWork.FineAdd.GetFirstorDefault(u => u.FineId == obj.Fine.FineId, includeProperties: "DriversAdd,TrafficAdd");

                string fromMail = "trafficfine11@gmail.com";
                string fromPassword = "etdytbbrihvhkzbo";
                string toMail = fineFromDb.DriversAdd.Email;

                using (var message = new MailMessage())
                {

                    message.From = new MailAddress(fromMail);
                    //message.To.Add(new MailAddress("samanraut120@gmail.com"));
                    message.To.Add(new MailAddress(toMail));
                    message.Subject = "This is message contains your fine ticket ID and Fine Type";
                    message.Body = " Fine ID : " + obj.Fine.FineId + "\nFine Type : " +
                        obj.Fine.FineType +"\n\n\n For Payment You Need To Visit the Site"+"\n\nThankYou!";

                    using (var smtp = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPassword),
                        EnableSsl = true,

                    })

                        smtp.Send(message);

                }


                //smtp ticket created

                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //apiendpoints data tables (edit and delete ko lagi)

        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            var driversList = _unitOfWork.FineAdd.GetAll(includeProperties: "DriversAdd,TrafficAdd");
            return Json(new { data = driversList });
        }
        //delete
        [HttpDelete]                 //used to handle the http request
        public IActionResult Delete(int? id)
        {

            var obj = _unitOfWork.FineAdd.GetFirstorDefault(u => u.FineId == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.FineAdd.Remove(obj);    //
            _unitOfWork.Save();         //
            return Json(new { success = true, message = "Successfully  deleted" });

        }
        #endregion
    }
}
