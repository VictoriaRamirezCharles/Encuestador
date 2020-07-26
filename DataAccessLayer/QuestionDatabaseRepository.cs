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
    public class QuestionDatabaseRepository : BaseRepository, IRepository<Question>
    {
        public QuestionDatabaseRepository(SqlConnection connection) : base(connection)
        {
        }
        public bool Add(Question item)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_Questions(Question,SurveyId) values(@question,@surveyId)", GetConnection());

            command.Parameters.AddWithValue("@question", item.Name);
            command.Parameters.AddWithValue("@surveyId", item.SurveyId);
        

            return executeDml(command);
        }

        public bool Delete(int id)
        {
            SqlCommand command = new SqlCommand("delete Tbl_Questions where id = @id", GetConnection());

            command.Parameters.AddWithValue("@id", id);


            return executeDml(command);
        }

        public bool Getting(string suveyId, string cantidad)
        {
            string command = string.Format("SELECT count(Question) as quantity FROM Tbl_Questions WHERE SurveyId='{0}'", Convert.ToInt32(suveyId));
            DataSet ds = Get(command);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int quantity = Convert.ToInt32(ds.Tables[0].Rows[0]?["quantity"]);
                if (quantity== Convert.ToInt32(cantidad))
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

        public int GettingId(Question item)
        {
            throw new NotImplementedException();
        }

        public DataTable List(string surveyId)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("select * from Tbl_Questions where SurveyId='{0}'", Convert.ToInt32(surveyId)), GetConnection());

            return LoadData(sqlDataAdapter);
        }

        public bool Update(Question item)
        {
            SqlCommand command = new SqlCommand("update Tbl_Questions set Question = @question, SurveyId = @surveyId where Id = @id", GetConnection());

            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@question", item.Name);
            command.Parameters.AddWithValue("@surveyId", item.SurveyId);

            return executeDml(command);
        }

        public bool validPass(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
