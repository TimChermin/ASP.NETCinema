using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL.Repository
{
    public class UserRepository : IUserContext
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public IEnumerable<IUser> GetUsers()
        {
            return _context.GetUsers();
        }

        public void AddUser(IUser user)
        {
            _context.AddUser(user);
        }

        public IUser GetUser(string name, string password)
        {
            return _context.GetUser(name, password);
        }

        public void EditUser(IUser user)
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
