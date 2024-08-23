using System.ComponentModel.DataAnnotations;
using ZooManagement.Helpers;

namespace ZooManagement.Models.Database
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCameToZoo { get; set; }
    }
}
