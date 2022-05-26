﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class MinesweeperGame
    {
        public struct cellStruct
        {
            public bool hasFlag;
            public bool hasBomb;
            public bool isUncovered;
            public int neighboringBombs;
            public int row;
            public int column;
        }

        public int boardSize;
        public int sideSize;
        public cellStruct[,] cell;

        public MinesweeperGame(int gridSize)
        {
            cell = new cellStruct[gridSize + 2, gridSize + 2];
            sideSize = gridSize;
            boardSize = gridSize * gridSize;
        }
        
        /*
         * Initializes the 2D array of cells for the game.  Sets fields in the cellstruct for
         * each cell.
         */
        public void initializeGame()
        {
            bool[] bombs = getBombs();
            int bombCounter = 0;
            for (int row = 1; row <= sideSize; row++)
            {
                for (int col = 1; col <= sideSize; col++)
                {
                    cell[row, col] = new cellStruct
                    {
                        hasFlag = false,
                        hasBomb = false,
                        isUncovered = false,
                        neighboringBombs = 0,
                        row = row,
                        column = col
                    };

                    // set hasBomb based on bombs array
                    if (bombs[bombCounter] == true)
                    {
                        cell[row, col].hasBomb = true;
                    }
                    bombCounter++;
                }
            }

            checkNeighbors();
        }

        /*
         * Creates a 1D boolean array for a given board size and randomizes 'bomb flags' in the array.
         * Returns a 1D boolean array.
         */
        public bool[] getBombs()
        {
            Random rand = new Random();
            bool[] n = new bool[boardSize];
            int emptyCells = boardSize - sideSize;
            // fill array with false values for number of non-bomb cells
            for (int i=0; i<emptyCells; i++)
            {
                n[i] = false;
            }
            // fill remaining space in array with true for number of bombs
            for (int i = emptyCells; i<boardSize; i++)
            {
                n[i] = true;
            }
            // randomly change positions of bombs in array
            for (int i=0; i<boardSize; i++)
            {
                int position = rand.Next(boardSize);
                bool save = n[i];
                n[i] = n[position];
                n[position] = save;
            }
            return n;
        }

        /*
         * Checks surrounding neighbors of a cell and counts the number of neighboring
         * cells with a bomb.  Sets cell.neighboringBombs with the total count.
         */
        public void checkNeighbors()
        {
            
            for (int row = 1; row <= sideSize; row++)
            {
                for (int col = 1; col <= sideSize; col++)
                {
                    int neighboringBombsCounter = 0;
                    // check three neighbors above
                    if (cell[row - 1, col - 1].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }
                    if (cell[row - 1, col].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }
                    if (cell[row - 1, col + 1].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }

                    // check left and right neighbors
                    if (cell[row, col - 1].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }
                    if (cell[row, col + 1].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }

                    // check three neighbors below
                    if (cell[row + 1, col - 1].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }
                    if (cell[row + 1, col].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }
                    if (cell[row + 1, col + 1].hasBomb)
                    {
                        neighboringBombsCounter++;
                    }

                    cell[row, col].neighboringBombs = neighboringBombsCounter;
                }
            }
        }
    }
}
