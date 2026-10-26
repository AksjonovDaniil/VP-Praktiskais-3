using Lab2.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly AnimalOwnerDbContext _db;

        public OwnersController()
        {
            _db = new AnimalOwnerDbContext();
        }

        [HttpGet]
        public Owner[] GetOwners()
        {
            return _db.Owners.ToArray();
        }

        [HttpGet("{id}")]
        public Owner? GetOwner(int id)
        {
            return _db.Owners.FirstOrDefault(o => o.Id == id);
        }

        [HttpGet("search")]
        public Owner[] SearchOwners(string surname)
        {
            return _db.Owners
                .Where(o => o.Surname.Contains(surname))
                .ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            _db.Owners.Add(owner);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateOwner(int id, [FromBody] Owner owner)
        {
            var existing = _db.Owners.FirstOrDefault(o => o.Id == id);

            if (existing != null)
            {
                existing.Name = owner.Name;
                existing.Surname = owner.Surname;
                existing.Email = owner.Email;

                _db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteOwner(int id)
        {
            var owner = _db.Owners.FirstOrDefault(o => o.Id == id);

            if (owner != null)
            {
                _db.Owners.Remove(owner);
                _db.SaveChanges();
            }
        }
    }
}