﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SurveyedDatabaseRepository : BaseRepository, IRepository<Surveyed>
    {
        public SurveyedDatabaseRepository(SqlConnection connection) : base(connection)
        {
        }
        public bool Add(Surveyed item)
        {
            SqlCommand command = new SqlCommand("insert into Tbl_surveyed(QuestionId,Name,Username,Answer,SurveyId) values(@questionId,@name,@username,@answer,@surveyId)", GetConnection());

            command.Parameters.AddWithValue("@questionId", item.QuestionId);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@username", item.UserName);
            command.Parameters.AddWithValue("@answer", item.Answer);
            command.Parameters.AddWithValue("@surveyId", item.SurveyId);

            return executeDml(command);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllAnwers(string name)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("select QuestionId, Answer from Tbl_surveyed where Name='{0}'", name), GetConnection());

            return LoadData(sqlDataAdapter);
        }

        public DataTable GetAllNames(string SurveyId)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("select distinct Name from Tbl_surveyed where SurveyId='{0}'", Convert.ToInt32(SurveyId)), GetConnection());

            return LoadData(sqlDataAdapter);
        }

        public bool Getting(string name, string username = null)
        {
            throw new NotImplementedException();
        }

        public int GettingId(Surveyed item)
        {
            throw new NotImplementedException();
        }

        public DataTable List(string SurveyId)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("select * from Tbl_Questions where SurveyId='{0}'", Convert.ToInt32(SurveyId)), GetConnection());

            return LoadData(sqlDataAdapter);
        }

        public bool Update(Surveyed item)
        {
            throw new NotImplementedException();
        }

        public bool validPass(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
