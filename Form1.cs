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
        // TODO: connect functionality between Form and MinesweeperGame
        // TODO: add unit tests

        private MinesweeperGame _game;
        public Form1()
        {
            InitializeComponent();
            
        }

        private bool gameStart = false;  //some flag that the game has started
        private int gridSize = 8;
        private Dictionary<string, Tuple<Button, MinesweeperGame.cellStruct>> buttons = new Dictionary<string, Tuple<Button, MinesweeperGame.cellStruct>>();

        private void Form1_Load(object sender, EventArgs e)
        {
            buildGameBoard();
        }

        /*protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            // identify which button was clicked and perform necessary actions
            button.Image = Minesweeper.Properties.Resources.bombflag;
        }
        */

        protected void button_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            var cell = buttons[button.Name].Item2;
            // identify which button was clicked and perform necessary actions
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
                        endGame();
                    } else if (cell.neighboringBombs > 0)
                    {
                        
                    }
                    button.Enabled = false;
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

        private void face_button_Click(object sender, EventArgs e)
        {
            resetGameBoard();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int time;
            if (int.TryParse(timer_textBox.Text, out time))
            {
                time++;
                this.timer_textBox.Text = time.ToString("000");
            }
            
        }

        private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 8;
            resetGameBoard();
        }

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 10;
            resetGameBoard();
        }

        private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 16;
            resetGameBoard();
        }

        private void x20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridSize = 20;
            resetGameBoard();
        }

        private void startGame()
        {
            _game = new MinesweeperGame(gridSize);
            _game.initializeGame();
        }

        private void endGame()
        {
            this.tableLayoutPanel1.Enabled = false;
            this.face_button.Image = Minesweeper.Properties.Resources.dead;
            this.timer1.Stop();
            MessageBox.Show("BOOM!  You lost.");
        }

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
                    //button.Click += new EventHandler(button_Click);
                    button.MouseUp += new MouseEventHandler(button_MouseUp);

                    // couple gameCell to button.
                    // tableLayoutPanel is actual game size, but the cells array in MinesweeperGame are size+2
                    var gameCell = _game.cell[i + 1, j + 1];
                    buttons.Add(button.Name, new Tuple<Button, MinesweeperGame.cellStruct>(button,gameCell));


                    this.tableLayoutPanel1.Controls.Add(button, j, i);
                }
            }

            
        }
    }
}
