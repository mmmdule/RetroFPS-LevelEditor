namespace LevelEditor.ProjectView {
    partial class StoryEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            mapNameLabel = new System.Windows.Forms.Label();
            exitButton = new System.Windows.Forms.Button();
            textBox = new System.Windows.Forms.TextBox();
            btnSaveChanges = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mapNameLabel
            // 
            mapNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mapNameLabel.AutoSize = true;
            mapNameLabel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mapNameLabel.ForeColor = System.Drawing.Color.White;
            mapNameLabel.Location = new System.Drawing.Point(21, 40);
            mapNameLabel.Name = "mapNameLabel";
            mapNameLabel.Size = new System.Drawing.Size(117, 24);
            mapNameLabel.TabIndex = 4;
            mapNameLabel.Text = "Map Name";
            // 
            // exitButton
            // 
            exitButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            exitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            exitButton.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            exitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            exitButton.ForeColor = System.Drawing.Color.White;
            exitButton.Location = new System.Drawing.Point(759, 1);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(39, 26);
            exitButton.TabIndex = 5;
            exitButton.Text = "✕";
            exitButton.UseVisualStyleBackColor = false;
            // 
            // textBox
            // 
            textBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox.BackColor = System.Drawing.Color.Black;
            textBox.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox.ForeColor = System.Drawing.Color.Red;
            textBox.Location = new System.Drawing.Point(21, 89);
            textBox.MaxLength = 300;
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(751, 340);
            textBox.TabIndex = 6;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSaveChanges.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnSaveChanges.ForeColor = System.Drawing.Color.White;
            btnSaveChanges.Location = new System.Drawing.Point(653, 445);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new System.Drawing.Size(119, 33);
            btnSaveChanges.TabIndex = 26;
            btnSaveChanges.Text = "Save changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(45, 24);
            menuStrip1.TabIndex = 27;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.ShortcutKeyDisplayString = "";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W;
            exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // StoryEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            ClientSize = new System.Drawing.Size(800, 500);
            ControlBox = false;
            Controls.Add(menuStrip1);
            Controls.Add(btnSaveChanges);
            Controls.Add(textBox);
            Controls.Add(exitButton);
            Controls.Add(mapNameLabel);
            Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MinimumSize = new System.Drawing.Size(816, 516);
            Name = "StoryEditor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label mapNameLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}