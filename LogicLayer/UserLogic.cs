using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using DAL.Repository;
using DAL;
using Interfaces;
using LogicLayer;

namespace ASPNETCinema.Logic
{
    public class UserLogic
    {
        private UserRepository Repository { get; }
        

        public UserLogic(IUserContext context)
        {
            Repository = new UserRepository(context);
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        public void random()
        {
            // Hash
            var hash = SecurePasswordHasher.Hash("mypassword");

            // Verify
            var result = SecurePasswordHasher.Verify("mypassword", hash);
        }


        public IUser GetUser(string name, string password)
        {
            var users = Repository.GetUsers();
            foreach (var user in users)
            {
                if (name == user.Name && SecurePasswordHasher.Verify(password, user.Password) == true)
                {
                    return user;
                }
            }
            return null;
        }

        public bool AddUser(int id, string name, string password, string confirmPassword, int administrator)
        {
            if (password == confirmPassword && password != null)
            {
                var hash = SecurePasswordHasher.Hash(password);
                var user = new UserModel
                {
                    Id = id,
                    Name = name,
                    Password = hash,
                    Administrator = administrator
                };
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
