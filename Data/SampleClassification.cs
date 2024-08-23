using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public static class SampleClassification
    {
        public const int NumberOfClassification = 6;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "1","Mammal" },
            new List<string> { "2","Reptile" },
            new List<string> { "3","Bird" },
            new List<string> { "4","Insect" },
            new List<string> { "5","Fish" },
            new List<string> { "6","Invertebrate" }
        };

        public static IEnumerable<Classification> GetClassifications()
        {
            return Enumerable.Range(0, NumberOfClassification).Select(CreateRandomClassification);
        }

        private static Classification CreateRandomClassification(int index)
        {

            return new Classification
            {
                Id = int.Parse(Data[index][0]),
                Name = Data[index][1]
            };
        }
    }
}
