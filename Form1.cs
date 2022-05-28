using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {

        private MinesweeperGame _game;
        public Form1()
        {
            InitializeComponent();
            
        }

        private bool gameStart = false;  //some flag that the game has started
        private int gridSize = 8;
        private int cellsLeft = (8*8)-8;  //used to determine when game is won
        private Dictionary<string, Tuple<Button, Cell>> buttons = new Dictionary<string, Tuple<Button, Cell>>();
        private Dictionary<string, Button> cellsToButton= new Dictionary<string, Button>();

        private void Form1_Load(object sender, EventArgs e)
        {
            buildGameBoard();
        }

        /*
         * Event handler for a button click.  Using MouseUp event to allow for 
         * left and right click handling.
         */
        protected void button_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            var cell = buttons[button.Name].Item2;
            
            if (gameStart == false)
            {
                this.timer1.Enabled = true;
                gameStart = true;
            }
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (cell.hasBomb)
                    {
                        button.Image = Minesweeper.Properties.Resources.bombhit;
                        cell.isUncovered = true;
                        endGame(false);
                    } else 
                    {
                        switch (cell.neighboringBombs)
                        {
                            case 0:
                                searchForClearNeighbors(cell);
                                break;
                            case 1:
                                button.Image = Minesweeper.Properties.Resources.tile1;
                                cellsLeft--;
                                break;
                            case 2:
                                button.Image = Minesweeper.Properties.Resources.tile2;
                                cellsLeft--;
                                break;
                            case 3:
                                button.Image = Minesweeper.Properties.Resources.tile3;
                                cellsLeft--;
                                break;
                            case 4:
                                button.Image = Minesweeper.Properties.Resources.tile4;
                                cellsLeft--;
                                break;
                            case 5:
                                button.Image = Minesweeper.Properties.Resources.tile5;
                                cellsLeft--;
                                break;
                            case 6:
                                button.Image = Minesweeper.Properties.Resources.tile6;
                                cellsLeft--;
                                break;
                            case 7:
                                button.Image = Minesweeper.Properties.Resources.tile7;
                                cellsLeft--;
                                break;
                            case 8:
                                button.Image = Minesweeper.Properties.Resources.tile8;
                                cellsLeft--;
                                break;
                        }
                        button.Enabled = false;
                        cell.isUncovered = true;
                    }
                    break;
                case MouseButtons.Right:
                    button.Image = Minesweeper.Properties.Resources.flag;
                    int flagsLeft;
                    if (int.TryParse(flag_textBox.Text, out flagsLeft))
                    {
                        flagsLeft--;
                        this.flag_textBox.Text = flagsLeft.ToString("000");
                    }
                    break;
            }
        }

        /*
         * Event handler for reset "face" button click.  Resets the game.
         */
        private void face_button_Click(object sender, EventArgs e)
        {
            resetGameBoard();
        }

        /*
         * Event handler for timer.  Only runs when first button clicked.
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            int time;
            if (int.TryParse(timer_textBox.Text, out time))
            {
                time++;
                this.timer_textBox.Text = time.ToString("000");
            }

            if (cellsLeft == 0)
            {
                endGame(true);
            }
            
        }

        /*
         * Event handler for Menu setting change.  Updates gridSize and restarts the game.
         */
        private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 8;
            resetGameBoard();
        }

        /*
         * Event handler for Menu setting change.  Updates gridSize and restarts the game.
         */
        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 10;
            resetGameBoard();
        }

        /*
         * Event handler for Menu setting change.  Updates gridSize and restarts the game.
         */
        private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 16;
            resetGameBoard();
        }

        /*
         * Event handler for Menu setting change.  Updates gridSize and restarts the game.
         */
        private void x20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 20;
            resetGameBoard();
        }

        /*
         * Displays all the bombs on the board after the game ends.
         */
        private void displayBombs()
        {
            foreach (KeyValuePair<string, Tuple<Button, Cell>> entry in buttons)
            {
                var button = entry.Value.Item1;
                var cell = entry.Value.Item2;
                if (cell.hasBomb && !cell.isUncovered)
                {
                    button.Image = Minesweeper.Properties.Resources.bombflag;
                }
                else if (!cell.isUncovered)
                {
                    switch (cell.neighboringBombs)
                    {
                        case 0:
                            break;
                        case 1:
                            button.Image = Minesweeper.Properties.Resources.tile1;
                            break;
                        case 2:
                            button.Image = Minesweeper.Properties.Resources.tile2;
                            break;
                        case 3:
                            button.Image = Minesweeper.Properties.Resources.tile3;
                            break;
                        case 4:
                            button.Image = Minesweeper.Properties.Resources.tile4;
                            break;
                        case 5:
                            button.Image = Minesweeper.Properties.Resources.tile5;
                            break;
                        case 6:
                            button.Image = Minesweeper.Properties.Resources.tile6;
                            break;
                        case 7:
                            button.Image = Minesweeper.Properties.Resources.tile7;
                            break;
                        case 8:
                            button.Image = Minesweeper.Properties.Resources.tile8;
                            break;
                    }
                }
            }
        }

        /*
         * Method that recursively searches for neighboring cells.
         * If cell has not neighboring bombs, then it's corresponding button is disabled and
         * the cell is marked as uncovered.
         */
        private void searchForClearNeighbors(Cell cell)
        {
            if (cell.getName() == null)
            {
                return;
            }
            Button button = cellsToButton[cell.getName()];
            button.Enabled = false;
            cellsLeft--;
            
            int row = cell.getRow();
            int col = cell.getCol();
            cell.isUncovered = true;

            // check three neighbors above
            if (_game.cell[row - 1, col - 1].neighboringBombs == 0 && !_game.cell[row - 1, col - 1].isUncovered  && !_game.cell[row - 1, col - 1].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row - 1, col - 1]);
            }
            if (_game.cell[row - 1, col].neighboringBombs == 0 && !_game.cell[row - 1, col].isUncovered && !_game.cell[row - 1, col].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row - 1, col]);
            }
            if (_game.cell[row - 1, col + 1].neighboringBombs == 0 && !_game.cell[row - 1, col + 1].isUncovered && !_game.cell[row - 1, col + 1].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row - 1, col + 1]);
            }

            // check left and right neighbors
            if (_game.cell[row, col - 1].neighboringBombs == 0 && !_game.cell[row, col - 1].isUncovered && !_game.cell[row, col - 1].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row, col - 1]);
            }
            if (_game.cell[row, col + 1].neighboringBombs == 0 && !_game.cell[row, col + 1].isUncovered && !_game.cell[row, col + 1].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row, col + 1]);
            }

            // check three neighbors below
            if (_game.cell[row + 1, col - 1].neighboringBombs == 0 && !_game.cell[row + 1, col - 1].isUncovered && !_game.cell[row + 1, col - 1].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row + 1, col - 1]);
            }
            if (_game.cell[row + 1, col].neighboringBombs == 0 && !_game.cell[row + 1, col].isUncovered && !_game.cell[row + 1, col].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row + 1, col]);
            }
            if (_game.cell[row + 1, col + 1].neighboringBombs == 0 && !_game.cell[row + 1, col + 1].isUncovered && !_game.cell[row + 1, col + 1].isBorderCell)
            {
                searchForClearNeighbors(_game.cell[row + 1, col + 1]);
            }
        }

        /*
         * Starts the game by initializing MinesweeperGame class.
         */
        private void startGame()
        {
            cellsLeft = (gridSize*gridSize)-gridSize;
            _game = new MinesweeperGame(gridSize);
            _game.initializeGame();
        }

        /*
         * Ends game by disabling buttons and stopping timer.  Reset button must be pressed to
         * start new game.
         */
        private void endGame(bool didWin)
        {
            this.tableLayoutPanel1.Enabled = false;
            this.timer1.Stop();
            displayBombs();
            if (!didWin)
            {
                this.face_button.Image = Minesweeper.Properties.Resources.dead;
                MessageBox.Show("BOOM!  You lost.");
            }
            else
            {
                MessageBox.Show("Congrats!  You won!");
            }
            
        }

        /*
         * Resets game controls and calls buildGameBoard().
         */
        private void resetGameBoard()
        {
            gameStart = false;
            timer1.Enabled = false;
            this.timer_textBox.Text = "000";
            this.flag_textBox.Text = "099";

            this.Controls.Clear();
            this.InitializeComponent();
            buildGameBoard();
        }

        /*
         * Builds the windows form for the selected gameboard size.  Links the form buttons to
         * their corresponding MinesweeperGame cells.
         */
        private void buildGameBoard()
        {
            startGame();

            this.MinimumSize = new Size(260, (gridSize * 20) + 120);
            this.Size = new Size((gridSize * 20), (gridSize * 20) + 120);

            this.tableLayoutPanel1.ColumnCount = gridSize;
            this.tableLayoutPanel1.RowCount = gridSize;
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.Size = new Size(gridSize * 20, gridSize * 20);
            this.tableLayoutPanel1.Dock = DockStyle.Bottom;
            //this.tableLayoutPanel1.Anchor = AnchorStyles.Bottom;


            for (int i = 0; i < gridSize; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / gridSize));
            }
            for (int i = 0; i < gridSize; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / gridSize));
            }

            buttons.Clear();
            cellsToButton.Clear();
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var button = new Button();
                    button.Name = string.Format("button_{0}_{1}", i, j);
                    button.Size = new Size(20, 20);
                    button.MaximumSize = new Size(20, 20);
                    button.Dock = DockStyle.Fill;
                    button.Anchor = AnchorStyles.Bottom;
                    button.Padding = new Padding(0);
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.MouseUp += new MouseEventHandler(button_MouseUp);

                    // add a copy of the current game cell to the buttons array
                    // tableLayoutPanel is actual game size, but the cells array in MinesweeperGame are size+2
                    buttons.Add(button.Name, new Tuple<Button, Cell>(button, _game.cell[i + 1, j + 1]));
                    cellsToButton.Add(_game.cell[i + 1, j + 1].getName(), button);

                    this.tableLayoutPanel1.Controls.Add(button, j, i);
                }
            }

            
        }
    }
}
