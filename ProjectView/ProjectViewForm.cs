using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor {
    public partial class ProjectViewForm : Form {
        private Point _mouseLoc; // used for moving the form
        private Project currentProject;
        private int selectedMapIndex = -1;

        public delegate void RefreshUiDelegate();
        private RefreshUiDelegate refreshUiDelegate;

        public ProjectViewForm(Project project) {
            InitializeComponent();
            SetDarkTheme();
            AddEventsToControls();
            currentProject = project;
            AddProjectInfoToForm();
            AddMapsToPanel();
            currentProject.LastOpened = DateTime.Now;
            currentProject.SaveToJsonFile(currentProject.Path, currentProject.Name);

            refreshUiDelegate = new RefreshUiDelegate(AddMapsToPanel);
        }

        //TODO: constructor that takes a project as a parameter

        private void SetDarkTheme() {
            exitButton.FlatAppearance.MouseOverBackColor = DarkTheme.ButtonHoverColor;
            exitButton.FlatAppearance.MouseDownBackColor = DarkTheme.ButtonMouseDownColor;

            foreach (Control control in this.Controls)
                control.BackColor = DarkTheme.BackgroundColor;

            //menuStrip styles
            menuStrip1.Renderer = new CustomToolStripRenderer(DarkTheme.BackgroundColor);
            menuStrip1.ForeColor = Color.White;

            foreach (ToolStripMenuItem item in menuStrip1.Items) {
                item.BackColor = DarkTheme.BackgroundColor;
                item.ForeColor = Color.White;
                item.DropDown.BackColor = DarkTheme.BackgroundColor;
                item.DropDown.ForeColor = Color.White;
                item.DropDown.RenderMode = ToolStripRenderMode.System;
            }
        }

        private void AddEventsToControls() {
            //for moving the form
            this.MouseDown += FormHome_MouseDown;
            this.MouseMove += FormHome_MouseMove;

            exitButton.Click += ExitButton_Click;

            btnRemoveMap.Click += BtnRemoveMap_Click;
            btnAddMap.Click += BtnAddMap_Click;
        }

        private void BtnAddMap_Click(object sender, EventArgs e) {
            AddNewMap newMapForm = new AddNewMap(currentProject, refreshUiDelegate);
            newMapForm.ShowDialog();
        }

        private void BtnRemoveMap_Click(object sender, EventArgs e) {
            if (selectedMapIndex == -1)
                return;

            DialogResult result = MessageBox.Show("Are you sure you want to remove this map?\n\nThis will delete the map data as well. If you only wish to remove the map from the project first make sure to back up the map file.", "Remove map", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            try {
                //delete the map file
                //System.IO.File.Delete($"{currentProject.Path}\\{currentProject.Name}\\maps\\{currentProject.MapNameList[selectedMapIndex]}.lem");
                System.IO.File.Delete($"{currentProject.Path}\\maps\\{currentProject.MapNameList[selectedMapIndex]}.lem");
                currentProject.MapNameList.RemoveAt(selectedMapIndex);
                currentProject.SaveToJsonFile(currentProject.Path, currentProject.Name);
                AddMapsToPanel();
                selectedMapIndex = -1;
            }
            catch (Exception) { }
        }

        private void FormHome_MouseDown(object sender, MouseEventArgs e) {
            _mouseLoc = e.Location;
        }

        private void FormHome_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            //this.Close();
            Application.Exit();
        }

        private void AddProjectInfoToForm() {
            projectNameLabel.Text = currentProject.Name;

            textBoxProjectName.Text = currentProject.Name;
            textBoxAuthor.Text = currentProject.Author;
            textBoxGameTitle.Text = currentProject.GameTitle;
            textBoxSubtitle.Text = currentProject.GameSubtitle;
            textBoxPath.Text = $"{currentProject.Path}";


        }

        private void AddMapsToPanel() {
            noRecentProjectsLabel.Visible = currentProject.MapNameList.Count == 0;
            mapsPanel.Controls.Clear();
            //if maps exist, add them to the panel
            for (int i = currentProject.MapNameList.Count - 1; i >= 0; i--) {
                MapControl mp = new MapControl();
                mapsPanel.Controls.Add(mp);
                mp.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                mp.Controls["mapName"].Text = currentProject.MapNameList[i];
                mp.Controls["mapNumber"].Text = (i + 1) > 9 ? $"{i + 1}" : $"0{i + 1}";
                mp.Controls["moveUp"].Click += MoveUp_Click;
                mp.Controls["moveDown"].Click += MoveDown_Click;
                mp.Controls["moveTop"].Click += MoveTop_Click;
                mp.Controls["moveBottom"].Click += MoveBottom_Click;
                mp.Dock = DockStyle.Top;
                mp.Click += Map_SingleClick;
                mp.DoubleClick += Map_DoubleClick; ;
                foreach (Control control in mp.Controls) {
                    if (control is not Button) {
                        control.Click += Map_SingleClick;
                        control.DoubleClick += Map_SingleClick;
                    }
                }
                //Add events to up/down & top/bottom buttons
            }
        }

        private void Map_DoubleClick(object sender, EventArgs e) {
            int index = -1;

            //get the index of the map
            if (sender is MapControl)
                index = int.Parse((sender as Control).Controls["mapNumber"].Text) - 1;
            else
                index = int.Parse((sender as Control).Parent.Controls["mapNumber"].Text) - 1;

            //open the map
            Map map = currentProject.ReadMap(index);
            if(map == null) {
                MessageBox.Show("Error occured while opening the map.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (map.StoryTextSegment) {
                //Open text editor
                ProjectView.StoryEditor storyEditor = new ProjectView.StoryEditor(map, currentProject);
                storyEditor.ShowDialog();
            }
            else {
                //Open map editor
                FormDraw formDraw = new FormDraw(map, currentProject);
                formDraw.ShowDialog();
                //this.WindowState = FormWindowState.Minimized;
            }
        }

        private void MoveUp_Click(object sender, EventArgs e) {
            //TODO: move map up in the list
            //get the name and the number of the map from the parent control
            string name = (sender as Control).Parent.Controls["mapName"].Text;
            int index = int.Parse((sender as Control).Parent.Controls["mapNumber"].Text) - 1;

            //swap the map name and the map number with the one above it
            try {
                string tmp = currentProject.MapNameList[index];
                currentProject.MapNameList[index] = currentProject.MapNameList[index - 1];
                currentProject.MapNameList[index - 1] = tmp;
                currentProject.SaveToJsonFile(currentProject.Path, currentProject.Name);
                AddMapsToPanel();
            }
            catch (Exception) { }
        }

        private void MoveDown_Click(object sender, EventArgs e) {
            //TODO: move map down in the list
            //get the name and the number of the map from the parent control
            string name = (sender as Control).Parent.Controls["mapName"].Text;
            int index = int.Parse((sender as Control).Parent.Controls["mapNumber"].Text) - 1;

            //swap the map name and the map number with the one above it
            try {
                string tmp = currentProject.MapNameList[index];
                currentProject.MapNameList[index] = currentProject.MapNameList[index + 1];
                currentProject.MapNameList[index + 1] = tmp;
                currentProject.SaveToJsonFile(currentProject.Path, currentProject.Name);
                AddMapsToPanel();
            }
            catch (Exception) { }
        }
        private void MoveTop_Click(object sender, EventArgs e) {
            //TODO: move map to the top of the list
            //get the name and the number of the map from the parent control
            string name = (sender as Control).Parent.Controls["mapName"].Text;
            int index = int.Parse((sender as Control).Parent.Controls["mapNumber"].Text) - 1;

            //swap the map name and the map number with the one on the top
            try {
                string tmp = currentProject.MapNameList[index];
                currentProject.MapNameList.RemoveAt(index);
                currentProject.MapNameList.Insert(0, tmp);
                currentProject.SaveToJsonFile(currentProject.Path, currentProject.Name);
                AddMapsToPanel();
            }
            catch (Exception) { }
        }

        private void MoveBottom_Click(object sender, EventArgs e) {
            //TODO: move map to the bottom of the list
            //get the name and the number of the map from the parent control
            string name = (sender as Control).Parent.Controls["mapName"].Text;
            int index = int.Parse((sender as Control).Parent.Controls["mapNumber"].Text) - 1;

            //swap the map name and the map number with the one on the bottom
            try {
                string tmp = currentProject.MapNameList[index];
                currentProject.MapNameList.RemoveAt(index);
                currentProject.MapNameList.Add(tmp);
                currentProject.SaveToJsonFile(currentProject.Path, currentProject.Name);
                AddMapsToPanel();
            }
            catch (Exception) { }
        }

        private void Map_SingleClick(object sender, EventArgs e) {
            Control control;
            if (sender is MapControl) {
                control = sender as MapControl;
            }
            else {
                control = (sender as Control).Parent;
            }

            foreach (Control c in mapsPanel.Controls) {
                c.BackColor = DarkTheme.BackgroundColor;
            }
            control.BackColor = DarkTheme.ButtonHoverColor;
            //-1 because the map number is 1-based in the UI
            selectedMapIndex = int.Parse(control.Controls["mapNumber"].Text) - 1;
        }

        private void ProjectViewForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }
    }
}
