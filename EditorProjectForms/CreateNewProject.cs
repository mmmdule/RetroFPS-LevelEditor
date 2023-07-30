using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LevelEditor {
    public partial class CreateNewProject : Form {
        private Point _mouseLoc; // used for moving the form
        private bool validInputs = true;
        public CreateNewProject() {
            InitializeComponent();
            SetDarkTheme();

            AddDefaultValuesTextBoxes();
            UpdatePathLabel(validInputs);
            AddEventsToControls();

            //create projects directory in Documents if it doesn't exist
            if (!Directory.Exists(textBoxPath.Text)) {
                Directory.CreateDirectory(textBoxPath.Text);
            }

            buttonCreateProject.Enabled = validInputs;
        }

        private void SetDarkTheme() {

        }

        private void AddEventsToControls() {
            //for moving the form
            this.MouseDown += NewProjectForm_MouseDown;
            this.MouseMove += NewProjectForm_MouseMove;

            exitButton.Click += ExitButton_Click;
            buttonBrowse.Click += ButtonBrowse_Click;

            buttonCreateProject.Click += ButtonCreateProject_Click;

            textBoxProjectName.TextChanged += TextBoxNameOrPath_TextChanged;
            textBoxPath.TextChanged += TextBoxNameOrPath_TextChanged;
        }

        private void ButtonCreateProject_Click(object sender, EventArgs e) {
            if (!validInputs)
                return;

            Project project = new Project(textBoxProjectName.Text.Trim(), textBoxGameTitle.Text.Trim(), textBoxSubtitle.Text.Trim(), textBoxPath.Text.Trim(), textBoxAuthor.Text.Trim());

            //create directory for project

            try {
                project.CreateProjectDirectory(textBoxPath.Text.Trim(), textBoxProjectName.Text.Trim());
                project.JsonSerializeProject(textBoxPath.Text.Trim(), textBoxProjectName.Text.Trim());
                ProjectViewForm projectViewForm = new ProjectViewForm(project);
                projectViewForm.Show();
                this.Hide();
            }
            catch (Exception ex) {
                string errorMsg = "Error creating project directory or project file.";
                MessageBox.Show(errorMsg,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            folderBrowserDialog.SelectedPath = textBoxPath.Text;
            UpdatePathLabel(ProjectInfoIsValid());
        }

        private void TextBoxNameOrPath_TextChanged(object sender, EventArgs e) {
            validInputs = ProjectInfoIsValid();
            TextBox textBox = sender as TextBox;
            SetTextBoxWarningColors(ref textBox, validInputs);

            UpdatePathLabel(validInputs);


            buttonCreateProject.Enabled = validInputs;
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
            if (Directory.Exists(path + "\\" + name + i)) {
                while (Directory.Exists(path + "\\" + name + i)) {
                    i++;
                }
            }
            return name + i;
        }

        private bool ProjectInfoIsValid() {
            if (textBoxProjectName.Text.Trim().Length == 0 || textBoxPath.Text.Trim().Length == 0)
                return false;

            //check if project directory name is valid
            if (textBoxProjectName.Text.Trim().IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                return false;


            //check if directory already exists so we don't overwrite it
            //if (System.IO.Directory.Exists(textBoxPath.Text + "\\" + textBoxProjectName.Text))
            //    return false;

            return true;
        }

        private void UpdatePathLabel(bool valid) {
            if (valid) {
                labelFullProjectPath.ForeColor = DarkTheme.TextColor;
                labelFullProjectPath.Text = $"'{textBoxPath.Text}\\{textBoxProjectName.Text}'";
                return;
            }
            
            labelFullProjectPath.Text = "Invalid path or name input!";
            labelFullProjectPath.ForeColor = Color.Red;
        }

        private void SetTextBoxWarningColors(ref TextBox textBox, bool textIsValid) {
            if (textIsValid) {
                textBox.BackColor = DarkTheme.BackgroundColor;
                textBox.ForeColor = Color.White;
                return;
            }

            //TODO: add red boder to textbox (?) instead of changing the background color
            textBox.BackColor = Color.Red;
            textBox.ForeColor = Color.Black;
        }
    }
}
