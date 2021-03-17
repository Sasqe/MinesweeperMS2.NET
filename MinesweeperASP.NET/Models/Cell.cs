using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Models
{
    public class Cell
    {
        public int rowNumber { get; set; }
        public int liveNeighbors { get; set; }
        public Boolean isLive { get; set; }
        public int colNumber { get; set; }
        public Boolean isVisited { get; set; }
        public Boolean isFlagged { get; set; }

        public Cell(int RowNumber, int ColNumber)
        {
            rowNumber = RowNumber;
            colNumber = ColNumber;
            isVisited = false;
            isLive = false;
            isFlagged = false;
            liveNeighbors = 0;
        }

        public Cell()
        {
        }

    }

}
