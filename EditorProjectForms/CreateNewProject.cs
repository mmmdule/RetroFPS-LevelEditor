using LevelEditor.LevelEditorHome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor {
    public partial class CreateNewProject : Form {
        private Point _mouseLoc; // used for moving the form
        private bool validInputs = true;
        public CreateNewProject() {
            InitializeComponent();
            SetDarkTheme();
            AddEventsToControls();

            AddDefaultValuesTextBoxes();
        }

        private void SetDarkTheme() {

        }

        private void AddEventsToControls() {
            //for moving the form
            this.MouseDown += NewProjectForm_MouseDown;
            this.MouseMove += NewProjectForm_MouseMove;

            exitButton.Click += ExitButton_Click;
            buttonBrowse.Click += ButtonBrowse_Click; ;


            textBoxProjectName.TextChanged += TextBoxNameOrPath_TextChanged;
            textBoxPath.TextChanged += TextBoxNameOrPath_TextChanged;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            folderBrowserDialog.SelectedPath = textBoxPath.Text;
            UpdatePathLabel();
        }

        private void TextBoxNameOrPath_TextChanged(object sender, EventArgs e) {
            bool textIsValid = ProjectInfoIsValid();
            TextBox textBox = sender as TextBox;
            SetTextBoxWarningColors(ref textBox, textIsValid);

            UpdatePathLabel();

            buttonCreateProject.Enabled = textIsValid;
        }


        private void NewProjectForm_MouseDown(object sender, MouseEventArgs e) {
            _mouseLoc = e.Location;
        }

        private void NewProjectForm_MouseMove(object sender, MouseEventArgs e) {
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

        private void AddDefaultValuesTextBoxes() {
            //set default projects path
            textBoxPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LevelEditorProjects";

            textBoxProjectName.Text = DefaultProjectName(textBoxPath.Text);
        }

        private string DefaultProjectName(string path) {
            string name = "LevelPack";
            //check if projects with the prefix LevelPack exist
            //if they do, add a number to the end of the name
            //if they don't, use the name LevelPack1
            int i = 1;
            if (System.IO.Directory.Exists(path + "\\" + name + i)) {
                while (System.IO.Directory.Exists(path + "\\" + name + i)) {
                    i++;
                }
            }
            return name + i;
        }

        private bool ProjectInfoIsValid() {
            if (textBoxProjectName.Text.Trim().Length == 0)
                return false;

            //check if project directory name is valid
            if (textBoxProjectName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
                return false;

            //check if path name is valid
            if (textBoxPath.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
                return false;

            //check if directory already exists so we don't overwrite it
            //if (System.IO.Directory.Exists(textBoxPath.Text + "\\" + textBoxProjectName.Text))
            //    return false;

            return true;
        }

        private void UpdatePathLabel() {
            labelFullProjectPath.Text = $"'{textBoxPath.Text}\\{textBoxProjectName.Text}'";
        }

        private void SetTextBoxWarningColors(ref TextBox textBox, bool textIsValid) {
            if (textIsValid) {
                textBox.BackColor = Color.FromArgb(31, 31, 31);
                textBox.ForeColor = Color.White;
                return;
            }

            //TODO: add red boder to textbox (?) instead of changing the background color
            textBox.BackColor = Color.Red;
            textBox.ForeColor = Color.Black;
            labelFullProjectPath.Text = "";
        }
    }
}
