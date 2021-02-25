using MinesweeperASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Services
{
    public class Physics
    {
        public string[] data { get; set; }
        public int rowNumber { get; set; }
        public int colNumber { get; set; }
        int breaker = 0;
//===============CONSTRUCTOR INITIALIZE ROW AND COL NUMBER============
        public Physics(Board board, string cellnumber)
        {
            data = cellnumber.Split(',');
            this.rowNumber = Convert.ToInt32(data[0]);
            this.colNumber = Convert.ToInt32(data[1]);


        }
        //===============VISIT CURRENT INDEX=================
        public void visit(Board grid)
        {
            grid.thisGame[this.rowNumber, this.colNumber].isVisited = true;
            checkpoint(grid);
        }
//==================================RESET GRID========================
        public void reset(Board grid)
        {
            foreach (Cell cell in grid.thisGame)
            {
                cell.isVisited = false;
                cell.isLive = false;
            }
        }
//========================CHECKPOINT CONTINUE/END=====================
        public int checkpoint(Board grid)
        {
              breaker = grid.IsGameOver(this.rowNumber, this.colNumber);
        
            if (breaker == 0)
            {
                grid.floodFill(this.rowNumber, this.colNumber);
                return 10;
            }
            else if (breaker == -1)
            {
                foreach (Cell cell in grid.thisGame)
                {
                    cell.isVisited = true;
                    return 11;
                }

            }
            else if (breaker == 1)
            {
                foreach (Cell cell in grid.thisGame)
                {
                    cell.isVisited = true;
                    return 12;
                }
            }
            grid.floodFill(this.rowNumber, this.colNumber);
            return 10;
        }
    }
//===============================EOF==================================
}
