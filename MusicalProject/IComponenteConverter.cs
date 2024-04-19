using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalProject
{
    internal class IComponenteConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var item = JObject.Load(reader);
            object target = null;

            switch (item["Version"].Value<string>()) // this is the property differentiater
            {
                case "brano":
                    target = new Brano();
                    break;
                case "playlist":
                    target = new Playlist();
                    break;
                case "cartella":
                    target = new Cartella();
                    break;
                default:
                    throw new NotImplementedException();
            }

            serializer.Populate(item.CreateReader(), target);

            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IComponente).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }
    }
}
