using Microsoft.Win32;
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
    public partial class AddNewMap : Form {
        private Point _mouseLoc; // used for moving the form
        Project project;
        Map map;

        private ProjectViewForm.RefreshUiDelegate updateDelegate;

        public AddNewMap() {
            InitializeComponent();
        }
        public AddNewMap(Project p) {
            InitializeComponent();
            project = p;

            AddEventsToControls();
        }

        //create constructor that takes project and event as parameters
        public AddNewMap(Project p, ProjectViewForm.RefreshUiDelegate uiDelegate) {
            InitializeComponent();
            project = p;

            AddEventsToControls();
            updateDelegate = uiDelegate;
        }

        private void AddEventsToControls() {
            //for moving the form
            this.MouseDown += AddMapForm_MouseDown;
            this.MouseMove += AddMapForm_MouseMove;

            btnAddMap.Click += BtnAddMap_Click;
            exitButton.Click += ExitButton_Click;
            btnCancel.Click += ExitButton_Click;
        }

        private void AddMapForm_MouseDown(object sender, MouseEventArgs e) {
            _mouseLoc = e.Location;
        }

        private void AddMapForm_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnAddMap_Click(object sender, EventArgs e) {
            if (!checkValidInputs())
                return;

            map = new Map(textBoxMapName.Text.Trim(), rbStory.Checked);
            project.MapNameList.Add(map.Name);
            //lem == Level Editor Map
            //map.WriteMapToJson($"{project.Path}\\{project.Name}\\maps", map.Name + ".lem");
            map.WriteMapToJson($"{project.Path}\\maps", map.Name + ".lem");
            project.SaveToJsonFile(project.Path, project.Name);
            updateDelegate(); //refreshes the UI on the ProjectViewForm
            this.Close();
        }

        private bool checkValidInputs() {
            if (project.MapNameList.Contains(textBoxMapName.Text.Trim())) {
                MessageBox.Show("A map with that name already exists.");
                return false;
            }
            if (textBoxMapName.Text.Trim() == "") {
                MessageBox.Show("Please enter a name for the map.");
                return false;
            }
            if (!rbLevel.Checked && !rbStory.Checked) {
                MessageBox.Show("Please select a map type.");
                return false;
            }

            return true;
        }
    }
}
