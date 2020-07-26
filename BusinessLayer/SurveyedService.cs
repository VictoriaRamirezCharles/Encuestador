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
    public class SurveyedService : IService<Surveyed>
    {
        private readonly IRepository<Surveyed> _repository;
        public SurveyedService(SqlConnection connection)
        {
            _repository = new SurveyedDatabaseRepository(connection);

        }
        public void Add(Surveyed item)
        {
            _repository.Add(item);
        }

        public void Delete(int index)
        {
            _repository.Delete(index);
        }

        public bool Get(string name, string username = null)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll(string username)
        {
            return _repository.List(username);
        }

        public DataTable GetAllAnwers(string username)
        {
            return _repository.GetAllAnwers(username);
        }

        public DataTable GetAllNames(string username)
        {
            return _repository.GetAllNames(username);
        }

        public int GetId(Surveyed item)
        {
            throw new NotImplementedException();
        }

        public void Update(Surveyed item)
        {
            _repository.Update(item);
        }

        public bool validPassWord(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
