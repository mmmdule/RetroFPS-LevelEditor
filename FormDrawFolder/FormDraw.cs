﻿//using LevelEditor.MapObjectClasses;
using LevelEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace LevelEditor {
    public partial class FormDraw : Form {
        private List<MapObject> MapObjectList = new List<MapObject>();
        private MapObject selectedMapObject = null;

        private Project currentProject = null; //for project saving and loading
        private Map currentMap = null;

        private bool doorAdded = false;
        private bool gateAdded = false;
        private bool playerAdded = false;
        private bool keyAdded = false; //TODO: implement key must be unique on map

        private int CurrentPictureSize = 30;

        private bool unsavedChanges = false;

        private bool middleClickMove = false;
        private Rectangle panelAreaRect;
        private bool drawScroll = false;
        private int drawX = 0, drawY = 0;
        private Pen GridPen = new Pen(Brushes.White);

        private bool resizingTable = false;
        private bool eraseSelected = false;
        private bool playerSelected = false;
        private Image currentPenImage = Resources.wallBrick; //inital state of pen is wallBrick

        private bool drawMode = true;

        private int wallTextureIndex = 0;


        public FormDraw() {
            this.DoubleBuffered = true;
            InitializeComponent();
            SetControlsToDarkTheme();

            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(panel1, true, null);

            AddEventsToControls();
        }

        public FormDraw(Map m, Project p) {
            this.DoubleBuffered = true;
            currentProject = p;
            //add all mapObjects to MapObjectList, and extended types too
            foreach (MapObject mObj in m.MapObjects) {
                MapObjectList.Add(mObj);
            }
            foreach (MapNpcObject mObj in m.MapNpcObjects)
                MapObjectList.Add(mObj);
            foreach (Pickup mObj in m.Pickups)
                MapObjectList.Add(mObj);
            MapObjectList.Add(m.PlayerGameObject);

            this.Text = $"{p.Name} - {m.Name}";
            unsavedChanges = false;

            currentMap = m;
            InitializeComponent();
            SetControlsToDarkTheme();

            typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(panel1, true, null);

            AddEventsToControls();
        }

        private void AddEventsToControls() {
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

            //player input eventHandlers
            playerHealthInput.ValueChanged += PlayerInputs_AnyValueChanged;
            playerHasRevolverCheckBox.CheckedChanged += PlayerInputs_AnyValueChanged;
            playerRevolverAmmoInput.ValueChanged += PlayerInputs_AnyValueChanged;
            playerHasShotgunCheckBox.CheckedChanged += PlayerInputs_AnyValueChanged;
            playerShotgunAmmoInput.ValueChanged += PlayerInputs_AnyValueChanged;
            playerHasSmgCheckBox.CheckedChanged += PlayerInputs_AnyValueChanged;
            playerSmgAmmoInput.ValueChanged += PlayerInputs_AnyValueChanged;

            //wall brush menu toolstrip eventHandlers
            foreach (ToolStripMenuItem item in wallBrushToolStripMenuItem.DropDownItems)
                item.Click += wallBrushChange;

            //wall texture menu toolstrip eventHandlers
            foreach (ToolStripMenuItem item in wallTextureToolStripMenu.DropDownItems)
                item.Click += borderWallTextureChange;

            //valueInput will be used for health, shotgun and bullet pickups.
            //their health value will be set to the value of valueInput
            //and it will represent how much health/ammo they give to the player
            valueInput.ValueChanged += ValueInput_ValueChanged;

            foreach (ToolStripMenuItem item in brushesToolStripMenuItem.DropDownItems)
                item.Click += BrushesViewChange;
        }

        private void BrushesViewChange(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;
            item.CheckState = CheckState.Checked;
            //uncheck all other items?
            foreach (ToolStripMenuItem i in brushesToolStripMenuItem.DropDownItems) {
                if (i != item) {
                    i.Checked = false;
                    i.CheckState = CheckState.Unchecked;
                }
            }

            switch (item.Text) {
                case "All":
                    ShowAllBrushes();
                    break;
                case "Walls":
                    ShowWallBrushes();
                    break;
                case "Enemies":
                    ShowEnemyBrushes();
                    break;
                case "Map Objects":
                    ShowMapObjectBrushes();
                    break;
                case "Pickups":
                    ShowPickupBrushes();
                    break;
                case "Player":
                    ShowPlayerBrushes();
                    break;
            }
        }

        private void SetControlsToDarkTheme() {
            this.BackColor = DarkTheme.BackgroundColor;
            foreach (Control control in this.Controls)
                control.BackColor = DarkTheme.BackgroundColor;
            foreach (Control control in panel3.Controls)
                control.BackColor = DarkTheme.BackgroundColor;
            foreach (Control control in panel4.Controls)
                control.BackColor = DarkTheme.BackgroundColor;
            button17.BackColor = DarkTheme.BackgroundColor;
            foreach (Control c in groupBoxPickup.Controls)
                c.BackColor = DarkTheme.BackgroundColor;
            foreach (Control c in groupBoxPlayer.Controls)
                c.BackColor = DarkTheme.BackgroundColor;

            //remove groupBox border
            groupBoxPickup.Paint += (sender, e) => {
                e.Graphics.Clear(DarkTheme.BackgroundColor); //fills the entire control with the specified color
            };
            groupBoxPlayer.Paint += (sender, e) => {
                e.Graphics.Clear(DarkTheme.BackgroundColor);
            };


            //adjust menuStrip1 to dark theme

            menuStrip1.Renderer = new CustomToolStripRenderer(DarkTheme.BackgroundColor);
            menuStrip1.ForeColor = Color.White;

            foreach (ToolStripMenuItem item in menuStrip1.Items) {
                item.BackColor = DarkTheme.BackgroundColor;
                item.ForeColor = Color.White;
                item.DropDown.BackColor = DarkTheme.BackgroundColor;
                item.DropDown.ForeColor = Color.White;
                item.DropDown.RenderMode = ToolStripRenderMode.System;
            }

            //make wallTextureToolStripMenuItem dropdown menu dark
            wallTextureToolStripMenu.DropDown.ForeColor = Color.White;
            wallTextureToolStripMenu.DropDown.BackColor = DarkTheme.BackgroundColor;

            brushesToolStripMenuItem.DropDown.ForeColor = Color.White;
            brushesToolStripMenuItem.DropDown.BackColor = DarkTheme.BackgroundColor;
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
                btn.FlatAppearance.MouseOverBackColor = DarkTheme.ButtonHoverColor;
                btn.FlatAppearance.MouseDownBackColor = DarkTheme.ButtonMouseDownColor;
            }

            (flowPanel.Controls[0] as Button).FlatAppearance.BorderColor = Color.Red;
        }

        private void PenChoice_Click(object sender, EventArgs e) {
            Button btn = (sender as Button);
            currentPenImage = btn.BackgroundImage;
            eraseSelected = (currentPenImage == null);
            foreach (Button b in gameObjectsFlowLayoutPanel.Controls) {
                b.FlatAppearance.BorderColor = Color.White;
            }
            btn.FlatAppearance.BorderColor = Color.Red;
        }

        private void FillPanelOnLoad(Panel panel, int pictureSize) {
            this.UseWaitCursor = true; //this == Form

            panel.Enabled = false;
            panel.Padding = new Padding(0);
            panel.Margin = new Padding(0);
            panel.SuspendLayout();


            Point pos = new Point(63 * pictureSize, 0);
            Size size = new Size(pictureSize, pictureSize);

            if (MapObjectList.Count == 0)
                AddBasicLevelOutline(panel);

            panel.ResumeLayout(true);
            panel.Enabled = true;

            this.UseWaitCursor = false; //this == Form
        }

        private bool IsItTheFirstTime() {
            int itemCount = 0;
            for (int i = 0; i <= 63; i += 63) //HORIZONTAL
                for (int j = 0; j < 64; j++) {
                    if (MapObjectList.Find(x => x.X == j && x.Y == i) != null) {
                        itemCount++;
                    }
                }
            for (int i = 1; i <= 62; i++) //VERTICAL
                for (int j = 0; j < 64; j += 63) {
                    if (MapObjectList.Find(x => x.X == j && x.Y == i) != null) {
                        itemCount++;
                    }
                }

            return itemCount == 252; //252 is the number of items on the border of the Map (64x64 map)
        }

        private void AddBasicLevelOutline(Panel panel, bool serialize = true) {
            panel.Enabled = false;
            panel.SuspendLayout();

            //if firstTime, serialize the Map
            bool firstTime = IsItTheFirstTime();
            if (!firstTime && serialize) {
                return;
            }

            //panel.Controls.Clear();
            for (int i = 0; i <= 63; i += 63) //HORIZONTAL
                for (int j = 0; j < 64; j++) {
                    MapObject tmp = new MapObject(j, i);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    MapObjectList.Add(tmp);
                }
            for (int i = 1; i <= 62; i++) //VERTICAL
                for (int j = 0; j < 64; j += 63) {
                    MapObject tmp = new MapObject(j, i);
                    tmp.SetTypeFromImage(Resources.wallBrick);
                    MapObjectList.Add(tmp);
                }

            panel.Invalidate();
            panel.Update();
            panel.ResumeLayout(true);
            panel.Enabled = true;

            if (serialize) {
                SerializeList();
            }
        }

        private void borderWallTextureChange(object sender, EventArgs e) {
            ChangeBorderTexture((sender as ToolStripMenuItem).Image);
            panel1.Invalidate();
            panel1.Update();
        }

        private void ChangeBorderTexture(Image imageArg) {
            //change texture of border walls
            foreach (MapObject mapGameObject in MapObjectList) {
                if (mapGameObject.X == 0 || mapGameObject.X == 63 || mapGameObject.Y == 0 || mapGameObject.Y == 63) {
                    mapGameObject.Image = imageArg;
                    mapGameObject.SetTypeFromImage(imageArg);
                }
            }
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
            if (selectedMapObject != null && selectedMapObject is Pickup) {
                (selectedMapObject as Pickup).Value = (int)valueInput.Value;
            }
        }

        private void PropertyInputs_AnyValueChanged(object sender, EventArgs e) {
            //apply changes to selected object
            if (selectedMapObject != null && (selectedMapObject.Type == "Imp" || selectedMapObject.Type == "Tri_horn")) {
                MapNpcObject selectedMapGameObject = selectedMapObject as MapNpcObject;
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

        private void PlayerInputs_AnyValueChanged(object sender, EventArgs e) {
            PlayerGameObject player = MapObjectList.Find(x => x is PlayerGameObject) as PlayerGameObject;
            if (player == null || selectedMapObject is not PlayerGameObject)
                return;

            //apply changes to player object
            switch ((sender as Control).Name) {
                case "playerHealthInput":
                    player.Health = (int)playerHealthInput.Value;
                    break;
                case "playerHasRevolverCheckBox":
                    player.HasRevolver = playerHasRevolverCheckBox.Checked;
                    break;
                case "playerRevolverAmmoInput":
                    player.RevolverAmmo = (int)playerRevolverAmmoInput.Value;
                    break;
                case "playerHasShotgunCheckBox":
                    player.HasShotgun = playerHasShotgunCheckBox.Checked;
                    break;
                case "playerShotgunAmmoInput":
                    player.ShotgunAmmo = (int)playerShotgunAmmoInput.Value;
                    break;
                case "playerHasSmgCheckBox":
                    player.HasSmg = playerHasSmgCheckBox.Checked;
                    break;
                case "playerSmgAmmoInput":
                    player.SmgAmmo = (int)playerSmgAmmoInput.Value;
                    break;
                default:
                    break;
            }
        }


        private void InputPanel_Resize(object sender, EventArgs e) {
            //Console.WriteLine($"Size: (X,Y) == ({this.Size.Width}{this.Size.Height})");
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
                (sender as Panel).Invalidate();
                (sender as Panel).Update();
            }
            else if (e.KeyCode == Keys.Left) {
                drawX = drawX > 0 ? drawX - 1 : drawX;
                (sender as Panel).Invalidate();
                (sender as Panel).Update();
            }
            else if (e.KeyCode == Keys.Down) {
                drawY = drawY > 62 ? drawY : drawY + 1;
                (sender as Panel).Invalidate();
                (sender as Panel).Update();
            }
            else if (e.KeyCode == Keys.Up) {
                drawY = drawY > 0 ? drawY - 1 : drawY;
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
            int itemCount = MapObjectList.Count;

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

                //check if objects that must be only one on map are already added
                if (currentPenImage.Tag.Equals("ExitDoor") && doorAdded)
                    return;
                else if (currentPenImage.Tag.Equals("ExitDoor") && !doorAdded)
                    doorAdded = true;

                if (currentPenImage.Tag.Equals("DoorGate") && gateAdded)
                    return;
                else if (currentPenImage.Tag.Equals("DoorGate") && !gateAdded)
                    gateAdded = true;

                if (currentPenImage.Tag.Equals("player") && playerAdded)
                    return;

                MapObject tmpGameObj;
                if (currentPenImage.Tag.Equals("player")) {
                    playerAdded = true;
                    tmpGameObj = new PlayerGameObject(x, y);
                }
                else if (currentPenImage.Tag.Equals("Bullets")
                        || currentPenImage.Tag.Equals("ShotgunAmmo")
                        || currentPenImage.Tag.Equals("smgAmmo")
                        || currentPenImage.Tag.Equals("SmallMedkit")) {
                    tmpGameObj = new Pickup(currentPenImage.Tag.ToString(), x, y, currentPenImage);
                }
                else if (currentPenImage.Tag.Equals("Imp") || currentPenImage.Tag.Equals("Tri_horn")) {
                    tmpGameObj = new MapNpcObject(x, y, currentPenImage);
                }
                else {
                    tmpGameObj = new MapObject(x, y, currentPenImage);
                }
                tmpGameObj.SetTypeFromImage(currentPenImage);
                MapObjectList.Add(tmpGameObj);
                unsavedChanges = true;
                this.Text = $"{currentProject.Name} - {currentMap.Name}*";

                handleExistingMapObject(panel, x, y, tmpGameObj); //erases game object if it's on (X,Y). Works for NPC, Pickup & Player

                panel.Invalidate();
                panel.Update();
                //ADD GAMEOBJECT TO LIST ON CALCULATED COORDINATES
                //ONLY CHANGE IT'S IMAGE & TYPE IF IT EXISTS THERE ALREADY
            }
            else if (e.Button == MouseButtons.Right || (eraseSelected && e.Button == MouseButtons.Left)) {
                handleExistingMapObject(panel, x, y);
            }
            panel.Focus();
        }

        private void handleExistingMapObject(Panel panel, int x, int y, MapObject addedObj = null) {
            if (panel.Capture)
                panel.Capture = false;

            int removeIndex = MapObjectList.FindIndex(obj => obj.X == x && obj.Y == y && obj != addedObj);
            if (removeIndex != -1) {
                if (MapObjectList[removeIndex].Type == "ExitDoor")
                    doorAdded = false;
                if (MapObjectList[removeIndex].Type == "DoorGate")
                    gateAdded = false;
                if (MapObjectList[removeIndex] is PlayerGameObject) {
                    playerAdded = false;
                    playerSelected = false;
                }

                MapObjectList.RemoveAt(removeIndex);
                unsavedChanges = true;
                this.Text = $"{currentProject.Name} - {currentMap.Name}*";
                panel.Invalidate();
                panel.Update();
                return;
            }
            //REMOVE GAMEOBJECT FROM LIST ON CALCULATED COORDINATES

            return;
        }

        private void selectGameObjectOnMap(MouseEventArgs e, Panel panel, int x, int y) {
            if (panel.Capture)
                panel.Capture = false;
            //(sender as Panel).Focus();

            if (e.Button == MouseButtons.Left) {
                //get the item at the X and Y coordinates
                selectedMapObject = MapObjectList.Find(item => item.X == x && item.Y == y);

                if (selectedMapObject is PlayerGameObject) {
                    //playerSelected = true;
                }
                else if (selectedMapObject != null) {
                    //playerSelected = false;
                }
                else {
                    clearInputs();
                    return;
                }

                //fill the input fields in with the selected item's data
                //if the item is not null
                changeEnabledPropInputs();
                fillInputsWithSelectedProps();
            }
        }

        private void changeEnabledPropInputs() {
            if (!(selectedMapObject is MapNpcObject or Pickup or PlayerGameObject) /*&& !playerSelected*/) {
                groupBoxPickup.Visible = false;
                groupBoxPickup.Enabled = false;

                groupBoxPlayer.Enabled = false;
                groupBoxPlayer.Visible = false;

                foreach (Control c in panel3.Controls) {
                    if (c is NumericUpDown || c is CheckBox)
                        c.Enabled = false;
                }
            }
            if (selectedMapObject is Pickup) {
                groupBoxPickup.Visible = (selectedMapObject is Pickup);//(selectedMapObject.Type == "Bullets" || selectedMapObject.Type == "ShotgunAmmo" || selectedMapObject.Type == "SmallMedkit");
                groupBoxPickup.Enabled = groupBoxPickup.Visible;

                groupBoxPlayer.Enabled = false;
                groupBoxPlayer.Visible = false;
            }
            else if (selectedMapObject is MapNpcObject) {
                foreach (Control c in panel3.Controls) {
                    if (c is NumericUpDown || c is CheckBox)
                        c.Enabled = true;
                }
                groupBoxPlayer.Enabled = false;
                groupBoxPlayer.Visible = false;
                groupBoxPickup.Visible = false;
                groupBoxPickup.Enabled = false;
            }
            else if (selectedMapObject is PlayerGameObject) {
                groupBoxPickup.Visible = false;
                groupBoxPickup.Enabled = false;
                foreach (Control c in panel3.Controls) {
                    if (c is NumericUpDown || c is CheckBox)
                        c.Enabled = false;
                }
                groupBoxPlayer.Visible = true;
                groupBoxPlayer.Enabled = true;
            }
        }



        private void fillInputsWithSelectedProps(/*bool playerSelected = false*/) {
            if (selectedMapObject is PlayerGameObject) {
                PlayerGameObject player = MapObjectList.Find(obj => obj is PlayerGameObject) as PlayerGameObject;
                playerHealthInput.Value = (decimal)player.Health;
                playerRevolverAmmoInput.Value = (decimal)player.RevolverAmmo;
                playerHasRevolverCheckBox.Checked = player.HasRevolver;
                playerShotgunAmmoInput.Value = (decimal)player.ShotgunAmmo;
                playerHasShotgunCheckBox.Checked = player.HasShotgun;
                playerHasSmgCheckBox.Checked = player.HasSmg;
                playerSmgAmmoInput.Value = (decimal)player.SmgAmmo;
                playerCoordinatesLabel.Text = $"Coordinates:           ({player.X}, {player.Y})";
                typeLabel.Text = $"Type:           Player";
                return;
            }

            if (selectedMapObject != null) {
                coordinatesLabel.Text = $"Coordinates:           ({selectedMapObject.X}, {selectedMapObject.Y})";
                typeLabel.Text = $"Type:           {selectedMapObject.Type}";
            }

            if (selectedMapObject != null && selectedMapObject is Pickup) {
                //valueInput.Value = selectedBaseMapObject.Health; //for bullets, shotgun ammo, small medkit
                valueInput.Value = (selectedMapObject as Pickup).Value;
                return;
            }
            if (selectedMapObject != null && selectedMapObject is MapNpcObject) {
                MapNpcObject selectedMapGameObject = selectedMapObject as MapNpcObject;
                healthInput.Value = selectedMapGameObject.Health;
                projectileDamageInput.Value = selectedMapGameObject.ProjectileDamage;
                firingRateInput.Value = (decimal)selectedMapGameObject.FiringRate;
                patrolRangeInput.Value = (decimal)selectedMapGameObject.PatrolRange;
                sightRangeInput.Value = (decimal)selectedMapGameObject.AttackRange;
                attackRangeInput.Value = (decimal)selectedMapGameObject.ChaseRange;
                canMoveCheckboxInput.Checked = selectedMapGameObject.CanMove;
            }
        }

        private void clearInputs() {
            groupBoxPickup.Visible = false;
            groupBoxPickup.Enabled = false;
            valueInput.Value = valueInput.Minimum; //for bullets, shotgun ammo, small medkit

            foreach (Control control in panel3.Controls) {
                if (control is NumericUpDown)
                    (control as NumericUpDown).Value = (control as NumericUpDown).Minimum;
                else if (control is CheckBox)
                    (control as CheckBox).Checked = false;
            }

            foreach (Control control in groupBoxPickup.Controls) {
                if (control is NumericUpDown)
                    (control as NumericUpDown).Value = (control as NumericUpDown).Minimum;
                else if (control is CheckBox)
                    (control as CheckBox).Checked = false;
            }

            groupBoxPlayer.Visible = false;
            groupBoxPlayer.Enabled = false;
            //foreach (Control control in groupBoxPlayer.Controls) {
            //    if (control is NumericUpDown)
            //        (control as NumericUpDown).Value = (control as NumericUpDown).Minimum;
            //    else if (control is CheckBox)
            //        (control as CheckBox).Checked = false;
            //}

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
            MapObjectList.RemoveAll(x => x == null); //prevent null reference exception

            base.OnPaint(e);
            e.Graphics.Clear(DarkTheme.BackgroundColor); //clear the panel

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

            //Rectangle r = (sender as Panel).DisplayRectangle;

            foreach (MapObject gObject in MapObjectList) {
                if (gObject is PlayerGameObject) continue;

                if (gObject.X >= drawX && gObject.Y >= drawY)
                    e.Graphics.DrawImage(gObject.Image, (gObject.X - drawX) * CurrentPictureSize, (gObject.Y - drawY) * CurrentPictureSize,
                                     CurrentPictureSize, CurrentPictureSize);

            }

            PlayerGameObject player = MapObjectList.Find(obj => obj is PlayerGameObject) as PlayerGameObject;
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
            drawMode = radioButtonDrawMode.Checked;
        }



        private void SerializeList() {
            PlayerGameObject player = MapObjectList.Find(obj => obj is PlayerGameObject) as PlayerGameObject;

            //for debugging
            if (currentMap == null && currentProject == null) {
                if (player != null)
                    new Map(MapObjectList, "map1", false, "", wallTextureIndex, player).WriteMapToJson("C:\\FPS_editor_json", "level1.json");
                else
                    new Map(MapObjectList, "map1", false, "", wallTextureIndex, -1, -1).WriteMapToJson("C:\\FPS_editor_json", "level1.json"); //start X and Y -1 means no player
                return;
            }

            if (player != null)
                new Map(MapObjectList, currentMap.Name, false, "", wallTextureIndex, player).WriteMapToJson($"{currentProject.Path}\\maps", $"{currentMap.Name}.lem");
            //new Map(MapObjectList, currentMap.Name, false, "", wallTextureIndex, player).WriteMapToJson($"{currentProject.Path}\\{currentProject.Name}\\maps", $"{currentMap.Name}.lem");
            else
                new Map(MapObjectList, currentMap.Name, false, "", wallTextureIndex, null).WriteMapToJson($"{currentProject.Path}\\maps", $"{currentMap.Name}.lem");
            //new Map(MapObjectList, currentMap.Name, false, "", wallTextureIndex, null).WriteMapToJson($"{currentProject.Path}\\{currentProject.Name}\\maps", $"{currentMap.Name}.lem");


            //new Map(MapObjectList, currentMap.Name, false, "", wallTextureIndex, -1, -1).WriteMapToJson($"{currentProject.Path}\\{currentProject.Name}\\maps", $"{currentMap.Name}.lem"); //start X and Y -1 means no player

            unsavedChanges = false;
            this.Text = $"{currentProject.Name} - {currentMap.Name}";
        }

        private void resetObjectPropsButton_Click(object sender, EventArgs e) {
            if (selectedMapObject != null) {
                if (selectedMapObject is Pickup)
                    (selectedMapObject as Pickup).SetDefaultValues();
                else if (selectedMapObject is MapNpcObject)
                    (selectedMapObject as MapNpcObject).setDefaultPropsForType(selectedMapObject.Type);
                fillInputsWithSelectedProps(); //set input values to default props of selected object
            }
            else if (playerSelected) {
                PlayerGameObject player = MapObjectList.Find(obj => obj is PlayerGameObject) as PlayerGameObject;
                player = new PlayerGameObject(player.X, player.Y);
                fillInputsWithSelectedProps(); //set input values to default props of selected object
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
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
                //gameObjectsFlowLayoutPanel.Enabled = false;
                drawMode = false;
            }
        }

        private void FormDraw_FormClosing(object sender, FormClosingEventArgs e) {
            //show dialog if unsaved changes
            if (!unsavedChanges)
                return;

            DialogResult dialogResult = MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes) {
                SerializeList();
            }
            else if (dialogResult == DialogResult.No) {
                //just exit the form
                //maybe remove this else if branch
            }
            else if (dialogResult == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }

        private void resetMapToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset the map?", "Reset Map", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes) {
                MapObjectList.RemoveAll(x => !(x.Y == 0 || x.Y == 63 || x.X == 0 || x.X == 63));
                ChangeBorderTexture(Resources.wallBrick);
                panel1.Invalidate();
                panel1.Update();
                //AddBasicLevelOutline(panel1, false);
            }
        }

        private void ShowAllBrushes() {
            foreach(Button btn in gameObjectsFlowLayoutPanel.Controls) {
                btn.Visible = true;
                btn.Enabled = true;
            }
        }

        private void ShowWallBrushes(){
            List<string> wallNames = new List<string>{ "Cobweb_Wall", "wallBrick", "wallMoss", "wallStone", "tileWall" };
            foreach (Button btn in gameObjectsFlowLayoutPanel.Controls) {
                if(btn.BackgroundImage == null) { 
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else if (wallNames.IndexOf( (string)btn.BackgroundImage.Tag ) == -1) {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else {
                    btn.Visible = true;
                    btn.Enabled = true;
                }
            }
        }
        private void ShowEnemyBrushes(){
            List<string> npcNames = new List<string> { "Imp", "Tri_horn" };
            foreach (Button btn in gameObjectsFlowLayoutPanel.Controls) {
                if (btn.BackgroundImage == null)
                {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else if (npcNames.IndexOf( (string)btn.BackgroundImage.Tag ) == -1) {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else {
                    btn.Visible = true;
                    btn.Enabled = true;
                }
            }
        }
        private void ShowMapObjectBrushes(){
            List<string> objNames = new List<string> { "ArchwaySingle", "ArchwaySmall", "ArmorBlink", "DoorGate", "EnergyBall", "ExitDoor", "Key", "Stone", "Torch"};
            foreach (Button btn in gameObjectsFlowLayoutPanel.Controls) {
                if (btn.BackgroundImage == null)
                {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else if (objNames.IndexOf((string)btn.BackgroundImage.Tag) == -1) {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else {
                    btn.Visible = true;
                    btn.Enabled = true;
                }
            }
        }
        private void ShowPickupBrushes(){
            List<string> pickupNames = new List<string> { "Bullets", "ShotgunAmmo", "SmallMedkit", "smgAmmo" };
            foreach (Button btn in gameObjectsFlowLayoutPanel.Controls) {
                if (btn.BackgroundImage == null)
                {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else if (pickupNames.IndexOf((string)btn.BackgroundImage.Tag) == -1) {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else {
                    btn.Visible = true;
                    btn.Enabled = true;
                }
            }

        }
        private void ShowPlayerBrushes() {
            foreach (Button btn in gameObjectsFlowLayoutPanel.Controls) {
                if (btn.BackgroundImage == null)
                {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
                else if (btn.BackgroundImage.Tag.Equals("player")) {
                    btn.Visible = true;
                    btn.Enabled = true;
                }
                else {
                    btn.Visible = false;
                    btn.Enabled = false;
                }
            }
            
        }

    }
}
