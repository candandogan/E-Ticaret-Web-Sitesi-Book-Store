using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public static class MessageUsers
    {
        public static List<UserResponse> MessageOfUsers = new List<UserResponse>();

        public static void Add(UserResponse userResponse)
        {
            MessageOfUsers.Add(userResponse);
        }
    }
}
