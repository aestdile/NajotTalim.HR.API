using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.API.Models;
using NajotTalim.HR.API.Services;

namespace NajotTalim.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IGenericCRUDService<AdressModel> _adressSvc;

        public AdressController(IGenericCRUDService<AdressModel> adressSvc)
        {
            _adressSvc = adressSvc;
        }

        // GET: api/<AdressController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _adressSvc.GetAll());
        }

        // GET api/<AdressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Adress with the given id: {id} is not found.");
            else if (id < 1)
                return BadRequest("Wrong data.");

            return Ok(await _adressSvc.Get(id));
        }

        // POST api/<AdressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdressModel adress)
        {
            var createdEmployee = await _adressSvc.Create(adress);
            var routeValues = new { id = createdEmployee.Id };
            return CreatedAtRoute(routeValues, createdEmployee);
        }

        // PUT api/<AdressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AdressModel adress)
        {
            var updatedEmployee = await _adressSvc.Update(id, adress);
            return Ok(updatedEmployee);
        }

        // DELETE api/<AdressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult = await _adressSvc.Delete(id);
            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}
