using Lab2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalOwnerDbContext _db;

        public AnimalsController()
        {
            _db = new AnimalOwnerDbContext();
        }

        [HttpGet]
        public Animal[] GetAnimals()
        {
            return _db.Animals.ToArray();
        }

        [HttpGet("{id}")]
        public Animal? GetAnimal(int id)
        {
            return _db.Animals.FirstOrDefault(a => a.Id == id);
        }

        [HttpGet("owner/{ownerId}")]
        public Animal[] GetAnimalsByOwner(int ownerId)
        {
            return _db.Animals
                .Where(a => a.OwnerId == ownerId)
                .ToArray();
        }

        [HttpGet("search")]
        public Animal[] SearchAnimals(string species)
        {
            return _db.Animals
                .Where(a => a.Species.Contains(species))
                .ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateAnimal(int id, [FromBody] Animal animal)
        {
            var existing = _db.Animals.FirstOrDefault(a => a.Id == id);

            if (existing != null)
            {
                existing.Name = animal.Name;
                existing.Species = animal.Species;
                existing.Age = animal.Age;
                existing.OwnerId = animal.OwnerId;
                existing.VeterinarianId = animal.VeterinarianId;

                _db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteAnimal(int id)
        {
            var animal = _db.Animals.FirstOrDefault(a => a.Id == id);

            if (animal != null)
            {
                _db.Animals.Remove(animal);
                _db.SaveChanges();
            }
        }
    }
}