using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class UserRepository : IUserContext
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public List<UserDto> GetUsers()
        {
            return _context.GetUsers();
        }

        public void AddUser(UserModel user)
        {
            _context.AddUser(user);
        }

        public UserDto GetUser(string name, string password)
        {
            return _context.GetUser(name, password);
        }

        public void EditUser(UserModel user)
        {
            _context.EditUser(user);
        }

        public void DeleteUser(int id)
        {
            _context.DeleteUser(id);
        }

        public int GetUserRole(int id)
        {
            return _context.GetUserRole(id);
        }
    }
}
