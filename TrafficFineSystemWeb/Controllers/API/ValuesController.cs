using Microsoft.AspNetCore.Mvc;
using TrafficFineSystemWeb.Data;
using TrafficFineSystemWeb.Models;
using TrafficFineSystemWeb.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrafficFineSystemWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork; //
        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        // GET: api/<ValuesController>
        [HttpGet("{VehicleNumber}")]
        public IEnumerable<DriversModel> Get(string VehicleNumber)
        {
            var test = _unitOfWork.DriversAdd.GetAll();
            var driver = test.Where(x => x.VechileNumber == VehicleNumber);
            return driver;
        }


    }
}