using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace LevelEditor
{
    public partial class FormCopy : Form
    {
        //Image[] editorImages
        List<Image> editorImages = new List<Image>{Resources.ArchwaySingle, Resources.ArchwaySmall,
        Resources.ArmorBlink, Resources.Bullets, Resources.Imp, Resources.Cobweb_Wall,
        Resources.DoorGate, Resources.EnergyBall, Resources.ExitDoor, Resources.Key,
        Resources.ShotgunAmmo,Resources.SmallMedkit, Resources.Stone, Resources.Torch,
        Resources.Tri_horn, Resources.wallBrick};

        PictureBox[] pictureBoxArr; //= new PictureBox[64 * 64];

        public FormCopy()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            //for (int i = 0; i < pictureBoxArr.Length; i++)
            //    pictureBoxArr[i] = null;

            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(panel1, true, null);

            panel1.Paint += Panel1_Paint;
            panel1.Scroll += Panel1_Scroll;
            panel1.Resize += Panel1_Resize;

            
        }

        Rectangle panelAreaRect;

        private void Panel1_Resize(object sender, EventArgs e)
        {
            panelAreaRect = new Rectangle((sender as Panel).Location, (sender as Panel).Size);
        }


        private void Panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //(sender as Panel).SuspendLayout();
            //(sender as Panel).Invalidate(panelAreaRect, false);
            //(sender as Panel).Update();
            //(sender as Panel).ResumeLayout(true);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pictureBoxArr = new PictureBox[64 * 64];
            FillPanelOnLoad(panel1, 30, true);
            AddBasicLevelOutline(panel1);

            AddPenChoiceButtonEvents(gameObjectsFlowLayoutPanel);
            this.ResumeLayout(true);
            panelAreaRect = new Rectangle(panel1.Location, panel1.Size);
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
        

        private void FillPanelOnLoad(Panel panel, int pictureSize, bool firstTime = false)
        {
            this.UseWaitCursor = true; //this == Form

            panel.Enabled = false;
            panel.Padding = new Padding(0);
            panel.Margin = new Padding(0);
            panel.SuspendLayout();
            panel.Controls.Clear();
            
            Point pos = new Point(0, 0);
            Size size = new Size(pictureSize, pictureSize);
            for (int i = 0; i < pictureBoxArr.Length; i++)
            {
                if (pictureBoxArr[i] != null){
                    pictureBoxArr[i].Size = size;
                    pictureBoxArr[i].Location = pos;
                }
                else
                    pictureBoxArr[i] = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = size,
                        BackColor = Color.Black,//Color.FromArgb(128, 128, 0);
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        Location = pos
                    };

                if ((i + 1) % 64 == 0){
                    pos.X = 0;
                    pos.Y += pictureBoxArr[i].Size.Height;
                }
                else
                    pos.X += pictureBoxArr[i].Size.Width;

                if (firstTime){
                    pictureBoxArr[i].Paint += panelPictureBox_Paint;
                    pictureBoxArr[i].MouseMove += DrawOnMap;//TablePictureBox_MouseMove;
                    pictureBoxArr[i].MouseDown += DrawOnMap;
                }
                panel.Controls.Add(pictureBoxArr[i]);

                
            }
            panel.ResumeLayout(true);
            panel.Enabled = true;

            this.UseWaitCursor = false; //this == Form
        }

        private void panelPictureBox_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, (sender as PictureBox).ClientRectangle, Color.White, ButtonBorderStyle.Dashed);
            
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

        private void AddBasicLevelOutline(Panel panel)
        {
            panel.Enabled = false;
            panel.SuspendLayout();
            for (int i = 0; i < 64; i++)
            {
                pictureBoxArr[i].Image = Resources.wallBrick;
                pictureBoxArr[i].MouseMove -= DrawOnMap;
                pictureBoxArr[i].MouseDown -= DrawOnMap;
            }
            for (int i = 63; i < (64 * 64); i += 64)
            {
                pictureBoxArr[i].Image = Resources.wallBrick;
                pictureBoxArr[i].MouseMove -= DrawOnMap;
                pictureBoxArr[i].MouseDown -= DrawOnMap;
            }
            for (int i = 64; i < (64 * 64) - 64; i+= 64)
            {
                pictureBoxArr[i].Image = Resources.wallBrick;
                pictureBoxArr[i].MouseMove -= DrawOnMap;
                pictureBoxArr[i].MouseDown -= DrawOnMap;
            }
            for (int i = 64*64 - 1; i >= (64*64)-64; i--)
            {
                pictureBoxArr[i].Image = Resources.wallBrick;
                pictureBoxArr[i].MouseMove -= DrawOnMap;
                pictureBoxArr[i].MouseDown -= DrawOnMap;
            }
            panel.ResumeLayout(true);
            panel.Enabled = true;
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
            FillPanelOnLoad(panel1, (int)numericUpDownCellSize.Value);
            //ResizeCells(panel1, new Point((int)numericUpDownCellSize.Value));
        }

        private void ResizeCells(Panel panel, Point point)
        {
            this.UseWaitCursor = true;

            //panel.Visible = false;
            panel.Enabled = false;
            //panel.SuspendLayout();
            //panel.AutoScroll = false;
            PictureBox[] pictureBoxes = new PictureBox[64 * 64];
            for (int i = 0; i < panel.Controls.Count; i++)
                pictureBoxes[i] = panel.Controls[i] as PictureBox;

            Size size = new Size(point);
            for (int i = 0; i < pictureBoxes.Length; i++){
                pictureBoxes[i].Size = size;
            }

            panel.Controls.Clear();

            Point pos = new Point(0, 0);
            for (int i = 0; i < pictureBoxes.Length; i++){
                panel.Controls.Add(pictureBoxes[i]);
                panel.Controls[i].Location = pos;

                if ((i + 1) % 64 == 0)
                {
                    pos.X = 0;
                    pos.Y += panel.Controls[i].Size.Height;
                }
                else
                    pos.X += panel.Controls[i].Size.Width;
            }


            //panel.ResumeLayout(true);
            //panel.Invalidate(true);
            //panel.Update();
            //panel.Visible = true;
            panel.Enabled = true;
            //panel.AutoScroll = true;
            this.UseWaitCursor = false;
        }

        private void ResizeCells(FlowLayoutPanel flowPanel)
        {
            int size = (int)numericUpDownCellSize.Value;

            flowPanel.Visible = false;
            flowPanel.Enabled = false;
            flowPanel.SuspendLayout();
            flowPanel.AutoScroll = false;
            for (int i = 0; i < 64*64; i++)
            {
                flowPanel.Controls[i].Size = new Size(size, size);
            }
            flowPanel.ResumeLayout(true);
            flowPanel.Invalidate(true);
            flowPanel.Update();
            flowPanel.Visible = true;
            flowPanel.Enabled = true;
            flowPanel.AutoScroll = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gameObjectsFlowLayoutPanel.Enabled = radioButtonDrawMode.Checked;
            drawMode = radioButtonDrawMode.Checked;
        }
    }
}
