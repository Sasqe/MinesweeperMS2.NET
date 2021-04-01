using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MinesweeperASP.NET.Models;
using MinesweeperASP.NET.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Controllers
{
    
    public class DataController : Controller
    {
        DataService ds = new DataService();
        public Board board { get; set; }
        public DataController()
        {
           
        }
        public IActionResult Index()
        {
            int userID = (int)HttpContext.Session.GetInt32("userID");

            List<gridDTO> games = ds.retrieveData(userID);
          return View("Games", games);
        }
   
       

       

    }


    /*=====================EOF==================================*/
}













/*================================NOTES=======================
 * -------------------------LOGIC---------------------------/*
            if (gameOver == 0)
            {
                board.floodFill(rowNumber, colNumber);
            }
            else if (gameOver == -1)
            {
                foreach (Cell cell in board.thisGame)
                {
                    cell.isVisited = true;
                    return View("loser");
                }
               
            }
            else if (gameOver == 1)
            {
                foreach (Cell cell in board.thisGame)
                {
                    cell.isVisited = true;
                    return View("winner");
                }
            }
 ---------------------INDEX GRABBING--------------------------
   /*
            string[] data = cellNumber.Split(',');
            int rowNumber = Convert.ToInt32(data[0]);
            int colNumber = Convert.ToInt32(data[1]);
             board.thisGame[rowNumber, colNumber].isVisited = true; 
            board.thisGame[rowNumber, colNumber].isVisited = true;
            */

