using Terminal.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.CompilerServices;

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

    public static bool AddDirectory(DirectoryObject file)
    {
        if (SystemObjects.Count() > 32 || file.Name.Length > 12){
            return false;
        }
        file.Id = SystemObjects.Max(p => p.Id) + 1;
        SystemObjects.Add(file);
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
        Console.WriteLine("Added new directory");
        return true;
    }

    public static bool AddTextFile(TextFileObject file)
    {
        if (SystemObjects.Count() > 32 || file.Name.Length > 12){
            return false;
        }
        file.Id = SystemObjects.Max(p => p.Id) + 1;
        SystemObjects.Add(file);
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
        Console.WriteLine("Added new text file");
        return true;
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
        if (file.Content.Length > 250){
            return;
        }
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

    public static bool Delete(int id)
    {
        string[] ForbiddenNames = ["root", "home", "bin", "Documents", "README.md"];
        int index = SystemObjects.FindIndex(p => p.Id == id);
        if(index == -1)
        {
            throw new Exception("File not found");
        }
        if(ForbiddenNames.Any(SystemObjects[index].Name.Contains)){
            return false;
        }
        SystemObjects[index].DeleteObject(SystemObjects);
        string output = JsonConvert.SerializeObject(SystemObjects, Formatting.Indented);
        File.WriteAllText("./Services/systemobjects.json", output);
        return true;
    }
}