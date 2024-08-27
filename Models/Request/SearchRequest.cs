namespace ZooManagement.Models.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public virtual string Filters => "";
    }
    

    // public class AnimalSearchRequest : SearchRequest
    // {
    //     public int? SpeciesId { get; set; }        
    //     public override string Filters => SpeciesId == null ? "" : $"&speciesid={SpeciesId}";
    // }

        public class AnimalSearchRequest : SearchRequest
    {
        public int? SpeciesId { get; set; }        
        public string? Name { get; set; }
        public override string Filters => Name == null ? "" : $"&speciesid={SpeciesId}&name={Name}";
    }
}