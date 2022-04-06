using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zoo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Zoo_AnimalsController : ControllerBase
    {
        private readonly IZoo_AnimalsRepo _repo;

        public Zoo_AnimalsController(IZoo_AnimalsRepo repo)
        {
            _repo = repo;
        }

        // GET: api/<Zoo_AnimalsController>
        [HttpGet]
        public ActionResult<IEnumerable<Zoo_Animals>> GetAllAnimals()
        {
            var animals = _repo.GetAllAnimals();
            return Ok(JsonConvert.SerializeObject(animals));
        }

        // GET api/<Zoo_AnimalsController>
        [HttpGet("{animal_id}")]
        public ActionResult<Zoo_Animals> Get(int animal_id)
        {
            var animal = _repo.GetAnimal(animal_id);
            return Ok(JsonConvert.SerializeObject(animal));
        }

        // POST api/<Zoo_AnimalsController>
        [HttpPost]
        public void Post(Zoo_Animals animal)
        {
            // Gets the last animal ID that exists in order to increment to next ID
            var lastAnimal_ID = _repo.GetAllAnimals().LastOrDefault().animal_id;
            animal.animal_id = ++lastAnimal_ID;

            _repo.InsertAnimal(animal);
        }

        // PUT api/<Zoo_AnimalsController>
        [HttpPut("{animal_id}")]
        public void Put(int animal_id, Zoo_Animals animal)
        {
            var animalToUpdate = _repo.GetAnimal(animal_id);
            animal.animal_id = animal_id;

            _repo.UpdateAnimal(animal);
        }

        // DELETE api/<Zoo_AnimalsController>
        [HttpDelete("{animal_id}")]
        public void Delete(int animal_id)
        {
            var animalToDelete = _repo.GetAnimal(animal_id);
            _repo.DeleteAnimal(animalToDelete);
        }
    }
}
