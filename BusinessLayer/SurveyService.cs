using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SurveyService : IService<Survey>
    {
        private readonly IRepository<Survey> _repository;
        public SurveyService(SqlConnection connection)
        {
            _repository = new SurveyDatabaseRepository(connection);

        }
        public void Add(Survey item)
        {
            _repository.Add(item);
        }

        public void Delete(int index)
        {
            _repository.Delete(index);
        }

        public bool Get(string name, string username)
        {
            return _repository.Getting(name, username);
        }

        public DataTable GetAll(string username)
        {
            return _repository.List(username);
        }

        public DataTable GetAllAnwers(string username)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllNames(string username)
        {
            throw new NotImplementedException();
        }

        public int GetId(Survey item)
        {
           return _repository.GettingId(item);
        }

        public void Update(Survey item)
        {
            _repository.Update(item);
        }

        public bool validPassWord(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
