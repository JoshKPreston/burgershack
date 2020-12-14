using System.Collections.Generic;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class FriesController : ControllerBase
    {
    private readonly FriesService _bs;

    public FriesController(FriesService friesService)
        {
            _bs = friesService;
        }


    [HttpGet]
        public ActionResult<IEnumerable<Fries>> Get()
        {
            try
            {
                return Ok(_bs.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);         
            }
        }
    }
}