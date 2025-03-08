using Microsoft.AspNetCore.Mvc;
using Neosoft_Ankita_Khokale_04March2025.Repository;
using Neosoft_Ankita_Khokale_04March2025.Models;
using System.Collections.Generic;

namespace Neosoft_Ankita_Khokale_04March2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository _repo;

        public CityController(CityRepository repo)
        {
            _repo = repo;
        }

        // Get all cities
        [HttpGet]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            return Ok(_repo.GetCities());
        }

        // Get cities by state ID (for cascading dropdowns)
        [HttpGet("byState/{stateId}")]
        public ActionResult<IEnumerable<City>> GetCitiesByStateId(int stateId)
        {
            return Ok(_repo.GetCitiesByStateId(stateId));
        }

    /*    // Add a new city
        [HttpPost]
        public IActionResult AddCity(City city)
        {
            _repo.AddCity(city);
            return Ok("City added successfully");
        }

        // Delete a city by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            _repo.DeleteCity(id);
            return Ok("City deleted successfully");
        }*/
    }
}