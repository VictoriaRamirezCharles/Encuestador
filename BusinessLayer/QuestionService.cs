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
    public class QuestionService : IService<Question>
    {
        private readonly IRepository<Question> _repository;
        public QuestionService(SqlConnection connection)
        {
            _repository = new QuestionDatabaseRepository(connection);

        }
        public void Add(Question item)
        {
            _repository.Add(item);
        }

        public void Delete(int index)
        {
            _repository.Delete(index);
        }

        public bool Get(string suveyId, string cantidad)
        {
            return _repository.Getting(suveyId, cantidad);
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

        public int GetId(Question item)
        {
            throw new NotImplementedException();
        }

        public void Update(Question item)
        {
            _repository.Update(item);
        }

        public bool validPassWord(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
