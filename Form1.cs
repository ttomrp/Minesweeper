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
        public Form1()
        {
            InitializeComponent();
        }

        private bool gameStart = false;  //some flag that the game has started
        private int rowCount = 16;
        private int columnCount = 16;
        private Dictionary<string, Button> buttons = new Dictionary<string, Button>();

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
            // identify which button was clicked and perform necessary actions
            if (gameStart == false)
            {
                this.timer1.Enabled = true;
                gameStart = true;
            }
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    button.Image = Minesweeper.Properties.Resources.bombflag;
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
            rowCount = 8;
            columnCount = 8;
            resetGameBoard();
            buildGameBoard();
        }

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 10;
            columnCount = 10;
            resetGameBoard();
            buildGameBoard();
        }

        private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 16;
            columnCount = 16;
            resetGameBoard();
            buildGameBoard();
        }

        private void x20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 20;
            columnCount = 20;
            resetGameBoard();
            buildGameBoard();
        }

        private void resetGameBoard()
        {
            gameStart = false;
            timer1.Enabled = false;
            this.timer_textBox.Text = "000";
            this.flag_textBox.Text = "099";

            this.Controls.Clear();
            this.InitializeComponent();
            /*
            string[] abArray = new string[] { "a", "b" };
            foreach (string letter in abArray)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        var buttonName = string.Format("button_{0}{1}{2}", i, j, letter);
                        if (buttons.ContainsKey(buttonName))
                        {
                            var button = buttons[buttonName];
                            if (button.Image != null)
                            {
                                button.Image = null;
                            }
                            buttons.Remove(buttonName);
                        }
                    }
                }
            }
            buttons.Clear();
            */
        }

        private void buildGameBoard()
        {
            this.Size = new Size((rowCount * 20), (columnCount * 20) + 120);

            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.Size = new Size(rowCount * 20, columnCount * 20);
            this.tableLayoutPanel1.Dock = DockStyle.Bottom;


            for (int i = 0; i < columnCount; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
            }
            for (int i = 0; i < rowCount; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }

            buttons.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {

                    var button = new Button();
                    //button.Text = string.Format("{0}{1}", i, j);
                    string nameFormat = string.Format("button_{0}{1}a", i, j);
                    if (buttons.ContainsKey(nameFormat)) 
                    {
                        button.Name = string.Format("button_{0}{1}b", i, j);
                    }
                    else
                    {
                        button.Name = nameFormat;
                    }
                    button.Size = new Size(20, 20);
                    button.Dock = DockStyle.Fill;
                    button.Padding = new Padding(0);
                    button.Margin = new Padding(0, 0, 0, 0);
                    //button.Click += new EventHandler(button_Click);
                    button.MouseUp += new MouseEventHandler(button_MouseUp);
                    buttons.Add(button.Name, button);


                    this.tableLayoutPanel1.Controls.Add(button, j, i);
                }
            }
        }
    }
}
