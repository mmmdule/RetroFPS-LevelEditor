using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LevelEditor {
    public partial class FormDraw : Form {
        //Image[] editorImages
        List<Image> editorImages = new List<Image>{Resources.ArchwaySingle, Resources.ArchwaySmall,
        Resources.ArmorBlink, Resources.Bullets, Resources.Imp, Resources.Cobweb_Wall,
        Resources.DoorGate, Resources.EnergyBall, Resources.ExitDoor, Resources.Key,
        Resources.ShotgunAmmo,Resources.SmallMedkit, Resources.Stone, Resources.Torch,
        Resources.Tri_horn, Resources.wallBrick};

        List<MapGameObject> mapGameObjects = new List<MapGameObject>();

        int CurrentPictureSize = 30;

        public FormDraw() {
            this.DoubleBuffered = true;
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            //for (int i = 0; i < pictureBoxArr.Length; i++)
            //    pictureBoxArr[i] = null;

            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(panel1, true, null);

            panel1.Paint += Panel1_Paint;
            panel1.Scroll += Panel1_Scroll;
            panel1.Resize += Panel1_Resize;
            panel1.MouseClick += Panel_MouseClick;
            panel1.MouseMove += Panel1_MouseMove;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e) {
            PanelDrawDirect(sender, e);
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e) {
            PanelDrawDirect(sender, e);
        }

        private void PanelDrawDirect(object sender, MouseEventArgs e) {
            if (!drawMode)
                return;

            Panel panel = sender as Panel;
            int x, y;
            int itemCount = mapGameObjects.Count;

            x = (panel.PointToClient(Cursor.Position).X / CurrentPictureSize); //* CurrentPictureSize;
            y = (panel.PointToClient(Cursor.Position).Y / CurrentPictureSize); //* CurrentPictureSize;
            if (y == 0 || y == 63 || x == 0 || x == 63)
                return;

            if (e.Button == MouseButtons.Left) {
                //MouseMove radi "Capture" nad misem ako se klikne taster.
                //Kako bi se bojilo po drugim poljima, mora da se uradi "un-Capture"
                if (panel.Capture)
                    panel.Capture = false;

                Console.WriteLine($"X: {x}, Y: {y}");

                for (int i = 0; i < itemCount; i++)
                    if (mapGameObjects[i].X == x && mapGameObjects[i].Y == y) {
                        mapGameObjects[i].SetTypeFromImage(currentPenImage);
                        panel.Invalidate();
                        panel.Update();
                        return;
                    }
                MapGameObject tmpGameObj = new MapGameObject(x, y);
                tmpGameObj.SetTypeFromImage(currentPenImage);
                mapGameObjects.Add(tmpGameObj);
                panel.Invalidate();
                panel.Update();

                //ADD GAMEOBJECT TO LIST ON CALCULATED COORDINATES
                //ONLY CHANGE IT'S IMAGE & TYPE IF IT EXISTS THERE ALREADY
            }
            else if (e.Button == MouseButtons.Right) {
                if (panel.Capture)
                    panel.Capture = false;


                for (int i = 0; i < itemCount; i++)
                    if (mapGameObjects[i].X == x && mapGameObjects[i].Y == y) {
                        mapGameObjects.RemoveAt(i);
                        panel.Invalidate();
                        panel.Update();
                        break;
                    }
                //REMOVE GAMEOBJECT FROM LIST ON CALCULATED COORDINATES
            }
        }

        Rectangle panelAreaRect;

        private void Panel1_Resize(object sender, EventArgs e) {
            panelAreaRect = new Rectangle((sender as Panel).Location, (sender as Panel).Size);
        }


        private void Panel1_Scroll(object sender, ScrollEventArgs e) {
            //(sender as Panel).SuspendLayout();
            //(sender as Panel).Invalidate(panelAreaRect, false);
            //(sender as Panel).Update();
            //(sender as Panel).ResumeLayout(true);
        }

        Pen GridPen = new Pen(Brushes.White);
        private void Panel1_Paint(object sender, PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

            foreach (MapGameObject gObject in mapGameObjects) {
                e.Graphics.DrawImage(gObject.Image, gObject.X * CurrentPictureSize, gObject.Y * CurrentPictureSize,
                                     CurrentPictureSize, CurrentPictureSize);
            }

            //GRID
            for (int i = 0; i < 64; i++) {
                // Vertical
                e.Graphics.DrawLine(GridPen, i * CurrentPictureSize, 0, i * CurrentPictureSize, 64 * CurrentPictureSize);
                // Horizontal
                e.Graphics.DrawLine(GridPen, 0, i * CurrentPictureSize, 64 * CurrentPictureSize, i * CurrentPictureSize);
            }

        }

        private void Form1_Load(object sender, EventArgs e) {
            this.SuspendLayout();

            FillPanelOnLoad(panel1, 30);
            //AddBasicLevelOutline(panel1); //now handled inside FillPanelOnLoad

            AddPenChoiceButtonEvents(gameObjectsFlowLayoutPanel);
            this.ResumeLayout(true);
            panelAreaRect = new Rectangle(panel1.Location, panel1.Size);
        }


        private bool resizingTable = false;


        private void AddPenChoiceButtonEvents(FlowLayoutPanel flowPanel) {
            for (int i = 0; i < flowPanel.Controls.Count; i++) {
                (flowPanel.Controls[i] as Button).Click += PenChoice_Click;
            }
        }

        private void PenChoice_Click(object sender, EventArgs e) {
            currentPenImage = (sender as Button).BackgroundImage;
        }



        private void FillPanelOnLoad(Panel panel, int pictureSize) {
            this.UseWaitCursor = true; //this == Form

            panel.Enabled = false;
            panel.Padding = new Padding(0);
            panel.Margin = new Padding(0);
            panel.SuspendLayout();


            Point pos = new Point(0, 0);
            Size size = new Size(pictureSize, pictureSize);

            //panel.ClientSize = new Size(pictureSize * 64, pictureSize * 64);
            

            if (mapGameObjects.Count == 0)
                AddBasicLevelOutline(panel, pictureSize);

            panel.ResumeLayout(true);
            panel.Enabled = true;

            this.UseWaitCursor = false; //this == Form
        }




        private void AddBasicLevelOutline(Panel panel, int pictureSize) {
            panel.Enabled = false;
            panel.SuspendLayout();

            panel.Controls.Clear();
            for (int i = 0; i <= 63; i += 63) //HORIZONTAL
                for (int j = 0; j < 64; j++) {
                    MapGameObject tmp = new MapGameObject(j /* * pictureSize*/, i /** pictureSize*/);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    mapGameObjects.Add(tmp);
                }
            for (int i = 1; i <= 62; i ++) //VERTICAL
                for (int j = 0; j < 64; j+=63) {
                    MapGameObject tmp = new MapGameObject(j /* * pictureSize*/, i /*  * pictureSize*/);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    mapGameObjects.Add(tmp);
                }

            panel.Invalidate();
            panel.Update();

            panel.ResumeLayout(true);
            panel.Enabled = true;
        }

        private Image currentPenImage = Resources.wallBrick; //pocetno stanje

        private bool drawMode = true;
        private void DrawOnMap(object sender, MouseEventArgs e) {
            if (!drawMode)
                return;

            PictureBox pictureBox = sender as PictureBox;

            if (e.Button == MouseButtons.Left) {
                //MouseMove radi "Capture" nad misem ako se klikne taster.
                //Kako bi se bojilo po drugim poljima, mora da se uradi "un-Capture"
                if (pictureBox.Capture)
                    pictureBox.Capture = false;

                pictureBox.Image = currentPenImage;
            }
            else if (e.Button == MouseButtons.Right) {
                if (pictureBox.Capture)
                    pictureBox.Capture = false;

                pictureBox.Image = null;
            }

        }

        private void resizeCellsButton_Click(object sender, EventArgs e) {
            CurrentPictureSize = (int)numericUpDownCellSize.Value;
            panel1.Invalidate();
            panel1.Update();
            //FillPanelOnLoad(panel1, CurrentPictureSize);



            //ResizeCells(panel1, new Point((int)numericUpDownCellSize.Value));
        }

        private void ResizeCells(Panel panel, Point point) {
            this.UseWaitCursor = true;

            panel.Enabled = false;

            Point pos = new Point(0, 0);

            panel.Enabled = true;

            this.UseWaitCursor = false;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            gameObjectsFlowLayoutPanel.Enabled = radioButtonDrawMode.Checked;
            drawMode = radioButtonDrawMode.Checked;
        }
    }
}
