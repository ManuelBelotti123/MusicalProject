using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicalProject
{
    [JsonConverter(typeof(IComponenteConverter))]
    internal interface IComponente
    {
        //versione per IComponenteConverter
        string Version { get; set; }
        //metodi
        void Add(IComponente c);
        void Remove(IComponente c);
        IComponente GetChild(int i);
        string ToString();
        bool Equals(object obj);
        int GetHashCode();
    }
}
