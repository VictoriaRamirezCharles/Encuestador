using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class User 
    { 
      public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }


    public User(string username, string password)
    {
        this.UserName = username;
        this.Password = password;
    }
    public User(string name, string lastname, string username, string password)
    {
        this.Name = name;
        this.LastName = lastname;
        this.UserName = username;
        this.Password = password;
    }
}
}
