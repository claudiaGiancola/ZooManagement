using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;
using ZooManagement.Models.Request;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {

        Animal GetAnimalById(int id);

        Animal Create(CreateAnimalRequest animal);

        IEnumerable<Animal> Search(AnimalSearchRequest search);

        int Count(AnimalSearchRequest search);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animals
                .Single(animal => animal.Id == id);
        }

        public IEnumerable<Animal> Search(AnimalSearchRequest search)
        {

            return _context.Animals
                .Include(p => p.Species)
                .Where(p => search.Name == null || p.Name == search.Name)
                .Where(p => search.SpeciesId == null || p.SpeciesId == search.SpeciesId)
                .Where(p => search.ClassificationId == null || p.Species.ClassificationId == search.ClassificationId)
                .Where(p => search.Age == null || DateTime.Today.Year - p.DateOfBirth.Year - (DateTime.Today.DayOfYear < p.DateOfBirth.DayOfYear ? 1 : 0) == search.Age)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);

        }

        public int Count(AnimalSearchRequest search)
        {
            return _context.Animals
                .Count(p => p.Name == search.Name && p.SpeciesId == search.SpeciesId);
        }

        public Animal Create(CreateAnimalRequest animal)
        {
            var insertResult = _context.Animals.Add(new Animal
            {
                Name = animal.Name,
                SpeciesId = animal.SpeciesId,
                Sex = animal.Sex,
                DateOfBirth = animal.DateOfBirth,
                DateCameToZoo = animal.DateCameToZoo
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }
    }
}