using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using DAL.Repository;
using DAL;
using LogicLayer;
using LogicLayer.Interfaces;
using AutoMapper;

namespace ASPNETCinema.Logic
{
    public class UserLogic : IUserLogic
    {
        private UserRepository Repository { get; }
        private IMapper _mapper;

        public UserLogic(IUserContext context, IMapper mapper)
        {
            Repository = new UserRepository(context);
            _mapper = mapper;
        }

        public UserModel GetUser(string name, string password)
        {
            var users = Repository.GetUsers();
            foreach (var user in users)
            {
                if (name == user.Name && SecurePasswordHasher.Verify(password, user.Password) == true)
                {
                    return _mapper.Map<UserModel>(user);
                }
            }
            return null;
        }

        public bool AddUser(UserModel user)
        {
            if (user.Password == user.ConfirmPassword && user.Password != null)
            {
                var hash = SecurePasswordHasher.Hash(user.Password);
                Repository.AddUser(user);
                return true;
            }
            return false;
        }

        public bool CheckIfThisLoginIsCorrect(string name, string password)
        {
            var users = Repository.GetUsers();
            foreach (var user in users)
            {
                if (name == user.Name && SecurePasswordHasher.Verify(password, user.Password) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetRoleUser(int id)
        {
            if (Repository.GetUserRole(id) == 1)
            {
                return "Administrator";
            }
            else if (Repository.GetUserRole(id) == 2)
            {
                return "Employee";
            }
            
            return "Normal";
        }
    }
}
