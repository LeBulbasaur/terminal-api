namespace Terminal.Models;

public abstract class SystemObject
{
        public int Id { get; set; }
        public string Name { get; set; }
        public long Date { get; set; }
        public string Type { get; set; }
        public int ParentId { get; set; }
        public SystemObject(int id, string name, int parentId)
        {
            // epoch time 10101000000
            DateTime date = DateTime.Now;
            Id = id;
            Name = name;
            Date = long.Parse(date.ToString("yyyyMMddHHmmss"));;
            ParentId = parentId;
        }
        public abstract void DeleteObject(List<SystemObject> systemObjects);

}