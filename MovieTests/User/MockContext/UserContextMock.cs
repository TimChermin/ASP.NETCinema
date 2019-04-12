using DAL;
using Interfaces;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.User.Dtos;

namespace UnitTests.User.MockContext
{
    class UserContextMock : IUserContext
    {
        List<IUser> users = new List<IUser>();
        List<IUser> usersAdded = new List<IUser>();
        int delete = 0;
        int edit = 0;
        string editName = "";
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public IEnumerable<IUser> GetUsers()
        {
            users.Clear();
            users.Add(new UserDto
            {
                Id = 1,
                Name = "Normal",
                Password = SecurePasswordHasher.Hash("IdOne"),
                Administrator = 0
            });

            users.Add(new UserDto
            {
                Id = 5,
                Name = "Employee",
                Password = SecurePasswordHasher.Hash("IdFive"),
                Administrator = 2
            });

            users.Add(new UserDto
            {
                Id = 2,
                Name = "NormalTwo",
                Password = SecurePasswordHasher.Hash("IdTwo"),
                Administrator = 0
            });

            users.Add(new UserDto
            {
                Id = 3,
                Name = "Admin",
                Password = SecurePasswordHasher.Hash("IdThree"),
                Administrator = 1
            });

            foreach (var user in usersAdded)
            {
                users.Add(user);
            }
            /*
             * later use 
            if (delete != 0)
            {
                foreach (var user in users)
                {
                    if (user.Id == delete)
                    {
                        users.Remove(user);
                        break;
                    }
                }
            }
            

            if (edit != 0)
            {
                foreach (var user in users)
                {
                    if (user.Id == edit && editName != "")
                    {
                        users[0].Name = editName;
                        break;
                    }
                }
            }
            */
            return users;
        }


        public void AddUser(IUser user)
        {
            usersAdded.Add(new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Administrator = user.Administrator
            });
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(string name, string password)
        {
            foreach (var user in users)
            {
                if (user.Name == name && SecurePasswordHasher.Verify(password, user.Password) == true)
                {
                    return user;
                }
            }
            return null;
        }

        public int GetUserRole(int id)
        {
            foreach (var user in usersAdded)
            {
                if (user.Id == id)
                {
                    return user.Administrator;
                }
            }
            return -1;
        }

        
    }
}
