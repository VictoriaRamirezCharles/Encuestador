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
            throw new NotImplementedException();
        }

        public bool Getting(string name)
        {
            throw new NotImplementedException();
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
        public bool Update(Survey item)
        {
            throw new NotImplementedException();
        }

        public bool validPass(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
