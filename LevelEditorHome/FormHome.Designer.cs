namespace LevelEditor {
    partial class FormHome {
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
            panelCreateProject = new System.Windows.Forms.Panel();
            pictureBoxCreate = new System.Windows.Forms.PictureBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panelOpenProject = new System.Windows.Forms.Panel();
            pictureBoxOpen = new System.Windows.Forms.PictureBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            panelCreateProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCreate).BeginInit();
            panelOpenProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpen).BeginInit();
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
            exitButton.Location = new System.Drawing.Point(1116, 2);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(40, 40);
            exitButton.TabIndex = 0;
            exitButton.Text = "✕";
            exitButton.UseVisualStyleBackColor = false;
            // 
            // panelCreateProject
            // 
            panelCreateProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            panelCreateProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelCreateProject.Controls.Add(pictureBoxCreate);
            panelCreateProject.Controls.Add(label3);
            panelCreateProject.Controls.Add(label2);
            panelCreateProject.Location = new System.Drawing.Point(61, 106);
            panelCreateProject.Name = "panelCreateProject";
            panelCreateProject.Size = new System.Drawing.Size(421, 112);
            panelCreateProject.TabIndex = 4;
            // 
            // pictureBoxCreate
            // 
            pictureBoxCreate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBoxCreate.Image = Properties.Resources.create225;
            pictureBoxCreate.Location = new System.Drawing.Point(24, 23);
            pictureBoxCreate.Name = "pictureBoxCreate";
            pictureBoxCreate.Size = new System.Drawing.Size(50, 50);
            pictureBoxCreate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxCreate.TabIndex = 4;
            pictureBoxCreate.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(93, 54);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(271, 19);
            label3.TabIndex = 3;
            label3.Text = "Start creating new custom map pack.";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(93, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(205, 24);
            label2.TabIndex = 2;
            label2.Text = "Create New Project";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(61, 68);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(115, 19);
            label1.TabIndex = 3;
            label1.Text = "Getting Started";
            // 
            // panelOpenProject
            // 
            panelOpenProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            panelOpenProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelOpenProject.Controls.Add(pictureBoxOpen);
            panelOpenProject.Controls.Add(label4);
            panelOpenProject.Controls.Add(label5);
            panelOpenProject.Location = new System.Drawing.Point(61, 224);
            panelOpenProject.Name = "panelOpenProject";
            panelOpenProject.Size = new System.Drawing.Size(421, 112);
            panelOpenProject.TabIndex = 5;
            // 
            // pictureBoxOpen
            // 
            pictureBoxOpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBoxOpen.Image = Properties.Resources.open;
            pictureBoxOpen.Location = new System.Drawing.Point(24, 23);
            pictureBoxOpen.Name = "pictureBoxOpen";
            pictureBoxOpen.Size = new System.Drawing.Size(50, 50);
            pictureBoxOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxOpen.TabIndex = 5;
            pictureBoxOpen.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(93, 54);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(308, 19);
            label4.TabIndex = 3;
            label4.Text = "Open existing project from local directory.";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(93, 20);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(141, 24);
            label5.TabIndex = 2;
            label5.Text = "Open Project";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(668, 68);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(117, 19);
            label6.TabIndex = 6;
            label6.Text = "Recent Projects";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(671, 109);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(434, 333);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            ClientSize = new System.Drawing.Size(1154, 494);
            ControlBox = false;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label6);
            Controls.Add(panelOpenProject);
            Controls.Add(panelCreateProject);
            Controls.Add(label1);
            Controls.Add(exitButton);
            Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.White;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(1170, 510);
            MinimizeBox = false;
            Name = "FormHome";
            panelCreateProject.ResumeLayout(false);
            panelCreateProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCreate).EndInit();
            panelOpenProject.ResumeLayout(false);
            panelOpenProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOpen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel panelCreateProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelOpenProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxCreate;
        private System.Windows.Forms.PictureBox pictureBoxOpen;
    }
}

