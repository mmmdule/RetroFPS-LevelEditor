using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LevelEditor {
    public partial class FormDraw : Form {

        private List<MapGameObject> mapGameObjects = new List<MapGameObject>();
        private bool doorAdded = false;
        private bool gateAdded = false;
        private int CurrentPictureSize = 30;

        private bool unsavedChanges = false;

        private PlayerGameObject player = null;

        private bool middleClickMove = false;
        private MapGameObject selectedMapGameObject = null;
        private Rectangle panelAreaRect;
        private bool drawScroll = false;
        private int drawX = 0, drawY = 0;
        private Pen GridPen = new Pen(Brushes.White);
        private bool resizingTable = false;
        private bool eraseSelected = false;
        private bool playerSelected = false;
        private bool playerAdded = false;
        private Image currentPenImage = Resources.wallBrick; //pocetno stanje
        private bool drawMode = true;
        private int wallTextureIndex = 0;


        public FormDraw() {
            this.DoubleBuffered = true;
            InitializeComponent();

            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.BackColor = Color.FromArgb(31, 31, 31);
            foreach (Control control in this.Controls)
                control.BackColor = Color.FromArgb(31, 31, 31);
            foreach (Control control in panel3.Controls)
                control.BackColor = Color.FromArgb(31, 31, 31);
            foreach (Control control in panel4.Controls)
                control.BackColor = Color.FromArgb(31, 31, 31);
            button17.BackColor = Color.FromArgb(31, 31, 31);
            foreach (Control c in groupBoxPickup.Controls)
                c.BackColor = Color.FromArgb(31, 31, 31);
            foreach (Control c in groupBoxPlayer.Controls)
                c.BackColor = Color.FromArgb(31, 31, 31);


            //adjust menuStrip1 to dark theme

            menuStrip1.Renderer = new CustomToolStripRenderer(Color.FromArgb(31, 31, 31));
            menuStrip1.ForeColor = Color.White;

            foreach (ToolStripMenuItem item in menuStrip1.Items) {
                item.BackColor = Color.FromArgb(31, 31, 31);
                item.ForeColor = Color.White;
                item.DropDown.BackColor = Color.FromArgb(31, 31, 31);
                item.DropDown.ForeColor = Color.White;
                item.DropDown.RenderMode = ToolStripRenderMode.System;
            }

            //make wallTextureToolStripMenuItem dropdown menu dark
            wallTextureToolStripMenu.DropDown.ForeColor = Color.White;
            wallTextureToolStripMenu.DropDown.BackColor = Color.FromArgb(31, 31, 31);


            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(panel1, true, null);

            panel1.Paint += Panel1_Paint;
            panel1.Scroll += Panel1_Scroll;
            panel1.Resize += Panel1_Resize;
            panel1.MouseClick += Panel_MouseClick;
            panel1.MouseMove += Panel_MouseMove;
            panel1.PreviewKeyDown += Panel1_KeyDownScroll;

            panel1.MouseWheel += Panel1_MouseWheel;

            panel1.BackgroundImageLayout = ImageLayout.None;

            //input eventHandlers
            attackRangeInput.ValueChanged += PropertyInputs_AnyValueChanged;
            canMoveCheckboxInput.CheckedChanged += PropertyInputs_AnyValueChanged;
            sightRangeInput.ValueChanged += PropertyInputs_AnyValueChanged;
            firingRateInput.ValueChanged += PropertyInputs_AnyValueChanged;
            healthInput.ValueChanged += PropertyInputs_AnyValueChanged;
            patrolRangeInput.ValueChanged += PropertyInputs_AnyValueChanged;
            projectileDamageInput.ValueChanged += PropertyInputs_AnyValueChanged;
            canMoveCheckboxInput.CheckedChanged += PropertyInputs_AnyValueChanged;

            //wall brush menu toolstrip eventHandlers
            foreach (ToolStripMenuItem item in wallBrushToolStripMenuItem.DropDownItems)
                item.Click += wallBrushChange;

            //wall texture menu toolstrip eventHandlers
            foreach (ToolStripMenuItem item in wallTextureToolStripMenu.DropDownItems)
                item.Click += wallTextureChange;

            //valueInput will be used for health, shotgun and bullet pickups.
            //their health value will be set to the value of valueInput
            //and it will represent how much health/ammo they give to the player
            valueInput.ValueChanged += ValueInput_ValueChanged;


        }

        private void wallTextureChange(object sender, EventArgs e) {
            //change texture of border walls
            foreach (MapGameObject mapGameObject in mapGameObjects) {
                if (mapGameObject.X == 0 || mapGameObject.X == 63 || mapGameObject.Y == 0 || mapGameObject.Y == 63) {
                    mapGameObject.Image = (sender as ToolStripMenuItem).Image;
                    mapGameObject.SetTypeFromImage((sender as ToolStripMenuItem).Image);
                }
            }
            panel1.Invalidate();
            panel1.Update();
        }

        private void wallBrushChange(object sender, EventArgs e) {
            wallTextureIndex = wallBrushToolStripMenuItem.DropDownItems.IndexOf(sender as ToolStripMenuItem);
            btnWallBrush.BackgroundImage = wallBrushToolStripMenuItem.DropDownItems[wallTextureIndex].Image;

            //check if currentPenImage is any of wallTextureToolStripMenuItem.DropDownItems images
            foreach (ToolStripMenuItem item in wallBrushToolStripMenuItem.DropDownItems) {
                if (currentPenImage.Tag == item.Image.Tag) {
                    currentPenImage = wallBrushToolStripMenuItem.DropDownItems[wallTextureIndex].Image;
                    break;
                }
            }

            //MessageBox.Show($"Wall texture changed to {wallTextureIndex}");
        }

        private void ValueInput_ValueChanged(object sender, EventArgs e) {
            if (selectedMapGameObject != null && (selectedMapGameObject.Type == "Bullets" || selectedMapGameObject.Type == "ShotgunAmmo" || selectedMapGameObject.Type == "SmallMedkit")) {
                selectedMapGameObject.Health = (int)valueInput.Value;
            }
        }

        private void PropertyInputs_AnyValueChanged(object sender, EventArgs e) {
            //apply changes to selected object
            if (selectedMapGameObject != null && (selectedMapGameObject.Type == "Imp" || selectedMapGameObject.Type == "Tri_horn")) {
                switch ((sender as Control).Name) {
                    case "attackRangeInput":
                        selectedMapGameObject.AttackRange = (float)attackRangeInput.Value;
                        break;
                    case "canMoveCheckboxInput":
                        selectedMapGameObject.CanMove = canMoveCheckboxInput.Checked;
                        break;
                    case "sightRangeInput":
                        selectedMapGameObject.ChaseRange = (float)sightRangeInput.Value;
                        break;
                    case "firingRateInput":
                        selectedMapGameObject.FiringRate = (float)firingRateInput.Value;
                        break;
                    case "healthInput":
                        selectedMapGameObject.Health = (int)healthInput.Value;
                        break;
                    case "patrolRangeInput":
                        selectedMapGameObject.PatrolRange = (float)patrolRangeInput.Value;
                        break;
                    case "projectileDamageInput":
                        selectedMapGameObject.ProjectileDamage = (int)projectileDamageInput.Value;
                        break;
                    default:
                        break;

                }
            }
        }

        private void InputPanel_Resize(object sender, EventArgs e) {
            Console.WriteLine($"Size: (X,Y) == ({this.Size.Width}{this.Size.Height})");
        }

        private void Panel1_MouseWheel(object sender, MouseEventArgs e) {
            Console.WriteLine("MouseWheel event");
            if (ModifierKeys == Keys.Shift) {
                if (e.Delta > 0) {
                    drawX = drawX > 0 ? drawX - 1 : drawX;
                    //(sender as Panel).Refresh();
                    (sender as Panel).Invalidate();
                    (sender as Panel).Update();
                }
                else if (e.Delta < 0) {
                    drawX = drawX > 62 ? drawX : drawX + 1;
                    //(sender as Panel).Refresh();
                    (sender as Panel).Invalidate();
                    (sender as Panel).Update();
                }
            }
            else {
                if (e.Delta > 0) {
                    drawY = drawY > 0 ? drawY - 1 : drawY;
                    //(sender as Panel).Refresh();
                    (sender as Panel).Invalidate();
                    (sender as Panel).Update();
                }
                else if (e.Delta < 0) {
                    drawY = drawY > 62 ? drawY : drawY + 1;
                    //(sender as Panel).Refresh();
                    (sender as Panel).Invalidate();
                    (sender as Panel).Update();
                }
            }

            if (ModifierKeys == Keys.Control) {
                if (e.Delta > 0) {
                    numericUpDownCellSize.Value = numericUpDownCellSize.Value + 5 > numericUpDownCellSize.Maximum ? numericUpDownCellSize.Maximum : numericUpDownCellSize.Value + 5;
                    ResizeCells(panel1, (int)numericUpDownCellSize.Value);
                }
                else if (e.Delta < 0) {
                    numericUpDownCellSize.Value = numericUpDownCellSize.Value - 5 < numericUpDownCellSize.Minimum ? numericUpDownCellSize.Minimum : numericUpDownCellSize.Value - 5;
                    ResizeCells(panel1, (int)numericUpDownCellSize.Value);
                }
            }
        }

        private void Panel1_KeyDownScroll(object sender, PreviewKeyDownEventArgs e) {


            if (e.KeyCode == Keys.Right) {
                drawX = drawX > 62 ? drawX : drawX + 1;
                //(sender as Panel).Refresh();
                (sender as Panel).Invalidate();
                (sender as Panel).Update();
            }
            else if (e.KeyCode == Keys.Left) {
                drawX = drawX > 0 ? drawX - 1 : drawX;
                //(sender as Panel).Refresh();
                (sender as Panel).Invalidate();
                (sender as Panel).Update();
            }
            else if (e.KeyCode == Keys.Down) {
                drawY = drawY > 62 ? drawY : drawY + 1;
                //(sender as Panel).Refresh();
                (sender as Panel).Invalidate();
                (sender as Panel).Update();
            }
            else if (e.KeyCode == Keys.Up) {
                drawY = drawY > 0 ? drawY - 1 : drawY;
                //(sender as Panel).Refresh();
                (sender as Panel).Invalidate();
                (sender as Panel).Update();

            }
            Console.WriteLine($"{e.KeyCode}, drawX: {drawX}, drawY: {drawY}");
        }



        private void Panel_MouseMove(object sender, MouseEventArgs e) {
            PanelDrawDirect(sender, e);
            if (middleClickMove) {
                if (e.X > 0 && e.X < (sender as Panel).Width && e.Y > 0 && e.Y < (sender as Panel).Height) {
                    if (e.X > (sender as Panel).Width / 2) {         //if mouse moves right increase drawX
                        drawX = drawX > 62 ? drawX : drawX + 1;
                        (sender as Panel).Invalidate();
                        (sender as Panel).Update();
                    }
                    else if (e.X < (sender as Panel).Width / 2) {   //if mouse moves left decrease drawX
                        drawX = drawX > 0 ? drawX - 1 : drawX;
                        (sender as Panel).Invalidate();
                        (sender as Panel).Update();
                    }
                    if (e.Y > (sender as Panel).Height / 2) {       //if mouse moves down increase drawY
                        drawY = drawY > 62 ? drawY : drawY + 1;
                        (sender as Panel).Invalidate();
                        (sender as Panel).Update();
                    }
                    else if (e.Y < (sender as Panel).Height / 2) {  //if mouse moves up decrease drawY
                        drawY = drawY > 0 ? drawY - 1 : drawY;
                        (sender as Panel).Invalidate();
                        (sender as Panel).Update();
                    }
                }
            }
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e) {
            PanelDrawDirect(sender, e);
            if (e.Button == MouseButtons.Middle) {
                middleClickMove = !middleClickMove;
            }
        }


        private void PanelDrawDirect(object sender, MouseEventArgs e) {
            Panel panel = sender as Panel;
            int x, y;
            int itemCount = mapGameObjects.Count;

            x = (panel.PointToClient(Cursor.Position).X / CurrentPictureSize) + drawX; //* CurrentPictureSize;
            y = (panel.PointToClient(Cursor.Position).Y / CurrentPictureSize) + drawY; //* CurrentPictureSize;
            if (y <= 0 || y >= 63 || x <= 0 || x >= 63)
                return;

            if (!drawMode) {
                selectGameObjectOnMap(e, panel, x, y);
                return;
            }

            if (e.Button == MouseButtons.Left && !eraseSelected) {
                //MouseMove radi "Capture" nad misem ako se klikne taster.
                //Kako bi se bojilo po drugim poljima, mora da se uradi "un-Capture"
                if (panel.Capture)
                    panel.Capture = false;

                Console.WriteLine($"Drawing Click, X: {x}, Y: {y}");

                //check if objects that must be only one on map are already added
                if (currentPenImage.Tag == "ExitDoor" && doorAdded)
                    return;
                else if (currentPenImage.Tag == "ExitDoor" && !doorAdded)
                    doorAdded = true;

                if (currentPenImage.Tag == "DoorGate" && gateAdded)
                    return;
                else if (currentPenImage.Tag == "DoorGate" && !gateAdded)
                    gateAdded = true;

                if (currentPenImage.Tag == "player" && playerAdded)
                    return;
                else if (currentPenImage.Tag == "player" && !playerAdded) {
                    playerAdded = true;
                    player = player == null ?
                                                new PlayerGameObject(x, y) :
                                                new PlayerGameObject(player.Health, player.HasRevolver,
                                                player.RevolverAmmo, player.HasShotgun, player.ShotgunAmmo, x, y);
                    unsavedChanges = true;
                    panel.Invalidate();
                    panel.Update();
                    return;
                }
                //check if objects that must be only one on map are already added


                MapGameObject existingObj = mapGameObjects.Find(go => go.X == x && go.Y == y);

                if (existingObj != null) {
                    if (currentPenImage.Tag == "player" && playerAdded)
                        return;
                    else if (currentPenImage.Tag == "player") {
                        player = player == null ?
                                                new PlayerGameObject(x, y) :
                                                new PlayerGameObject(player.Health, player.HasRevolver,
                                                player.RevolverAmmo, player.HasShotgun, player.ShotgunAmmo, x, y);
                        unsavedChanges = true;
                        panel.Invalidate();
                        panel.Update();
                        return;
                    }


                    existingObj.SetTypeFromImage(currentPenImage);
                    unsavedChanges = true;
                    panel.Invalidate();
                    panel.Update();
                    return;
                }

                MapGameObject tmpGameObj = new MapGameObject(x, y);
                tmpGameObj.SetTypeFromImage(currentPenImage);
                mapGameObjects.Add(tmpGameObj);
                unsavedChanges = true;
                panel.Invalidate();
                panel.Update();

                //ADD GAMEOBJECT TO LIST ON CALCULATED COORDINATES
                //ONLY CHANGE IT'S IMAGE & TYPE IF IT EXISTS THERE ALREADY
            }
            else if (e.Button == MouseButtons.Right || (eraseSelected && e.Button == MouseButtons.Left)) {
                eraseMapGameObject(panel, x, y);
            }
            panel.Focus();
        }

        private void eraseMapGameObject(Panel panel, int x, int y) {
            if (panel.Capture)
                panel.Capture = false;

            int removeIndex = mapGameObjects.FindIndex(obj => obj.X == x && obj.Y == y);
            if (removeIndex != -1) {
                if (mapGameObjects[removeIndex].Type == "ExitDoor")
                    doorAdded = false;
                if (mapGameObjects[removeIndex].Type == "DoorGate")
                    gateAdded = false;

                mapGameObjects.RemoveAt(removeIndex);
                unsavedChanges = true;
                panel.Invalidate();
                panel.Update();
            }
            //REMOVE GAMEOBJECT FROM LIST ON CALCULATED COORDINATES

            if (player != null && player.X == x && player.Y == y) {
                playerAdded = false;
                player = null;
                unsavedChanges = true;
                panel.Invalidate();
                panel.Update();
            }
            //REMOVE PLAYER FROM MAP ON CALCULATED COORDINATES
        }

        private void selectGameObjectOnMap(MouseEventArgs e, Panel panel, int x, int y) {
            if (panel.Capture)
                panel.Capture = false;
            //(sender as Panel).Focus();

            if (e.Button == MouseButtons.Left) {
                //get the item at the X and Y coordinates
                selectedMapGameObject = mapGameObjects.Find(item => item.X == x && item.Y == y);

                //fill the input fields in panel3 and panel4 with the selected item's data
                //if the item is not null
                if (selectedMapGameObject != null) {
                    changeEnabledPropInputs();
                    fillInputsWithSelectedProps();
                }
                else if (player != null) {
                    playerSelected = (player.X == x && player.Y == y); //true if player coords are x and y
                    changeEnabledPropInputs();
                    fillInputsWithSelectedProps(true);
                }
                else {
                    clearInputs();
                }
            }
        }

        private void changeEnabledPropInputs() {
            if(selectedMapGameObject != null) {
                groupBoxPickup.Visible = (selectedMapGameObject.Type == "Bullets" || selectedMapGameObject.Type == "ShotgunAmmo" || selectedMapGameObject.Type == "SmallMedkit");
                groupBoxPickup.Enabled = groupBoxPickup.Visible;

                bool state = (selectedMapGameObject.Type == "Imp" || selectedMapGameObject.Type == "Tri_horn");
                foreach (Control c in panel3.Controls) {
                    if (c is NumericUpDown || c is CheckBox)
                        c.Enabled = state;
                }
            }

            if(player != null) {
                groupBoxPlayer.Visible = playerSelected;
                groupBoxPlayer.Enabled = playerSelected;
            }

        }

        private void fillInputsWithSelectedProps(bool playerSelected = false) {
            if (playerSelected) {
                playerHealthInput.Value = player.Health;
                playerRevolverAmmoInput.Value = player.RevolverAmmo;
                playerHasRevolverCheckBox.Checked = player.HasRevolver;
                playerShotgunAmmoInput.Value = player.ShotgunAmmo;
                playerHasShotgunCheckBox.Checked = player.HasShotgun;
                playerCoordinatesLabel.Text = $"Coordinates:           ({player.X}, {player.Y})";
                typeLabel.Text = $"Type:           Player";
                return;
            }

            if (selectedMapGameObject.Type == "Bullets" || selectedMapGameObject.Type == "ShotgunAmmo" || selectedMapGameObject.Type == "SmallMedkit") {
                valueInput.Value = selectedMapGameObject.Health; //for bullets, shotgun ammo, small medkit
                return;
            }

            healthInput.Value = selectedMapGameObject.Health;
            projectileDamageInput.Value = selectedMapGameObject.ProjectileDamage;
            firingRateInput.Value = (decimal)selectedMapGameObject.FiringRate;
            patrolRangeInput.Value = (decimal)selectedMapGameObject.PatrolRange;
            sightRangeInput.Value = (decimal)selectedMapGameObject.AttackRange;
            attackRangeInput.Value = (decimal)selectedMapGameObject.ChaseRange;
            canMoveCheckboxInput.Checked = selectedMapGameObject.CanMove;
            coordinatesLabel.Text = $"Coordinates:           ({selectedMapGameObject.X}, {selectedMapGameObject.Y})";
            typeLabel.Text = $"Type:           {selectedMapGameObject.Type}";
        }

        private void clearInputs() {
            valueInput.Value = valueInput.Minimum; //for bullets, shotgun ammo, small medkit

            foreach(NumericUpDown numeric in panel3.Controls) {
                numeric.Value = numeric.Minimum;
            }
            foreach(CheckBox checkBox in panel3.Controls) {
                checkBox.Checked = false;
            }

            foreach(NumericUpDown numeric in groupBoxPickup.Controls) {
                numeric.Value = numeric.Minimum;
            }

            foreach(NumericUpDown numeric in groupBoxPlayer.Controls) {
                numeric.Value = numeric.Minimum;
            }
            foreach(CheckBox checkBox in groupBoxPlayer.Controls) {
                checkBox.Checked = false;
            }

            //healthInput.Value = healthInput.Minimum;
            //projectileDamageInput.Value = projectileDamageInput.Minimum;
            //firingRateInput.Value = firingRateInput.Minimum;
            //patrolRangeInput.Value = patrolRangeInput.Minimum;
            //sightRangeInput.Value = sightRangeInput.Minimum;
            //attackRangeInput.Value = attackRangeInput.Minimum;
            //canMoveCheckboxInput.Checked = false;
            coordinatesLabel.Text = "Coordinates:";
            typeLabel.Text = "Type:";

            //playerHealthInput.Value = playerHealthInput.Minimum;
            //playerRevolverAmmoInput.Value = playerRevolverAmmoInput.Minimum;
            //playerHasRevolverCheckBox.Checked = false;
            //playerShotgunAmmoInput.Value = playerShotgunAmmoInput.Minimum;
            //playerHasShotgunCheckBox.Checked = false;
            playerCoordinatesLabel.Text = "Coordinates:";
            
        }



        private void Panel1_Resize(object sender, EventArgs e) {
            panelAreaRect = new Rectangle((sender as Panel).Location, (sender as Panel).Size);
        }


        private void Panel1_Scroll(object sender, ScrollEventArgs se) {

        }




        private void Panel1_Paint(object sender, PaintEventArgs e) {

            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

            //Rectangle r = (sender as Panel).DisplayRectangle;

            foreach (MapGameObject gObject in mapGameObjects) {
                if (gObject.X >= drawX && gObject.Y >= drawY)
                    e.Graphics.DrawImage(gObject.Image, (gObject.X - drawX) * CurrentPictureSize, (gObject.Y - drawY) * CurrentPictureSize,
                                     CurrentPictureSize, CurrentPictureSize);

            }

            //PLAYER
            if (player != null) {
                e.Graphics.DrawImage(player.Image, (player.X - drawX) * CurrentPictureSize, (player.Y - drawY) * CurrentPictureSize,
                                                        CurrentPictureSize, CurrentPictureSize);
            }

            //GRID
            for (int i = 0; i < 64 - drawX; i++) {
                // Vertical
                e.Graphics.DrawLine(GridPen, i * CurrentPictureSize, 0, i * CurrentPictureSize, 64 * CurrentPictureSize);
            }
            for (int i = 0; i < 64 - drawY; i++) {
                // Horizontal
                e.Graphics.DrawLine(GridPen, 0, i * CurrentPictureSize, 64 * CurrentPictureSize, i * CurrentPictureSize);
            }


        }

        private void FormDraw_Load(object sender, EventArgs e) {
            this.SuspendLayout();

            FillPanelOnLoad(panel1, 30);
            //AddBasicLevelOutline(panel1); //now handled inside FillPanelOnLoad

            AddPenChoiceButtonEvents(gameObjectsFlowLayoutPanel);
            this.ResumeLayout(true);
            panelAreaRect = new Rectangle(panel1.Location, panel1.Size);
        }





        private void AddPenChoiceButtonEvents(FlowLayoutPanel flowPanel) {
            for (int i = 0; i < flowPanel.Controls.Count; i++) {
                Button btn = (flowPanel.Controls[i] as Button);
                btn.Click += PenChoice_Click;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.White;
                btn.FlatAppearance.BorderSize = 2;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 48, 48);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 56, 56);
            }
            (flowPanel.Controls[0] as Button).FlatAppearance.BorderColor = Color.Red;
            (flowPanel.Controls[1] as Button).Click -= PenChoice_Click; //remove event from player button
            (flowPanel.Controls[1] as Button).Click += PlayerChoice_Click; //add new event to player button
        }




        private void PlayerChoice_Click(object sender, EventArgs e) {
            Button btn = (sender as Button);
            foreach (Button b in gameObjectsFlowLayoutPanel.Controls) {
                b.FlatAppearance.BorderColor = Color.White;
            }
            btn.FlatAppearance.BorderColor = Color.Red;
            playerSelected = true;
            currentPenImage = btn.BackgroundImage;
        }

        private void PenChoice_Click(object sender, EventArgs e) {
            Button btn = (sender as Button);
            currentPenImage = btn.BackgroundImage;
            eraseSelected = (currentPenImage == null);
            foreach (Button b in gameObjectsFlowLayoutPanel.Controls) {
                b.FlatAppearance.BorderColor = Color.White;
            }
            btn.FlatAppearance.BorderColor = Color.Red;
            playerSelected = false; //this event is only for pen buttons which are not the player button
        }



        private void FillPanelOnLoad(Panel panel, int pictureSize) {
            this.UseWaitCursor = true; //this == Form

            panel.Enabled = false;
            panel.Padding = new Padding(0);
            panel.Margin = new Padding(0);
            panel.SuspendLayout();

            //panel.Controls.Clear();
            Point pos = new Point(63 * pictureSize, 0);
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
                    MapGameObject tmp = new MapGameObject(j /* * pictureSize*/, i /* * pictureSize*/);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    tmp.CanMove = false;
                    mapGameObjects.Add(tmp);
                }
            for (int i = 1; i <= 62; i++) //VERTICAL
                for (int j = 0; j < 64; j += 63) {
                    MapGameObject tmp = new MapGameObject(j /* * pictureSize*/, i /*  * pictureSize*/);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    tmp.CanMove = false;
                    mapGameObjects.Add(tmp);
                }

            panel.Invalidate();
            panel.Update();

            panel.ResumeLayout(true);
            panel.Enabled = true;
        }






        private void resizeCellsButton_Click(object sender, EventArgs e) {
            ResizeCells(panel1, (int)numericUpDownCellSize.Value);
        }



        private void ResizeCells(Panel panel, int newSize) {
            //drawX = 0;
            //drawY = 0;
            CurrentPictureSize = newSize;
            panel.Invalidate();
            panel.Update();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            gameObjectsFlowLayoutPanel.Enabled = radioButtonDrawMode.Checked;
            drawMode = radioButtonDrawMode.Checked;
            //if (!drawMode)
            //    SerializeList();
        }



        private void SerializeList() {
            if (player != null)
                new Map(mapGameObjects, "map1", false, "", wallTextureIndex, player).WriteMapToJson("C:\\FPS_editor_json", "level1.json");
            else
                new Map(mapGameObjects, "map1", false, "", wallTextureIndex, -1, -1).WriteMapToJson("C:\\FPS_editor_json", "level1.json"); //start X and Y -1 means no player

            //MapGameObject.WriteCurrentListToJson("C:\\FPS_editor_json", "level1.json", mapGameObjects);
        }

        private void resetObjectPropsButton_Click(object sender, EventArgs e) {
            if (selectedMapGameObject != null) {
                selectedMapGameObject.setDefaultPropsForType(selectedMapGameObject.Type);
                fillInputsWithSelectedProps(); //set input values to default props of selected object
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            //show dialog if unsaved changes
            if (!unsavedChanges)
                this.Close();

            DialogResult dialogResult = MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes) {
                SerializeList();
                this.Close();
            }
            else if (dialogResult == DialogResult.No) {
                this.Close();
            }
            else if (dialogResult == DialogResult.Cancel) {
                //do nothing
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            unsavedChanges = false;
            SerializeList();
        }

        private void FormDraw_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.D) {
                radioButtonDrawMode.Checked = true;
                radioButtonSelectMode.Checked = false;
                gameObjectsFlowLayoutPanel.Enabled = true;
                drawMode = true;
            }
            else if (e.KeyCode == Keys.S) {
                radioButtonDrawMode.Checked = false;
                radioButtonSelectMode.Checked = true;
                gameObjectsFlowLayoutPanel.Enabled = false;
                drawMode = false;
            }
        }

    }
}
