using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using task1.Models;

namespace task1.Filters
{
    public class MyCustomTypeFilter:ActionFilterAttribute
    {
        private readonly ILogger<MyCustomTypeFilter> _logger;
        private readonly IConfiguration _configuration;

        public MyCustomTypeFilter(
            ILogger<MyCustomTypeFilter> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var types = _configuration.GetSection("CarTypes").Get<string[]>();

            //var car = context.ActionArguments["car"] as Car;

            //var checkType = types.FirstOrDefault(c => c.Equals(car.Type));

            //if (checkType is null || car is null)
            //{
            //    //Short Circuit with BadRequest
            //    context.ModelState.AddModelError("Type", "Car Type is not exsist");
            //    context.Result = new BadRequestObjectResult(context.ModelState);
            //}

            base.OnActionExecuting(context);

            var types = _configuration.GetSection("CarTypes").Get<List<string>>();

            if (types != null && context.ActionArguments["car"] is Car car && car != null)
            {
                if (!types.Any(t => t == car.Type))
                {
                    context.ModelState.AddModelError("Type", $"{car.Type} is not exsist ");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }

        }
    }
    }

