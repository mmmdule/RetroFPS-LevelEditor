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
            projectCreateDate = new System.Windows.Forms.Label();
            projectPath = new System.Windows.Forms.Label();
            projectName = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // projectCreateDate
            // 
            projectCreateDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            projectCreateDate.AutoSize = true;
            projectCreateDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            projectCreateDate.ForeColor = System.Drawing.Color.LightGray;
            projectCreateDate.Location = new System.Drawing.Point(18, 74);
            projectCreateDate.MaximumSize = new System.Drawing.Size(393, 20);
            projectCreateDate.Name = "projectCreateDate";
            projectCreateDate.Size = new System.Drawing.Size(105, 19);
            projectCreateDate.TabIndex = 7;
            projectCreateDate.Text = "Creation Date";
            // 
            // projectPath
            // 
            projectPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            projectPath.AutoSize = true;
            projectPath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            projectPath.Location = new System.Drawing.Point(18, 47);
            projectPath.MaximumSize = new System.Drawing.Size(393, 20);
            projectPath.Name = "projectPath";
            projectPath.Size = new System.Drawing.Size(113, 19);
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
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            Controls.Add(projectCreateDate);
            Controls.Add(projectPath);
            Controls.Add(projectName);
            ForeColor = System.Drawing.Color.White;
            Name = "RecentProjectButton";
            Size = new System.Drawing.Size(421, 112);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label projectCreateDate;
        private System.Windows.Forms.Label projectPath;
        private System.Windows.Forms.Label projectName;
    }
}
