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

        public ProjectViewForm(Project project) {
            InitializeComponent();
            SetDarkTheme();
            AddEventsToControls();
            currentProject = project;
            AddProjectInfoToForm();
            currentProject.LastOpened = DateTime.Now;
            currentProject.SaveToJsonFile(currentProject.Path, currentProject.Name);
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

            //if maps exist, add them to the panel
        }
    }
}
