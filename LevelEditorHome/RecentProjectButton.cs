using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor.LevelEditorHome {
    public partial class RecentProjectButton : UserControl {
        private Project project;

        public RecentProjectButton() {
            InitializeComponent();

            this.MouseMove += RecentProjectButton_MouseMove;
            this.MouseLeave += RecentProjectButton_MouseLeave;
        }

        public Project Project { get => project; set => project = value; }

        private void RecentProjectButton_MouseLeave(object sender, EventArgs e) {
            this.BackColor = DarkTheme.BackgroundColor;
        }

        private void RecentProjectButton_MouseMove(object sender, MouseEventArgs e) {
            this.BackColor = DarkTheme.ButtonHoverColor;
        }


    }
}
