using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IBookRepozitory<T>
    { 
        IEnumerable<T> Load();
        void Save(IEnumerable<T> books);
        
    }
}
