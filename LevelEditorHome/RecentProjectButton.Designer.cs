namespace LevelEditor.LevelEditorHome {
    partial class RecentProjectButton {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            lastOpenedDate = new System.Windows.Forms.Label();
            projectPath = new System.Windows.Forms.Label();
            projectName = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lastOpenedDate
            // 
            lastOpenedDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lastOpenedDate.AutoSize = true;
            lastOpenedDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lastOpenedDate.ForeColor = System.Drawing.Color.LightGray;
            lastOpenedDate.Location = new System.Drawing.Point(18, 74);
            lastOpenedDate.MaximumSize = new System.Drawing.Size(393, 20);
            lastOpenedDate.Name = "lastOpenedDate";
            lastOpenedDate.Size = new System.Drawing.Size(107, 17);
            lastOpenedDate.TabIndex = 7;
            lastOpenedDate.Text = "Last Opened On";
            // 
            // projectPath
            // 
            projectPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            projectPath.AutoSize = true;
            projectPath.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            projectPath.Location = new System.Drawing.Point(18, 47);
            projectPath.MaximumSize = new System.Drawing.Size(393, 20);
            projectPath.Name = "projectPath";
            projectPath.Size = new System.Drawing.Size(101, 17);
            projectPath.TabIndex = 6;
            projectPath.Text = "Path to project";
            // 
            // projectName
            // 
            projectName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            projectName.AutoSize = true;
            projectName.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            projectName.Location = new System.Drawing.Point(18, 13);
            projectName.MaximumSize = new System.Drawing.Size(393, 20);
            projectName.Name = "projectName";
            projectName.Size = new System.Drawing.Size(228, 20);
            projectName.TabIndex = 5;
            projectName.Text = "Name Of Your Project";
            // 
            // RecentProjectButton
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(lastOpenedDate);
            Controls.Add(projectPath);
            Controls.Add(projectName);
            ForeColor = System.Drawing.Color.White;
            MinimumSize = new System.Drawing.Size(640, 110);
            Name = "RecentProjectButton";
            Size = new System.Drawing.Size(640, 110);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lastOpenedDate;
        private System.Windows.Forms.Label projectPath;
        private System.Windows.Forms.Label projectName;
    }
}
