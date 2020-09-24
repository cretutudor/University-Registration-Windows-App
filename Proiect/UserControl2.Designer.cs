namespace Proiect
{
    partial class UserControl2
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.facultateaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salveazăToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 55);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1455, 632);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr. crt.";
            this.columnHeader1.Width = 73;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nume";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 33;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Prenume";
            this.columnHeader4.Width = 119;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Facultatea";
            this.columnHeader5.Width = 461;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Specializarea";
            this.columnHeader6.Width = 215;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Media";
            this.columnHeader7.Width = 91;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Navy;
            this.menuStrip1.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facultateaToolStripMenuItem,
            this.generalToolStripMenuItem,
            this.salveazăToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1455, 53);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // facultateaToolStripMenuItem
            // 
            this.facultateaToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facultateaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.facultateaToolStripMenuItem.Name = "facultateaToolStripMenuItem";
            this.facultateaToolStripMenuItem.Size = new System.Drawing.Size(118, 49);
            this.facultateaToolStripMenuItem.Text = "Facultate";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(106, 49);
            this.generalToolStripMenuItem.Text = "General";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // salveazăToolStripMenuItem
            // 
            this.salveazăToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salveazăToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.salveazăToolStripMenuItem.Name = "salveazăToolStripMenuItem";
            this.salveazăToolStripMenuItem.Size = new System.Drawing.Size(117, 49);
            this.salveazăToolStripMenuItem.Text = "Salvează";
            this.salveazăToolStripMenuItem.Click += new System.EventHandler(this.salveazăToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(122, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 53);
            this.panel3.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(237, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 53);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 53);
            this.panel2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel4.Location = new System.Drawing.Point(354, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 53);
            this.panel4.TabIndex = 12;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1455, 687);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem facultateaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem salveazăToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
    }
}
