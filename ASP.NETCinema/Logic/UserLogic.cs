using ASPNETCinema.Data;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ASPNETCinema.Logic
{
    public class UserLogic
    {
        DatabaseUser databaseUser = new DatabaseUser();
        UserModel user = new UserModel();

        public bool CheckIfThisLoginIsCorrect(string name, string password)
        {
            List<UserModel> users = databaseUser.GetUsers();
            foreach (UserModel user in users)
            {
                if (name == user.Name && password == user.Password)
                {
                    
                    return true;
                }
            }
            return false;
        }

        public bool IsThisUserAnAdmin(UserModel user)
        {
            return true;
        }
    }
}
