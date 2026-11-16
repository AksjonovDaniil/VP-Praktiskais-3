using Lab2.DataAccess;

namespace Lab2.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new AnimalOwnerDbContext();

            // OWNER
            var owner = db.Owners.FirstOrDefault(o => o.Email == "janis@example.com");

            if (owner == null)
            {
                owner = new Owner
                {
                    Name = "Janis",
                    Surname = "Berzins",
                    Email = "janis@example.com"
                };

                db.Owners.Add(owner);
            }

            // VETERINARIAN
            var veterinarian = db.Veterinarians
                .FirstOrDefault(v => v.Name == "Anna" && v.Surname == "Kalnina");

            if (veterinarian == null)
            {
                veterinarian = new Veterinarian
                {
                    Name = "Anna",
                    Surname = "Kalnina",
                    Specialization = "Small animals"
                };

                db.Veterinarians.Add(veterinarian);
            }

            db.SaveChanges();

            // ADD
            var existingAnimal = db.Animals
                .FirstOrDefault(a => a.Name == "Rex");

            if (existingAnimal == null)
            {
                var animal = new Animal
                {
                    Name = "Rex",
                    Species = "Dog",
                    Age = 5,
                    Owner = owner,
                    Veterinarian = veterinarian
                };

                db.Animals.Add(animal);
                db.SaveChanges();

                System.Console.WriteLine("Animal added.");
            }

            // WHERE
            var dogs = db.Animals
                .Where(a => a.Species == "Dog")
                .ToList();

            System.Console.WriteLine();
            System.Console.WriteLine("Dogs:");

            foreach (var animal in dogs)
            {
                System.Console.WriteLine(
                    $"{animal.Id}: {animal.Name}, {animal.Species}, age = {animal.Age}");
            }

            // FIRST OR DEFAULT
            var firstAnimal = db.Animals
                .FirstOrDefault(a => a.Name == "Rex");

            if (firstAnimal != null)
            {
                System.Console.WriteLine();
                System.Console.WriteLine(
                    $"First found animal: {firstAnimal.Name}");
            }

            // UPDATE
            var animalToUpdate = db.Animals
                .FirstOrDefault(a => a.Name == "Rex");

            if (animalToUpdate != null)
            {
                animalToUpdate.Age = 6;
                db.SaveChanges();

                System.Console.WriteLine(
                    $"Updated animal: {animalToUpdate.Name}, age = {animalToUpdate.Age}");
            }

            // DELETE
            var animalToDelete = db.Animals
                .FirstOrDefault(a => a.Name == "Rex");

            if (animalToDelete != null)
            {
                db.Animals.Remove(animalToDelete);
                db.SaveChanges();

                System.Console.WriteLine(
                    $"Deleted animal: {animalToDelete.Name}");
            }

            System.Console.ReadLine();
        }
    }
}