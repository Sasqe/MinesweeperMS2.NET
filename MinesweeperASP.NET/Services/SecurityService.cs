using MinesweeperASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Services
{
    public class SecurityService
    {
        UsersDAO usersDAO = new UsersDAO();

        public userModel IsLoginValid(userModel user)
        {
            // return true if found in the list
            return usersDAO.FindUserByNameAndPassword(user);
        }

        /*public bool AddAccountToDatabase(userModel user)
        {
            // If true send user details to the database
            return usersDAO.AddAccountToDatabase(user);
        }*/
    }
}
