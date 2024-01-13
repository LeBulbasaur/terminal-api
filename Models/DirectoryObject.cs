namespace Terminal.Models
{
    public class DirectoryObject : SystemObject
    {

        public DirectoryObject(int id, string name, int parentId) : base(id, name, parentId)
        {
            Type = "dir";
        }

        // delete directory and all its children recursively
        public override void DeleteObject(List<SystemObject> systemObjects)
        {
            List<SystemObject> children = systemObjects.Where(p => p.ParentId == this.Id).ToList();
            foreach(SystemObject child in children)
            {
                child.DeleteObject(systemObjects);
            }
            int index = systemObjects.FindIndex(p => p.Id == this.Id);
            if(index != -1)
            {
                systemObjects.RemoveAt(index);
            }
            Console.WriteLine("Deleted children of directory with id: " + this.Id);
        }
    }
}