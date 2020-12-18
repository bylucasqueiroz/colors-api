using System.Linq;
using Colors.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Colors.WebApi.Controllers
{
    [ApiController]
    [Route("api/colors")]
    public class ColorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllColors()
        {
            var colors = ColorsRepository.Get();
            return Ok(colors);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var colors = ColorsRepository.Get();
            var response = colors.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
            return Ok(response);
        }
    }
}