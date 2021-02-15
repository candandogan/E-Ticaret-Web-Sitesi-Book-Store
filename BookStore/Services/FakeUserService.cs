using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class FakeUserService : IUserService
    {
        private List<User> users = new List<User>
        {
            new User{Username="candan",Name="Candan", Password="turkcell", Role=new Role {Name="Admin" } },
        };
        public User ValidUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
