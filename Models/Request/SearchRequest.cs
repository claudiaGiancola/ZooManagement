namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }

    public class AnimalSearchRequest : SearchRequest
    {
        public int? SpeciesId { get; set; }
        public string? Name { get; set; }

        public string SearchText()
        {
            return SpeciesId.ToString() + Name;
        }

        public override string Filters => SearchText() == null ? "" : $"&speciesid={SpeciesId}&name={Name}";
    }
}