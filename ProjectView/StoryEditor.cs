using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor.ProjectView {
    public partial class StoryEditor : Form {
        private Point _mouseLoc; // used for moving the form

        private Map currentMap;
        private Project currentProject;

        private bool unsavedChanges;

        public StoryEditor(Map m, Project p) {
            InitializeComponent();
            SetDarkTheme();
            AddEventsToControls();

            currentMap = m;
            currentProject = p;

            textBox.Text = m.StoryText;
            unsavedChanges = false;
            mapNameLabel.Text = m.Name;
        }

        private void SetDarkTheme() {
            exitButton.FlatAppearance.MouseOverBackColor = DarkTheme.ButtonHoverColor;
            exitButton.FlatAppearance.MouseDownBackColor = DarkTheme.ButtonMouseDownColor;

            //menuStrip styles
            menuStrip1.Renderer = new CustomToolStripRenderer(DarkTheme.BackgroundColor);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.BackColor = DarkTheme.BackgroundColor;

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
            this.MouseDown += StoryEditor_MouseDown;
            this.MouseMove += StoryEditor_MouseMove;

            this.exitButton.Click += ExitButton_Click;
            this.FormClosing += StoryEditor_FormClosing;

            this.saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            this.textBox.TextChanged += TextBox_TextChanged;

            this.btnSaveChanges.Click += BtnSaveChanges_Click;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveMapToFile();
        }

        private void TextBox_TextChanged(object sender, EventArgs e) {
            unsavedChanges = true;
            mapNameLabel.Text = $"{currentMap.Name}*";
            
            currentMap.StoryText = textBox.Text;
        }

        private void StoryEditor_MouseDown(object sender, MouseEventArgs e) {
            _mouseLoc = e.Location;
        }

        private void StoryEditor_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int dx = e.Location.X - _mouseLoc.X;
                int dy = e.Location.Y - _mouseLoc.Y;
                this.Location = new Point(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void StoryEditor_FormClosing(object sender, FormClosingEventArgs e) {
            //TODO: check if changes were made and ask if user wants to save
            if (!unsavedChanges)
                return;

            DialogResult result = MessageBox.Show("Do you want to save changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes) {
                SaveMapToFile();
            }
            else if (result == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e) {
            SaveMapToFile();
        }

        private void SaveMapToFile() {
            try {
                //currentMap.WriteMapToJson($"{currentProject.Path}\\{currentProject.Name}\\maps", $"{currentMap.Name}.lem");
                currentMap.WriteMapToJson($"{currentProject.Path}\\maps", $"{currentMap.Name}.lem");


                unsavedChanges = false;
                mapNameLabel.Text = $"{currentMap.Name}";
            }
            catch {
                MessageBox.Show("Error saving changes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
