using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Cell
    {
        private string name;
        private int row;
        private int col;
        public bool isUncovered { get; set; }
        public bool hasBomb { get; set; }
        public int neighboringBombs { get; set; }
        public bool isBorderCell { get; set; }


        public Cell (int gridRow, int gridCol)
        {
            row = gridRow;
            col = gridCol;
            name = string.Format("cell_{0}_{1}", row, col);
            hasBomb = false;
            isUncovered = false;
            neighboringBombs = 0;
            isBorderCell = false;
        }

        public int getRow()
        {
            return this.row;
        }

        public int getCol()
        {
            return this.col;
        }

        public string getName()
        {
            return this.name;
        }
    }
}
