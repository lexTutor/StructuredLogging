using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index(int value)
        {
            try
            {
                if (value == 1)
                {
                    return Ok();
                }

                throw new ArgumentOutOfRangeException("We only deal with 1's");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Error at index");
                return BadRequest();
            }
        }
    }
}
