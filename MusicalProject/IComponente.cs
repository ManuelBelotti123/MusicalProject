using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalProject
{
    internal interface IComponente
    {
        void Add(IComponente c);
        void Remove(IComponente c);
        void GetChild(int i);
        string ToString();
        bool Equals(object obj);
        int GetHashCode();
    }
}
