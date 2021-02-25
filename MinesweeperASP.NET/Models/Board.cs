using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Models
{
    public class Board
    {
        //Board and board logic  created by Chris King with collaboration with Kayla and Max.
        //12/18/2020
        //CST-227
        public int tick = 1;
        public int fieldDifficulty { get; set; }
        public int Size { get; set; }
        //Creating the array
        public Cell[,] thisGame;

        //creating minefield
        public Board(int size)
        {
            Size = size;
            //provides player ability to choose grid size
            thisGame = new Cell[size, size];
            //give grid cells
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    thisGame[i, j] = new Cell(i,j);
                }
            }
           
        }
        public int IsGameOver(int row, int column)
        {
            if (thisGame[row, column].isVisited && thisGame[row, column].isLive)
            {

                return -1;
            }
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (!thisGame[i, j].isVisited && !thisGame[i, j].isLive)
                    {
                        
                        Console.WriteLine("Keep going!");
                        return 0;
                    }
                }
            }
            
            Console.WriteLine("\tYou win!");
            return 1;
        }



        public void calculateLiveNeighbors()
        {
            //Code to check the 8 neighbors around a given starting cell, written by Chris King with collaboration with Kayla and Max among others

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    // checks if current cell  is live
                    if (thisGame[i, j].isLive)
                    {
                        thisGame[i, j].liveNeighbors = 9;
                    }
                    //checks the live neighbors of the cell

                    else
                    {
                        if (i < Size - 1 && thisGame[i + 1, j].isLive) // done
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                        if (j < Size - 1 && thisGame[i, j + 1].isLive) // done
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                        if (i < Size - 1 && j < Size - 1 && thisGame[i + 1, j + 1].isLive) //done
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                        if (i > 0 && thisGame[i - 1, j].isLive) //done
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                        if (j > 0 && thisGame[i, j - 1].isLive) //done
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                        if (i > 0 && j > 0 && thisGame[i - 1, j - 1].isLive) //done
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                        if (i < Size - 1 && j > 0 && thisGame[i + 1, j - 1].isLive) //done
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                        if (i > 0 && j < Size - 1 && thisGame[i - 1, j + 1].isLive)
                        {
                            thisGame[i, j].liveNeighbors++;
                        }
                    }
                }
            }

        }
        public void setupLiveNeighbors(int difficulty)
        {
            //using random integer for difficulty
            Random random = new Random();
            //initializing difficulty
            fieldDifficulty = difficulty;
            foreach (var cell in thisGame)
            {
                int randint = random.Next(1, difficulty * 10);
                if (randint <= difficulty)
                {
                    cell.isLive = true;
                }
            }
        }


        public void floodFill(int row, int col)
        {
            //FOR EACH CHECK IN ALL 8 DIRECTIONS,
            //this is how it goes
            //each statement is in a try catch to keep it where I want it, if the starting position is in a valid position on the board, if the starting position's live neighbors are 0, and if the cell in the direction its checking 
            //is not visited yet, it will visit that cell, and then repeat the process in said direction until it no longer can.
            //I wrote these myself, through my own understanding of the flood fill algorithm in itself, however the algorithm was worked on by me in collaboration with Max and Kayla, as well as some other students.
            try
            {
                if (row < Size && thisGame[row, col].liveNeighbors == 0 && thisGame[row + 1, col].isVisited == false)
                {
                    thisGame[row + 1, col].isVisited = true;
                    floodFill(row + 1, col);
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            try
            {
                if (col < Size && thisGame[row, col].liveNeighbors == 0 && thisGame[row, col + 1].isVisited == false)
                {
                    thisGame[row, col + 1].isVisited = true;
                    floodFill(row, col + 1);
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            try
            {
                if (row < Size && col < Size && thisGame[row, col].liveNeighbors == 0 && thisGame[row + 1, col + 1].isVisited == false)
                {
                    thisGame[row + 1, col + 1].isVisited = true;
                    floodFill(row + 1, col + 1);
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            try
            {
                if (row > 0 && thisGame[row, col].liveNeighbors == 0 && thisGame[row - 1, col].isVisited == false)
                {
                    thisGame[row - 1, col].isVisited = true;
                    floodFill(row - 1, col);
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            try
            {
                if (col > 0 && thisGame[row, col].liveNeighbors == 0 && thisGame[row, col - 1].isVisited == false)
                {
                    thisGame[row, col - 1].isVisited = true;
                    floodFill(row, col - 1);
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            try
            {
                if (row > 0 && col > 0 && thisGame[row, col].liveNeighbors == 0 && thisGame[row - 1, col - 1].isVisited == false)
                {
                    thisGame[row - 1, col - 1].isVisited = true;
                    floodFill(row - 1, col - 1);
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            try
            {
                if (row < Size - 1 && col > 0 && thisGame[row, col].liveNeighbors == 0 && thisGame[row + 1, col - 1].isVisited == false)
                {
                    thisGame[row + 1, col - 1].isVisited = true;
                    floodFill(row + 1, col - 1);
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
            try
            {
                if (row > 0 && col < Size - 1 && thisGame[row, col].liveNeighbors == 0 && thisGame[row - 1, col + 1].isVisited == false)
                {
                    thisGame[row - 1, col + 1].isVisited = true;
                    floodFill(row - 1, col + 1);
                }
            }
            catch (System.IndexOutOfRangeException)
            {
            }
        }

    }
}
