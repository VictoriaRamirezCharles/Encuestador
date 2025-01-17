﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class UserService : IService<User>
    {
        private readonly IRepository<User> _repository;
        public UserService(SqlConnection connection)
        {
            _repository = new UserDataBaseRepository(connection);

        }
        public void Add(User item)
        {
            _repository.Add(item);
        }

        public void Delete(int index)
        {
            _repository.Delete(index);
        }

        public bool Get(string name, string username = null)
        {
           
           return _repository.Getting(username);
        }

        public bool validPassWord(string name, string password)
        {

            return _repository.validPass(name, password);
        }

        public void Update(User item)
        {
            _repository.Update(item);
        }

        public int GetId(User item)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll(string username)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllNames(string username)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllAnwers(string username)
        {
            throw new NotImplementedException();
        }
    }
}
