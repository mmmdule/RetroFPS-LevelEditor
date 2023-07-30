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
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            exitButton.AutoSize = true;
            exitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            exitButton.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            exitButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            exitButton.ForeColor = System.Drawing.Color.White;
            exitButton.Location = new System.Drawing.Point(1229, -1);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(40, 40);
            exitButton.TabIndex = 1;
            exitButton.Text = "✕";
            exitButton.UseVisualStyleBackColor = false;
            // 
            // ProjectViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            ClientSize = new System.Drawing.Size(1269, 624);
            ControlBox = false;
            Controls.Add(exitButton);
            ForeColor = System.Drawing.Color.White;
            Name = "ProjectViewForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button exitButton;
    }
}