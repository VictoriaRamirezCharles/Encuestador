using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDataBaseRepository : BaseRepository, IRepository<User>
    {
        public UserDataBaseRepository(SqlConnection connection) : base(connection)
        {
        }

        public bool Add(User item)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_Users(Name, LastName, UserName, Password) values(@name,@lastname,@username,@password)", GetConnection());

            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@lastname", item.LastName);
            command.Parameters.AddWithValue("@username", item.UserName);
            command.Parameters.AddWithValue("@password", item.Password);
           

            return executeDml(command);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

     

        public bool Getting(string name)
        {

            string command = string.Format("SELECT * FROM Tbl_Users WHERE USERNAME='{0}'", name);
            DataSet ds=Get(command);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Username = ds.Tables[0].Rows[0]?["UserName"].ToString().Trim();
                if (Username == name)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public bool validPass(string name, string pass)
        {

            string command = string.Format("SELECT PASSWORD FROM Tbl_Users WHERE UserName='{0}'", name);

            DataSet ds = Get(command);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string password = ds.Tables[0].Rows[0]?["Password"].ToString().Trim();
                if (password == pass)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        public bool Update(User item)
        {
            throw new NotImplementedException();
        }

        public int GettingId(User item)
        {
            throw new NotImplementedException();
        }
    }
}
