using System;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            var rowCount = 16;
            var columnCount = 16;

            this.Size = new Size((rowCount * 20), (columnCount * 20) + 120);

            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.Size = new Size(rowCount * 20, columnCount * 20);
            this.tableLayoutPanel1.Dock = DockStyle.Bottom;

            //this.face_button.Location.X = this.Width / 2;

            

            for (int i = 0; i < columnCount; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
            }
            for (int i = 0; i < rowCount; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {

                    var button = new Button();
                    //button.Text = string.Format("{0}{1}", i, j);
                    button.Name = string.Format("button_{0}{1}", i, j);
                    button.Size = new Size(20, 20);
                    button.Dock = DockStyle.Fill;
                    button.Padding = new Padding(0);
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Click += new EventHandler(button_Click);



                    this.tableLayoutPanel1.Controls.Add(button, j, i);
                }
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            // identify which button was clicked and perform necessary actions
            button.Image = Minesweeper.Properties.Resources.bombflag;
        }
    }
}
