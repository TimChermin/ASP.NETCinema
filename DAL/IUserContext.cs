using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserContext
    {
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        IEnumerable<IUser> GetUsers();
        void AddUser(IUser user);
        IUser GetUser(string name, string password);
        int GetUserRole(int id);
        void EditUser(IUser user);
        void DeleteUser(int id);
    }
}
