using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SurveyDatabaseRepository : BaseRepository, IRepository<Survey>
    {
        public SurveyDatabaseRepository(SqlConnection connection) : base(connection)
        {
        }

        public bool Add(Survey item)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_Surveys(Name, QuestionQuantity, UserName) values(@name,@questionQuantity,@userName)", GetConnection());

            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@questionQuantity", item.QuestionQuantity);
            command.Parameters.AddWithValue("@userName", item.UserName);
   
            return executeDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("delete Tbl_Surveys where id = @id", GetConnection());

            command.Parameters.AddWithValue("@id", id);


            return executeDml(command);
        }

        public DataTable GetAllAnwers(string username)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllNames(string username)
        {
            throw new NotImplementedException();
        }

        public bool Getting(string name, string username)
        {
            string command = string.Format("SELECT * FROM Tbl_Surveys WHERE UserName='{0}' and Name='{1}'", username, name);
            DataSet ds = Get(command);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Name = ds.Tables[0].Rows[0]?["Name"].ToString().Trim();
                var namedba = Name.ToUpper();
                if (namedba.Equals(name))
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

        public int GettingId(Survey item)
        {

            SqlCommand command = new SqlCommand($"SELECT Id FROM Tbl_Surveys where Name= '{item.Name}'");
      
            DataSet ds = Get(command.CommandText);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int surveyId = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                item.Id = surveyId;
                return item.Id;
            }

            return 0;
        }

        public DataTable List(string username)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("select * from Tbl_Surveys where UserName='{0}'",username), GetConnection());

            return LoadData(sqlDataAdapter);
        }

        public bool Update(Survey item)
        {
            SqlCommand command = new SqlCommand("update Tbl_Surveys set Name = @name, QuestionQuantity = @questionQuantity, UserName = @username where Id = @id", GetConnection());

            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@questionQuantity", item.QuestionQuantity);
            command.Parameters.AddWithValue("@username", item.UserName);
          

            return executeDml(command);
        }

        public bool validPass(string name, string password)
        {
            throw new NotImplementedException();
        }

     
    }
}
