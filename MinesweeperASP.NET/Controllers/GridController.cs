﻿using Microsoft.AspNetCore.Mvc;
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
        static Board board = new Board(10);
        static int gameOver;
        
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
            Physics physics = new Physics(cellNumber);
            ///game progress here
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
            return View("Index", board);
        }
        public IActionResult ShowOneButton(string cellNumber)
        {
            Physics physics = new Physics(cellNumber);
            int row = physics.rowNumber;
            int col = physics.colNumber;
            //physics.flag(board);
            return PartialView(board.thisGame[row,col]);
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
