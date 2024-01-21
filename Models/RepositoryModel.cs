namespace Terminal.Models
{
    public class RepositoryModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }

        public RepositoryModel(string name, string url, string description)
        {
            Name = name;
            Url = url;
            Description = description;
        }
    }
}