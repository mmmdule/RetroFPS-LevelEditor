namespace LevelEditor {
    partial class AddNewMap {
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
            textBoxMapName = new System.Windows.Forms.TextBox();
            rbLevel = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            rbStory = new System.Windows.Forms.RadioButton();
            btnAddMap = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            projectNameLabel = new System.Windows.Forms.Label();
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
            exitButton.Location = new System.Drawing.Point(643, 2);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(39, 26);
            exitButton.TabIndex = 2;
            exitButton.Text = "✕";
            exitButton.UseVisualStyleBackColor = false;
            // 
            // textBoxMapName
            // 
            textBoxMapName.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            textBoxMapName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxMapName.ForeColor = System.Drawing.Color.White;
            textBoxMapName.Location = new System.Drawing.Point(153, 76);
            textBoxMapName.Name = "textBoxMapName";
            textBoxMapName.Size = new System.Drawing.Size(474, 24);
            textBoxMapName.TabIndex = 17;
            // 
            // rbLevel
            // 
            rbLevel.AutoSize = true;
            rbLevel.Location = new System.Drawing.Point(58, 152);
            rbLevel.Name = "rbLevel";
            rbLevel.Size = new System.Drawing.Size(57, 21);
            rbLevel.TabIndex = 19;
            rbLevel.TabStop = true;
            rbLevel.Text = "Level";
            rbLevel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(58, 125);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 17);
            label1.TabIndex = 18;
            label1.Text = "Map Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(58, 79);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 17);
            label2.TabIndex = 21;
            label2.Text = "Map name:";
            // 
            // rbStory
            // 
            rbStory.AutoSize = true;
            rbStory.Location = new System.Drawing.Point(58, 182);
            rbStory.Name = "rbStory";
            rbStory.Size = new System.Drawing.Size(117, 21);
            rbStory.TabIndex = 20;
            rbStory.TabStop = true;
            rbStory.Text = "Story segment";
            rbStory.UseVisualStyleBackColor = true;
            // 
            // btnAddMap
            // 
            btnAddMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAddMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddMap.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnAddMap.Location = new System.Drawing.Point(509, 246);
            btnAddMap.Name = "btnAddMap";
            btnAddMap.Size = new System.Drawing.Size(119, 33);
            btnAddMap.TabIndex = 26;
            btnAddMap.Text = "Add Map";
            btnAddMap.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnCancel.Location = new System.Drawing.Point(384, 246);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(119, 33);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // projectNameLabel
            // 
            projectNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            projectNameLabel.AutoSize = true;
            projectNameLabel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            projectNameLabel.Location = new System.Drawing.Point(58, 30);
            projectNameLabel.Name = "projectNameLabel";
            projectNameLabel.Size = new System.Drawing.Size(150, 24);
            projectNameLabel.TabIndex = 28;
            projectNameLabel.Text = "Add New Map";
            // 
            // AddNewMap
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            ClientSize = new System.Drawing.Size(684, 309);
            ControlBox = false;
            Controls.Add(projectNameLabel);
            Controls.Add(btnCancel);
            Controls.Add(btnAddMap);
            Controls.Add(rbLevel);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(rbStory);
            Controls.Add(textBoxMapName);
            Controls.Add(exitButton);
            Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.White;
            MinimumSize = new System.Drawing.Size(700, 325);
            Name = "AddNewMap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox textBoxMapName;
        private System.Windows.Forms.RadioButton rbLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbStory;
        private System.Windows.Forms.Button btnAddMap;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label projectNameLabel;
    }
}