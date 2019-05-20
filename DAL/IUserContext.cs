using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserContext
    {
        List<UserDto> GetUsers();
        void AddUser(UserModel user);
        UserDto GetUser(string name, string password);
        int GetUserRole(int id);
        void EditUser(UserModel user);
        void DeleteUser(int id);
        UserDto DoesThisUserExist(string name);
    }
}
