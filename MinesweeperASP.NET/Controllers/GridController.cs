using Microsoft.AspNetCore.Mvc;
using MinesweeperASP.NET.Models;
using MinesweeperASP.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Controllers
{
    public class GridController : Controller
    {
        static Board board = new Board(5);
        static int gameOver;
        
        public GridController()
        {
            
        }
        public IActionResult Index()
        {
            //upon page load, create new grid and populate
            board.setupLiveNeighbors(2);
            board.calculateLiveNeighbors();
            gameOver = 0;
            return View("Index", board);
        }
/*=====================HANDLE LEFT CLICK====================*/
        public IActionResult HandleLeftClick(string cellNumber)
        {
            /// create new physics instance using our coordinates and board
            Physics physics = new Physics(board, cellNumber);
            physics.visit(board);
            ///game progress here
            int finish = physics.checkpoint(board);
            if (finish == 11)
            {
                physics.reset(board);
                finish = physics.checkpoint(board);
                return View("loser");

            }
            else if (finish == 12)
            {
                physics.reset(board);
                finish = physics.checkpoint(board);
                return View("winner");
            }
            return View("Index", board);
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

