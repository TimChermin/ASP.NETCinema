using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IUserLogic
    {
        bool AddUser(UserModel user);
        UserModel GetUser(string name, string password);
        bool CheckIfThisLoginIsCorrect(string name, string password);
        string GetRoleUser(int id);
        bool DoesThisUserExist(string name);
    }
}
