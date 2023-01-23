using Advert.API.Entities.Concrete;
using Advert.API.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Advert.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICarRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ICarRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("GetCars")]
        [ProducesResponseType(typeof(IEnumerable<Car>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _repository.GetCars();
            return Ok(cars);
        }

        [HttpGet("[action]/{id:length(24)}", Name = "GetCar")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Car>> GetCarById(string id)
        {
            var car = await _repository.GetCar(id);
            if (car == null)
            {
                _logger.LogError($"Car with id: {id}, not found.");
                return NotFound();
            }
            return Ok(car);
        }

        [Route("[action]/{title}", Name = "GetCarByTitle")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Car>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarByTitle(string title)
        {
            var cars = await _repository.GetCarByTitle(title);
            return Ok(cars);
        }

        [HttpPost("CreateCar")]
        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Car>> CreateCar([FromBody] Car car)
        {
            await _repository.CreateCar(car);

            return CreatedAtRoute("GetCar", new { id = car.Id }, car);
        }

        [HttpPut("UpdateCar")]
        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCar([FromBody] Car car)
        {
            return Ok(await _repository.UpdateCar(car));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteCar")]
        [ProducesResponseType(typeof(Car), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCarById(string id)
        {
            return Ok(await _repository.DeleteCar(id));
        }
    }
}