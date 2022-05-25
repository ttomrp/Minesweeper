
namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.face_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flag_textBox = new System.Windows.Forms.TextBox();
            this.timer_textBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 239);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // face_button
            // 
            this.face_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.face_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.face_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.face_button.FlatAppearance.BorderSize = 3;
            this.face_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.face_button.Image = global::Minesweeper.Properties.Resources.smiley;
            this.face_button.Location = new System.Drawing.Point(113, 27);
            this.face_button.Name = "face_button";
            this.face_button.Size = new System.Drawing.Size(50, 50);
            this.face_button.TabIndex = 2;
            this.face_button.UseVisualStyleBackColor = true;
            this.face_button.Click += new System.EventHandler(this.face_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(276, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // flag_textBox
            // 
            this.flag_textBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.flag_textBox.ForeColor = System.Drawing.Color.Black;
            this.flag_textBox.Location = new System.Drawing.Point(12, 27);
            this.flag_textBox.Name = "flag_textBox";
            this.flag_textBox.ReadOnly = true;
            this.flag_textBox.Size = new System.Drawing.Size(80, 50);
            this.flag_textBox.TabIndex = 4;
            this.flag_textBox.Text = "099";
            this.flag_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer_textBox
            // 
            this.timer_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timer_textBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timer_textBox.ForeColor = System.Drawing.Color.Black;
            this.timer_textBox.Location = new System.Drawing.Point(184, 27);
            this.timer_textBox.Name = "timer_textBox";
            this.timer_textBox.ReadOnly = true;
            this.timer_textBox.Size = new System.Drawing.Size(80, 50);
            this.timer_textBox.TabIndex = 5;
            this.timer_textBox.Text = "000";
            this.timer_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 331);
            this.Controls.Add(this.timer_textBox);
            this.Controls.Add(this.flag_textBox);
            this.Controls.Add(this.face_button);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Tom\'s Minesweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button face_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.TextBox flag_textBox;
        private System.Windows.Forms.TextBox timer_textBox;
        private System.Windows.Forms.Timer timer1;
    }
}

