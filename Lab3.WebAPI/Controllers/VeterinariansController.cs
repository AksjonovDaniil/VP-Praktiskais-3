using Lab2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinariansController : ControllerBase
    {
        private readonly AnimalOwnerDbContext _db;

        public VeterinariansController()
        {
            _db = new AnimalOwnerDbContext();
        }

        [HttpGet]
        public Veterinarian[] GetVeterinarians()
        {
            return _db.Veterinarians.ToArray();
        }

        [HttpGet("{id}")]
        public Veterinarian? GetVeterinarian(int id)
        {
            return _db.Veterinarians.FirstOrDefault(v => v.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Veterinarian veterinarian)
        {
            _db.Veterinarians.Add(veterinarian);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateVeterinarian(
            int id,
            [FromBody] Veterinarian veterinarian)
        {
            var existing = _db.Veterinarians
                .FirstOrDefault(v => v.Id == id);

            if (existing != null)
            {
                existing.Name = veterinarian.Name;
                existing.Surname = veterinarian.Surname;
                existing.Specialization = veterinarian.Specialization;

                _db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteVeterinarian(int id)
        {
            var veterinarian = _db.Veterinarians
                .FirstOrDefault(v => v.Id == id);

            if (veterinarian != null)
            {
                _db.Veterinarians.Remove(veterinarian);
                _db.SaveChanges();
            }
        }
    }
}