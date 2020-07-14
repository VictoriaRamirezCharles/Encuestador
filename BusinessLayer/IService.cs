using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IService<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int index);
        bool Get(string name);
        int GetId(T item);
        bool validPassWord(string name, string password);


    }
}
