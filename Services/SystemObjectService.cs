using Terminal.Models;
using Newtonsoft.Json;
using Terminal.Methods;

namespace Terminal.Services;

public static class SystemObjectService
{
    static List<SystemObject> SystemObjects { get; set; }
    static SystemObjectService()
    {
        // read data from json file and deserialize it using custom converter
        string json = File.ReadAllText("./Services/systemobjects.json");
        SystemObjects = JsonConvert.DeserializeObject<List<SystemObject>>(json, new SystemObjectJsonConverter());
    }

    public static List<SystemObject> GetAll() => SystemObjects;
    public static SystemObject? Get(int id) => SystemObjects.FirstOrDefault(p => p.Id == id);

    public static void AddDirectory(DirectoryObject file)
    {
        file.Id = SystemObjects.Max(p => p.Id) + 1;
        SystemObjects.Add(file);
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
        Console.WriteLine("Added new directory");
    }

    public static void AddTextFile(TextFileObject file)
    {
        file.Id = SystemObjects.Max(p => p.Id) + 1;
        SystemObjects.Add(file);
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
        Console.WriteLine("Added new text file");
    }

    public static void UpdateDIR(DirectoryObject file)
    {
        int index = SystemObjects.FindIndex(p => p.Id == file.Id);
        if(index == -1)
        {
            throw new Exception("File not found");
        }
        SystemObjects[index] = file;
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
        Console.WriteLine("Updated file with id: " + file.Id);
    }

        public static void UpdateTXT(TextFileObject file)
    {
        int index = SystemObjects.FindIndex(p => p.Id == file.Id);
        if(index == -1)
        {
            throw new Exception("File not found");
        }
        SystemObjects[index] = file;
        Console.WriteLine(file.Name + " " + file.ParentId);
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
        Console.WriteLine("Updated file with id: " + file.Id);
    }

    public static void Delete(int id)
    {
        int index = SystemObjects.FindIndex(p => p.Id == id);
        if(index == -1)
        {
            throw new Exception("File not found");
        }
        SystemObjects[index].DeleteObject(SystemObjects);
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
    }
}