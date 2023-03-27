using LevelEditor.Properties;
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
using System.Windows.Forms.Design;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        //Image[] editorImages
        List<Image> editorImages = new List<Image>{Resources.ArchwaySingle, Resources.ArchwaySmall,
        Resources.ArmorBlink, Resources.Bullets, Resources.Imp, Resources.Cobweb_Wall,
        Resources.DoorGate, Resources.EnergyBall, Resources.ExitDoor, Resources.Key,
        Resources.ShotgunAmmo,Resources.SmallMedkit, Resources.Stone, Resources.Torch,
        Resources.Tri_horn, Resources.wallBrick};


        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //typeof(TableLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(tableLayoutPanel1, true, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FillTablePanelOnLoad(tableLayoutPanel1);
            AddBasicLevelOutline(tableLayoutPanel1);
            AddPenChoiceButtonEvents(gameObjectsFlowLayoutPanel);
        }
        private bool resizingTable = false;
        

        private void AddPenChoiceButtonEvents(FlowLayoutPanel flowPanel)
        {
            for(int i = 0; i < flowPanel.Controls.Count; i++)
            {
                (flowPanel.Controls[i] as Button).Click += PenChoice_Click;
            }
        }

        private void PenChoice_Click(object sender, EventArgs e)
        {
            currentPenImage = (sender as Button).BackgroundImage;
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
                pictureBoxArr[i].SizeMode = PictureBoxSizeMode.StretchImage;
                //pictureBoxArr[i].Size = new Size(30, 30);
                pictureBoxArr[i].BackColor = Color.Black;//Color.FromArgb(128, 128, 0);
                pictureBoxArr[i].Margin = new Padding(0);
                pictureBoxArr[i].Padding = new Padding(0);

                pictureBoxArr[i].MouseMove += DrawOnMap;//TablePictureBox_MouseMove;
                pictureBoxArr[i].MouseDown += DrawOnMap;

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
                    (tablePanel.GetControlFromPosition(0, i) as PictureBox).Image = Resources.wallBrick;
                    (tablePanel.GetControlFromPosition(0, i) as PictureBox).MouseMove -= DrawOnMap;
                    (tablePanel.GetControlFromPosition(0, i) as PictureBox).MouseDown -= DrawOnMap;
                    (tablePanel.GetControlFromPosition(tablePanel.ColumnCount - 1, i) as PictureBox).Image = Resources.wallBrick;
                    (tablePanel.GetControlFromPosition(tablePanel.ColumnCount - 1, i) as PictureBox).MouseMove -= DrawOnMap;
                    (tablePanel.GetControlFromPosition(tablePanel.ColumnCount - 1, i) as PictureBox).MouseDown -= DrawOnMap;

                    continue;
                }
                
                for (int j = 0; j < tablePanel.ColumnCount; j++) {
                    (tablePanel.GetControlFromPosition(j, i) as PictureBox).Image = Resources.wallBrick;
                    (tablePanel.GetControlFromPosition(j, i) as PictureBox).MouseMove -= DrawOnMap;
                    (tablePanel.GetControlFromPosition(j, i) as PictureBox).MouseDown -= DrawOnMap;
                }
            }
            tablePanel.ResumeLayout(true); 
            tablePanel.Enabled = true;
        }

        private Image currentPenImage = Resources.wallBrick; //pocetno stanje

        private bool drawMode = true;
        private void DrawOnMap(object sender, MouseEventArgs e)
        {
            if (!drawMode)
                return;

            PictureBox pictureBox = sender as PictureBox;

            if (e.Button == MouseButtons.Left)
            {
                //MouseMove radi "Capture" nad misem ako se klikne taster.
                //Kako bi se bojilo po drugim poljima, mora da se uradi "un-Capture"
                if (pictureBox.Capture)
                    pictureBox.Capture = false;

                pictureBox.Image = currentPenImage;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (pictureBox.Capture)
                    pictureBox.Capture = false;

                pictureBox.Image = null;
            }
            
        }

        private void resizeCellsButton_Click(object sender, EventArgs e)
        {
            ResizeCells(tableLayoutPanel1);
        }

        private void ResizeCells(TableLayoutPanel tableLayout)
        {
            float size = (float)numericUpDownCellSize.Value;

            tableLayout.Visible = false;
            tableLayout.Enabled = false;
            tableLayout.SuspendLayout();
            tableLayout.AutoScroll = false;
            for (int i = 0; i < tableLayout.RowCount; i++)
            {
                tableLayout.RowStyles[i].Height = size;
                tableLayout.ColumnStyles[i].Width = size;
            }
            tableLayout.ResumeLayout(true);
            tableLayout.Invalidate(true);
            tableLayout.Update();
            tableLayout.Visible = true;
            tableLayout.Enabled = true;
            tableLayout.AutoScroll = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gameObjectsFlowLayoutPanel.Enabled = radioButtonDrawMode.Checked;
            drawMode = radioButtonDrawMode.Checked;
        }
    }
}
