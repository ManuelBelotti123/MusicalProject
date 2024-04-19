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
            JToken t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                IComponente comp = value as IComponente;
                JObject o = (JObject)t;

                if (comp != null)
                {
                    if (comp is Brano)
                    {
                        o.AddFirst(new JProperty("type", "Dog"));
                        //o.Find
                    }
                    else if (comp is Playlist)
                    {
                        o.AddFirst(new JProperty("type", "Cat"));
                    }

                    /*foreach (IComponente childcomp in childcomp.Children)
                    {
                        // ???
                    }*/

                    o.WriteTo(writer);
                }
            }
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
    }
}
