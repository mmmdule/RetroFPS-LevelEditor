namespace LevelEditor {
    partial class ProjectViewForm {
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
            exitButton = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            projectNameLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnSaveInfoChanges = new System.Windows.Forms.Button();
            textBoxPath = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            textBoxAuthor = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            textBoxSubtitle = new System.Windows.Forms.TextBox();
            textBoxProjectName = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            textBoxGameTitle = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            mapsPanel = new System.Windows.Forms.Panel();
            noRecentProjectsLabel = new System.Windows.Forms.Label();
            btnAddMap = new System.Windows.Forms.Button();
            btnRemoveMap = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            mapsPanel.SuspendLayout();
            SuspendLayout();
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
            exitButton.Location = new System.Drawing.Point(1219, 0);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(39, 26);
            exitButton.TabIndex = 1;
            exitButton.Text = "✕";
            exitButton.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(45, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // projectNameLabel
            // 
            projectNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            projectNameLabel.AutoSize = true;
            projectNameLabel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            projectNameLabel.Location = new System.Drawing.Point(12, 38);
            projectNameLabel.Name = "projectNameLabel";
            projectNameLabel.Size = new System.Drawing.Size(146, 24);
            projectNameLabel.TabIndex = 3;
            projectNameLabel.Text = "Project Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(6, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(145, 19);
            label3.TabIndex = 6;
            label3.Text = "Project information";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(btnSaveInfoChanges);
            groupBox1.Controls.Add(textBoxPath);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textBoxAuthor);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxSubtitle);
            groupBox1.Controls.Add(textBoxProjectName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBoxGameTitle);
            groupBox1.Location = new System.Drawing.Point(593, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(651, 639);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // btnSaveInfoChanges
            // 
            btnSaveInfoChanges.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSaveInfoChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSaveInfoChanges.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnSaveInfoChanges.Location = new System.Drawing.Point(513, 582);
            btnSaveInfoChanges.Name = "btnSaveInfoChanges";
            btnSaveInfoChanges.Size = new System.Drawing.Size(119, 33);
            btnSaveInfoChanges.TabIndex = 25;
            btnSaveInfoChanges.Text = "Save changes";
            btnSaveInfoChanges.UseVisualStyleBackColor = true;
            // 
            // textBoxPath
            // 
            textBoxPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxPath.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            textBoxPath.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPath.ForeColor = System.Drawing.Color.White;
            textBoxPath.Location = new System.Drawing.Point(158, 273);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.ReadOnly = true;
            textBoxPath.Size = new System.Drawing.Size(474, 24);
            textBoxPath.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(19, 276);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(118, 17);
            label7.TabIndex = 23;
            label7.Text = "Path (parent dir.):";
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxAuthor.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            textBoxAuthor.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxAuthor.ForeColor = System.Drawing.Color.White;
            textBoxAuthor.Location = new System.Drawing.Point(158, 215);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new System.Drawing.Size(474, 24);
            textBoxAuthor.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(19, 219);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 17);
            label6.TabIndex = 21;
            label6.Text = "Author:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(19, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(95, 17);
            label1.TabIndex = 15;
            label1.Text = "Project name:";
            // 
            // textBoxSubtitle
            // 
            textBoxSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxSubtitle.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            textBoxSubtitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxSubtitle.ForeColor = System.Drawing.Color.White;
            textBoxSubtitle.Location = new System.Drawing.Point(158, 162);
            textBoxSubtitle.Name = "textBoxSubtitle";
            textBoxSubtitle.Size = new System.Drawing.Size(474, 24);
            textBoxSubtitle.TabIndex = 20;
            // 
            // textBoxProjectName
            // 
            textBoxProjectName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxProjectName.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            textBoxProjectName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjectName.ForeColor = System.Drawing.Color.White;
            textBoxProjectName.Location = new System.Drawing.Point(158, 59);
            textBoxProjectName.Name = "textBoxProjectName";
            textBoxProjectName.Size = new System.Drawing.Size(474, 24);
            textBoxProjectName.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(19, 162);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(97, 17);
            label5.TabIndex = 19;
            label5.Text = "Game Subtitle:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(19, 109);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 17);
            label4.TabIndex = 17;
            label4.Text = "Game Title:";
            // 
            // textBoxGameTitle
            // 
            textBoxGameTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxGameTitle.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            textBoxGameTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxGameTitle.ForeColor = System.Drawing.Color.White;
            textBoxGameTitle.Location = new System.Drawing.Point(158, 109);
            textBoxGameTitle.Name = "textBoxGameTitle";
            textBoxGameTitle.Size = new System.Drawing.Size(474, 24);
            textBoxGameTitle.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(13, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 19);
            label2.TabIndex = 8;
            label2.Text = "Maps";
            // 
            // mapsPanel
            // 
            mapsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mapsPanel.AutoScroll = true;
            mapsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            mapsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mapsPanel.Controls.Add(noRecentProjectsLabel);
            mapsPanel.Location = new System.Drawing.Point(10, 109);
            mapsPanel.Name = "mapsPanel";
            mapsPanel.Size = new System.Drawing.Size(570, 508);
            mapsPanel.TabIndex = 9;
            // 
            // noRecentProjectsLabel
            // 
            noRecentProjectsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            noRecentProjectsLabel.AutoSize = true;
            noRecentProjectsLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            noRecentProjectsLabel.Location = new System.Drawing.Point(12, 16);
            noRecentProjectsLabel.Name = "noRecentProjectsLabel";
            noRecentProjectsLabel.Size = new System.Drawing.Size(117, 18);
            noRecentProjectsLabel.TabIndex = 28;
            noRecentProjectsLabel.Text = "No maps added.";
            // 
            // btnAddMap
            // 
            btnAddMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAddMap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnAddMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddMap.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAddMap.ForeColor = System.Drawing.Color.Green;
            btnAddMap.Location = new System.Drawing.Point(522, 632);
            btnAddMap.Name = "btnAddMap";
            btnAddMap.Size = new System.Drawing.Size(58, 57);
            btnAddMap.TabIndex = 26;
            btnAddMap.Text = "➕";
            btnAddMap.UseVisualStyleBackColor = true;
            // 
            // btnRemoveMap
            // 
            btnRemoveMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveMap.AutoSize = true;
            btnRemoveMap.FlatAppearance.BorderColor = System.Drawing.Color.White;
            btnRemoveMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRemoveMap.Font = new System.Drawing.Font("Tahoma", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRemoveMap.ForeColor = System.Drawing.Color.Red;
            btnRemoveMap.Location = new System.Drawing.Point(458, 632);
            btnRemoveMap.Name = "btnRemoveMap";
            btnRemoveMap.Size = new System.Drawing.Size(58, 57);
            btnRemoveMap.TabIndex = 27;
            btnRemoveMap.Text = "✕";
            btnRemoveMap.UseVisualStyleBackColor = true;
            // 
            // ProjectViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            ClientSize = new System.Drawing.Size(1259, 714);
            ControlBox = false;
            Controls.Add(exitButton);
            Controls.Add(btnRemoveMap);
            Controls.Add(btnAddMap);
            Controls.Add(mapsPanel);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(projectNameLabel);
            Controls.Add(menuStrip1);
            Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.White;
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(1275, 730);
            Name = "ProjectViewForm";
            FormClosing += ProjectViewForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            mapsPanel.ResumeLayout(false);
            mapsPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSubtitle;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGameTitle;
        private System.Windows.Forms.Button btnSaveInfoChanges;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel mapsPanel;
        private System.Windows.Forms.Button btnAddMap;
        private System.Windows.Forms.Button btnRemoveMap;
        private System.Windows.Forms.Label noRecentProjectsLabel;
    }
}