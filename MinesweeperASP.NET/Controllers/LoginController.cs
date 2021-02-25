using Microsoft.AspNetCore.Mvc;
using MinesweeperASP.NET.Models;
using MinesweeperASP.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Controllers
{
    public class LoginController : Controller
    {
        SecurityService securityService = new SecurityService();
        public IActionResult Index()
        {
            return View();
        }

        //Two Parameters --> Success page & user data from login form
        public IActionResult ProcessLogin(userModel user)
        {
            
            if (securityService.IsLoginValid(user))
            {
                return View("LoginSuccess", user);  
            }
            else
            {
                return View("LoginFailure", user);  
            }                       
        }

    }
}
