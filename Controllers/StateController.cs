using Microsoft.AspNetCore.Mvc;
using Neosoft_Ankita_Khokale_04March2025.Repository;
using Neosoft_Ankita_Khokale_04March2025.Models;
using System.Collections.Generic;

namespace Neosoft_Ankita_Khokale_04March2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateRepository _repo;

        public StateController(StateRepository repo)
        {
            _repo = repo;
        }

        // Get all states
        [HttpGet]
        public ActionResult<IEnumerable<State>> GetStates()
        {
            return Ok(_repo.GetStates());
        }

        // Get states by country ID (for cascading dropdowns)
        [HttpGet("byCountry/{countryId}")]
        public ActionResult<IEnumerable<State>> GetStatesByCountryId(int countryId)
        {
            return Ok(_repo.GetStatesByCountryId(countryId));
        }

     /*   // Add a new state
        [HttpPost]
        public IActionResult AddState(State state)
        {
            _repo.AddState(state);
            return Ok("State added successfully");
        }

        // Delete a state by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteState(int id)
        {
            _repo.DeleteState(id);
            return Ok("State deleted successfully");
        }*/
    }
}