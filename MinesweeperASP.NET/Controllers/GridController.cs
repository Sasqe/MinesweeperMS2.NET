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
    public class GridController : Controller
    {
        
        static public Board board = new Board(10);
        static int gameOver;
        DataService ds = new DataService();
        
        public GridController()
        {
            
        }
        public IActionResult Index()
        {
            //upon page load, create new grid and populate

           
            gameOver = 0;
            return View("Index", board);
        }
/*=====================HANDLE LEFT CLICK====================*/
        public IActionResult HandleLeftClick(string cellNumber)
        {
            /// create new physics instance using our coordinates and board
            /// create current cell
            Physics physics = new Physics(cellNumber);
            Cell cell = board.thisGame[physics.rowNumber, physics.colNumber];
            ///game progress here
            if (cell.isVisited == false)
            {
                if (physics.visit(board) == 11 && physics.visit(board) != -1)
                {
                    board = physics.reset(10);

                    return View("loser");

                }
                else if (physics.visit(board) == 12 && physics.visit(board) != -1)
                {
                    board = physics.reset(10);

                    return View("winner");
                }
            }
            return View("Index", board);
        }
        public IActionResult flag(string cellNumber)
        {
            Physics physics = new Physics(cellNumber);
           
            int row = physics.rowNumber;
            int col = physics.colNumber;
         
            physics.flag(board);
            /* return Json(new { part1 = buttonHTMLString });
             */
            return PartialView(board.thisGame[row, col]);
        }

        public IActionResult Save()
        {
           
            gridDTO dto = new gridDTO(1, JsonConvert.SerializeObject(board), DateTime.Now, 1);

            bool success = ds.Save(dto);
            return View("Index", board);
        }
        public IActionResult LoadDelete(int id, string action)
        {
            List<gridDTO> games = ds.retrieveData();
            //select board from database and return grid view
            if (action == "Load")
            {
                gridDTO dto = ds.Load();
                board = JsonConvert.DeserializeObject<Board>(dto.JSONString);

                return View("Index", board);
            }
            // select board from database to delete and return gridlist view
            else if (action == "Delete")
            {
                /* bool success = ds.delete(id);*/
               // ds.delete(id);
                games = ds.retrieveData();
                return View("Games", games);
            }
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

