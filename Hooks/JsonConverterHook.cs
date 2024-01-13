using Terminal.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class SystemObjectJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(SystemObject));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);
        if (jo["Type"].Value<string>() == "dir")
        {
            return jo.ToObject<DirectoryObject>();
        }
        else if (jo["Type"].Value<string>() == "txt")
        {
            return jo.ToObject<TextFileObject>();
        }
        else
        {
            return jo.ToObject<SystemObject>();
        }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}


