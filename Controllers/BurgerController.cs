using System.Collections.Generic;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
    public class BurgerController : ControllerBase
    {
    private readonly BurgerService _bs;

    public BurgerController(BurgerService burgerService)
        {
            _bs = burgerService;
        }


    [HttpGet]
        public ActionResult<IEnumerable<Burger>> Get()
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