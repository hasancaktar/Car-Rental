using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Merhaba";
        }
    }
}
