namespace Terminal.Models
{
    public class TextFileObject : SystemObject
    {
        public string Content { get; set; }
        
        public TextFileObject(int id, string name, int parentId, string content) : base(id, name, parentId)
        {
            Type = "txt";
            Content = content;
        }

        // delete text file
        public override void DeleteObject(List<SystemObject> systemObjects)
        {
            int index = systemObjects.FindIndex(p => p.Id == this.Id);
            if(index != -1)
            {
                systemObjects.RemoveAt(index);
            }
            Console.WriteLine("Deleted text file with id: " + this.Id);
        }
    }
}