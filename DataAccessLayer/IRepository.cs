using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T>
    {
        bool Add(T item);
        bool Update(T item);
        bool Delete(int id);
        bool Getting(string name);
        int GettingId(T item);
        bool validPass(string name, string password);
        
    }
}
