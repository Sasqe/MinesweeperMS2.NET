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
        
//===============CONSTRUCTOR INITIALIZE ROW AND COL NUMBER============
        public Physics(string cellnumber)
        {
            data = cellnumber.Split(',');
            this.rowNumber = Convert.ToInt32(data[0]);
            this.colNumber = Convert.ToInt32(data[1]);


        }
       
        //===============VISIT CURRENT INDEX=================
        public int visit(Board grid)
        {
            Cell cell = grid.thisGame[this.rowNumber, this.colNumber];
            if (!cell.isFlagged)
            {
                cell.isVisited = true;
                if (this.checkpoint(grid) == 10)
                {
                    return 10;
                }
                else if(this.checkpoint(grid) == 11)
                {
                    return 11;
                }
                else
                {
                    return 12;
                }
                
            }
            return -1;
        }
    
//==================================RESET GRID========================
        public Board reset(int dif)
        {
            Board temp = new Board(dif);
            

            return temp;
        }
//========================CHECKPOINT CONTINUE/END=====================
        public int checkpoint(Board grid)
        {
            
            int breaker = grid.IsGameOver(this.rowNumber, this.colNumber);
        
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
            
            return 10;
        }
    }
//===============================EOF==================================
}
