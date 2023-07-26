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

        public FormHome() {
            InitializeComponent();
            SetDarkTheme();
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
            }

            //for changing the background color of the open panel
            panelOpenProject.MouseMove += PanelBackground_MouseMove;
            panelOpenProject.MouseLeave += PanelBackground_MouseLeave;
            foreach (Control control in panelOpenProject.Controls) {
                control.MouseMove += PanelBackground_MouseMove;
                control.MouseLeave += PanelBackground_MouseLeave;
            }
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
            this.Close();
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
    }
}
