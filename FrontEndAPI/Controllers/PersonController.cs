using FrontEndLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService) {

            this._personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        [HttpGet("details")]
        public IActionResult GetPersonData() {


            var res = _personService.GetPersonDetails();
           return new JsonResult(_personService.GetPersonDetails());
        
        }
    }
}
