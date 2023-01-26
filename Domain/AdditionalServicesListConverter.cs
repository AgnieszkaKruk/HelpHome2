using HH2.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;


namespace Domain
{
    public class AdditionalServicesListConverter : JsonConverter<List<AdditionalServices>>
    {
        
        public override List<AdditionalServices> ReadJson(JsonReader reader, Type objectType, List<AdditionalServices> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var list = new List<AdditionalServices>();
            var values = JArray.Load(reader);

            foreach (var value in values)
            {
                list.Add((AdditionalServices)Enum.Parse(typeof(AdditionalServices), value.ToString()));
            }

            return list;
        }

        public override void WriteJson(JsonWriter writer, List<AdditionalServices> value, JsonSerializer serializer)
        {
            var values = new JArray();
            foreach (var item in value)
            {
                values.Add(item.ToString());
            }
            serializer.Serialize(writer, values);
        }
    }

}
