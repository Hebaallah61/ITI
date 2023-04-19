using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using task1.Filters;
using task1.Models;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase

    {
        private readonly ILogger<CarController> _logger;
        private readonly IConfiguration _config;


        public CarController(ILogger<CarController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            
        }

        private static int requestCounter = 0;//count req 
        [HttpGet]
        public ActionResult<IEnumerable<Car>>GetAll()
        {
            LogRequest();
            _logger.LogCritical($"GetAll Req");
            return Ok(CarList.Cars);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetByID(int id)
        {
            LogRequest();
            _logger.LogCritical("GetByID Req");
            Car? Car= CarList.Cars.FirstOrDefault(x => x.Id==id);
            if (Car == null) return NotFound();
            return Ok(Car);
        }

        [HttpPost]
        [Route("v1")]
        public ActionResult<Car> AddCarV1(Car? car)
        {
            LogRequest();
            _logger.LogCritical("AddCarv1 Req");
            if (car != null)
            {
                car.Id = new Random().Next(1, 1000);
                car.Type = "Gas";
                CarList.Cars.Add(car);

                return CreatedAtAction(
                    actionName: nameof(AddCarV1),
                    routeValues: new { id = car.Id },
                    value: new { Message = "Car Added" });

            }
            return BadRequest();
        }



        [HttpPost]
        [Route("v2")]
        [ServiceFilter(typeof(MyCustomTypeFilter))]
        public ActionResult<Car> AddCarV2(Car? car)
        {
            LogRequest();
            _logger.LogCritical("AddCarv2 Req");
            car.Id = new Random().Next(1, 1000);
            if (car != null)
            {
                CarList.Cars.Add(car);
                return CreatedAtAction(
                   actionName: nameof(AddCarV2),
                   routeValues: new { id = car.Id },
                   value: new { Message = "Car Added" });

            }
            return BadRequest();

        }















        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateCar(int id,Car car)
        {
            LogRequest();
            _logger.LogCritical("UpdateCar Req");
            if(car!=null)
            {
               Car? UpdatedCar=CarList.Cars.FirstOrDefault(x=>x.Id==id);
               if (UpdatedCar!=null)
                {
                    UpdatedCar.Model = car.Model;
                    UpdatedCar.Color= car.Color;
                    UpdatedCar.ProductionDate= car.ProductionDate;
                    return NoContent();
                }
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Car>DeleteCar(int id)
        {
            LogRequest();
            _logger.LogCritical("DeleteCar Req");
            if (id != null)
            {
                Car? car=CarList.Cars.FirstOrDefault(x=> x.Id==id);
                if (car != null)
                {
                    CarList.Cars.Remove(car);
                    return NoContent();
                }
            }
            return NotFound();
        }
        private void LogRequest()//function for count req
        {
            requestCounter++;
            Console.WriteLine($"Request counter: {requestCounter}");
        }
    }
}
