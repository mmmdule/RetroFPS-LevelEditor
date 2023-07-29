using LevelEditor.LevelEditorHome;
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
    public partial class FormHome : Form {
        private Point _mouseLoc; // used for moving the form
        private RecentProjectsManager recentProjectsManager;


        public FormHome() {
            InitializeComponent();
            SetDarkTheme();
            AddEventsToControls();
            recentProjectsManager = new RecentProjectsManager();
            AddRecentProjectsToPanel();
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
            foreach (Control control in panelOpenProject.Controls) {
                control.MouseMove += PanelBackground_MouseMove;
                control.MouseLeave += PanelBackground_MouseLeave;
                control.Click += OpenProjectDialog;
            }
            panelOpenProject.Click += OpenProjectDialog;
        }

        private void AddRecentProjectsToPanel() {
            if (recentProjectsManager.RecentProjects.Count > 0)
                flowLayoutPanel.Controls.RemoveByKey("noRecentProjectsLabel");

            foreach (Project P in recentProjectsManager.RecentProjects) {
                RecentProjectButton rpb = new RecentProjectButton();
                flowLayoutPanel.Controls.Add(rpb);
                rpb.Controls["projectName"].Text = P.Name;
                rpb.Controls["projectPath"].Text = P.Path;
                rpb.Controls["projectCreateDate"].Text = P.DateCreated.ToShortDateString();
                rpb.Click += RecentProjectButton_Click;
                foreach (Control control in rpb.Controls) {
                    control.Click += RecentProjectButton_Click;
                }
            }
        }

        private void RecentProjectButton_Click(object sender, EventArgs e) {
            //open project
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
                (sender as Control).BackColor = Color.FromArgb(48, 48, 48);
            else
                (sender as Control).Parent.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void PanelBackground_MouseLeave(object sender, EventArgs e) {
            if (sender is Panel)
                (sender as Control).BackColor = Color.FromArgb(31, 31, 31);
            else
                (sender as Control).Parent.BackColor = Color.FromArgb(31, 31, 31);
        }

        private void OpenProjectDialog(object sender, EventArgs e) {
            //open select folder dialog
            //inside the selected folder should be the project json file
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string projectPath = folderBrowser.SelectedPath;
            //MessageBox.Show(projectPath);

            //TODO: Open project located in projectPath directory
        }

        private void ShowCreateNewProjectForm(object sender, EventArgs e) {
            CreateNewProject createNewProjectWindow = new CreateNewProject();
            createNewProjectWindow.Show();
            this.Hide();
        }
    }
}
