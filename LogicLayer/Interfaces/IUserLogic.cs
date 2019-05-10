using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IUserLogic
    {
        bool AddUser(int id, string name, string password, string confirmPassword, int administrator);
        IUser GetUser(string name, string password);
        bool CheckIfThisLoginIsCorrect(string name, string password);
        string GetRoleUser(int id);
    }
}
