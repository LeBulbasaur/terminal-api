namespace Terminal.Models
{
    public class RepositoryModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }

        public RepositoryModel(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}