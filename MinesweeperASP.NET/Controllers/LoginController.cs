using Microsoft.AspNetCore.Http;
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
            return View("Login");
        }

        //Two Parameters --> Success page & user data from login form
        public IActionResult ProcessLogin(userModel user)
        {
            
            if (securityService.IsLoginValid(user) != null)
            {
                userModel m = securityService.IsLoginValid(user);
                HttpContext.Session.SetInt32("userID", m.ID);
                var red =(int)HttpContext.Session.GetInt32("userID");
                return View("LoginSuccess", user);  
            }
            else
            {
                return View("Login");  
            }                       
        }
        public IActionResult home()
        {
            return View("LoginSuccess");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
