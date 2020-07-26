using System;
using System.Collections.Generic;
using System.Data;
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
        bool Get(string name,  string username = null);
        int GetId(T item);
        bool validPassWord(string name, string password);
        DataTable GetAll(string username);
        DataTable GetAllNames(string username);
        DataTable GetAllAnwers(string username);


    }
}
