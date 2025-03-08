using Microsoft.AspNetCore.Mvc;
using Neosoft_Ankita_Khokale_04March2025.Repository;
using Neosoft_Ankita_Khokale_04March2025.Models;
using System.Collections.Generic;

namespace Neosoft_Ankita_Khokale_04March2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryRepository _repo;
        public CountryController(CountryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return Ok(_repo.GetCountries());
        }

   /*     [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            _repo.AddCountry(country);
            return Ok("Country added successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            _repo.DeleteCountry(id);
            return Ok("Country deleted successfully");
        }*/
    }
}