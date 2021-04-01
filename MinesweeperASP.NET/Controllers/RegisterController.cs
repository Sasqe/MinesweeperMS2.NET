using Microsoft.AspNetCore.Mvc;
using MinesweeperASP.NET.Models;
using MinesweeperASP.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Controllers
{
    public class RegisterController : Controller
    {
        UsersDAO usersDAO = new UsersDAO();
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessRegister(userModel user)
        {
            bool success = usersDAO.AddAccountToDatabase(user);

            // Check to see if either the Username or password feild was left empty
            if (success == true)       //if (user.UserName != null && user.Password != null)
            {

                return View("Login");
            }
            else
            {
                return View("Register", user);
            }
        }
    }
}
