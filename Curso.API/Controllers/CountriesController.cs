using Curso.API.Data;
using Curso.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curso.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContex _contex;

        public CountriesController(DataContex contex)
        {
            _contex = contex;
        }

        [HttpGet]
        public async Task<ActionResult> GetCountryAsync()
        {
            return Ok(await _contex.Conuntries.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostCountryAsync(Country country)
        {
            _contex.Add(country);
            await _contex.SaveChangesAsync();
            return Ok(country);
        }
    }
}
