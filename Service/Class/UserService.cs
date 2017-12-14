﻿using Data.Dapper.Interface;
using Model;
using Service.Interface;
using System.Collections.Generic;

namespace Service.Class
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUserList()
        {
            var obj = new List<User>();
            return obj;
        }

        public User GetToken(string username, string password)
        {
            var passwordCrypt = Utils.RijndaelManagedEncryption.EncryptRijndael(password);

            var ret = _userRepository.ValidateUser(username, passwordCrypt);

            if (ret != null)
            {
                ret.Token = Utils.JwtManager.GenerateToken(username);
            }
            return ret;
        }

        public void InsertUser(string username, string password)
        {
            var passwordCrypt = Utils.RijndaelManagedEncryption.EncryptRijndael(password);

            _userRepository.InsertUser(username, passwordCrypt);
        }

        public bool ClearFullCache()
        {
            return true;
        }
    }
}