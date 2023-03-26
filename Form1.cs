using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTablePanelOnLoad(tableLayoutPanel1);
            AddBasicLevelOutline(tableLayoutPanel1);
            
        }

        private void FillTablePanelOnLoad(TableLayoutPanel tablePanel)
        {
            this.UseWaitCursor = true; //this == Form

            tablePanel.Enabled = false;
            tablePanel.Padding = new Padding(0);
            tablePanel.Margin = new Padding(0);
            tablePanel.SuspendLayout();

            PictureBox[] pictureBoxArr = new PictureBox[64 * 64];
            for (int i = 0; i < pictureBoxArr.Length; i++)
            {
                pictureBoxArr[i] = new PictureBox();
                //pictureBoxArr[i].Size = new Size(30, 30);
                pictureBoxArr[i].BackColor = Color.FromArgb(128, 128, 0);
                pictureBoxArr[i].Margin = new Padding(0);
                pictureBoxArr[i].Padding = new Padding(0);

                pictureBoxArr[i].MouseMove += TablePictureBox_MouseMove;

                tablePanel.Controls.Add(pictureBoxArr[i]);
            }
            tablePanel.ResumeLayout(true);
            tablePanel.Enabled = true;

            this.UseWaitCursor = false; //this == Form
        }

        private void AddBasicLevelOutline(TableLayoutPanel tablePanel)
        {
            tablePanel.Enabled = false;
            tablePanel.SuspendLayout();
            for (int i = 0; i < tablePanel.RowCount; i++) {
                if (i != 0 && i != tablePanel.RowCount - 1){
                    (tablePanel.GetControlFromPosition(0, i) as PictureBox).BackColor = Color.Blue;
                    (tablePanel.GetControlFromPosition(0, i) as PictureBox).MouseMove -= TablePictureBox_MouseMove;
                    (tablePanel.GetControlFromPosition(tablePanel.ColumnCount - 1, i) as PictureBox).BackColor = Color.Blue;
                    (tablePanel.GetControlFromPosition(tablePanel.ColumnCount - 1, i) as PictureBox).MouseMove -= TablePictureBox_MouseMove;
                    continue;
                }
                
                for (int j = 0; j < tablePanel.ColumnCount; j++) {
                    (tablePanel.GetControlFromPosition(j, i) as PictureBox).BackColor = Color.Blue;
                    (tablePanel.GetControlFromPosition(j, i) as PictureBox).MouseMove -= TablePictureBox_MouseMove;
                }
            }
            tablePanel.ResumeLayout(true); 
            tablePanel.Enabled = true;
        }

        private void TablePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            if (e.Button != MouseButtons.None)
            {
                //MouseMove radi "Capture" nad misem ako se klikne taster.
                //Kako bi se bojilo po drugim poljima, mora da se uradi "un-Capture"
                if (pictureBox.Capture)
                    pictureBox.Capture = false;
                
                pictureBox.BackColor = Color.Black;
            }
        }
    }
}
