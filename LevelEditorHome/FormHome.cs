using LevelEditor.LevelEditorHome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelEditor {
    public partial class FormHome : Form {
        private Point _mouseLoc; // used for moving the form
        private RecentProjectsManager recentProjectsManager;


        public FormHome() {
            InitializeComponent();
            SetDarkTheme();
            recentProjectsManager = new RecentProjectsManager();
            AddRecentProjectsToPanel();
            AddEventsToControls();
        }

        private void SetDarkTheme() {

        }

        private void AddEventsToControls() {
            //for moving the form
            this.MouseDown += FormHome_MouseDown;
            this.MouseMove += FormHome_MouseMove;

            exitButton.Click += ExitButton_Click;

            //for changing the background color of the create panel
            panelCreateProject.MouseMove += PanelBackground_MouseMove;
            panelCreateProject.MouseLeave += PanelBackground_MouseLeave;
            foreach (Control control in panelCreateProject.Controls) {
                control.MouseMove += PanelBackground_MouseMove;
                control.MouseLeave += PanelBackground_MouseLeave;
                control.Click += ShowCreateNewProjectForm;
            }
            panelCreateProject.Click += ShowCreateNewProjectForm;

            //for changing the background color of the open panel
            panelOpenProject.MouseMove += PanelBackground_MouseMove;
            panelOpenProject.MouseLeave += PanelBackground_MouseLeave;
            panelOpenProject.Click += OpenProjectDialog;
            foreach (Control control in panelOpenProject.Controls) {
                control.MouseMove += PanelBackground_MouseMove;
                control.MouseLeave += PanelBackground_MouseLeave;
                control.Click += OpenProjectDialog;
            }
        }

        private void AddRecentProjectsToPanel() {
            if (recentProjectsManager.RecentProjects.Count > 0)
                recentProjectsPanel.Controls.RemoveByKey("noRecentProjectsLabel");

            foreach (Project P in recentProjectsManager.RecentProjects) {
                RecentProjectButton rpb = new RecentProjectButton();
                rpb.Project = P;
                recentProjectsPanel.Controls.Add(rpb);
                rpb.Dock = DockStyle.Top;
                rpb.Controls["projectName"].Text = P.Name;
                rpb.Controls["projectPath"].Text = P.Path.Length > 70 ? $"{P.Path[..70]}..." : P.Path;
                rpb.Controls["lastOpenedDate"].Text = $"{P.LastOpened.ToShortDateString()} - {P.LastOpened.TimeOfDay.Hours}:" + (P.LastOpened.TimeOfDay.Minutes == 0 ? "00" : P.LastOpened.TimeOfDay.Minutes);
                rpb.Click += RecentProjectButton_Click;
                foreach (Control control in rpb.Controls) {
                    control.Click += RecentProjectButton_Click;
                    control.MouseMove += PanelBackground_MouseMove;
                    control.MouseLeave += PanelBackground_MouseLeave;
                }
            }
        }

        private void RecentProjectButton_Click(object sender, EventArgs e) {
            Project P;
            if (sender is RecentProjectButton) {
                P = (sender as RecentProjectButton).Project;
            }
            else {
                P = ((sender as Control).Parent as RecentProjectButton).Project;
            }
            openProject($"{P.Path}\\{P.Name}\\{P.Name}.lep");
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

        private void PanelBackground_MouseMove(object sender, EventArgs e) {
            if (sender is Panel)
                (sender as Control).BackColor = DarkTheme.ButtonHoverColor;
            else
                (sender as Control).Parent.BackColor = DarkTheme.ButtonHoverColor;
        }

        private void PanelBackground_MouseLeave(object sender, EventArgs e) {
            if (sender is Panel)
                (sender as Control).BackColor = DarkTheme.BackgroundColor;
            else
                (sender as Control).Parent.BackColor = DarkTheme.BackgroundColor;
        }

        private void OpenProjectDialog(object sender, EventArgs e) {
            //open file browser, show only .lep files
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Level Editor Project (*.lep)|*.lep";
            openFileDialog.Title = "Open Project";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                openProject(openFileDialog.FileName);
            }

            //TODO: Open project located in projectPath directory
        }

        private void ShowCreateNewProjectForm(object sender, EventArgs e) {
            CreateNewProject createNewProjectWindow = new CreateNewProject();
            createNewProjectWindow.Show();
            this.Hide();
        }

        private void openProject(string path) {
            try {
                string jsonProjectData = System.IO.File.ReadAllText(path);
                Project proj = JsonSerializer.Deserialize<Project>(jsonProjectData);
                ProjectViewForm projectViewForm = new ProjectViewForm(proj);
                recentProjectsManager.UpdateRecentProjects(proj);
                projectViewForm.Show();
                this.Hide();
            }
            catch {
                MessageBox.Show("Error opening project", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }
    }
}
