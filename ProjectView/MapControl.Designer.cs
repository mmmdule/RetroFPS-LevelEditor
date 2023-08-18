namespace LevelEditor {
    partial class MapControl {
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
            mapName = new System.Windows.Forms.Label();
            mapNumber = new System.Windows.Forms.Label();
            moveUp = new System.Windows.Forms.Button();
            moveDown = new System.Windows.Forms.Button();
            moveBottom = new System.Windows.Forms.Button();
            moveTop = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // mapName
            // 
            mapName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            mapName.AutoSize = true;
            mapName.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mapName.Location = new System.Drawing.Point(124, 52);
            mapName.Name = "mapName";
            mapName.Size = new System.Drawing.Size(117, 24);
            mapName.TabIndex = 8;
            mapName.Text = "Map Name";
            // 
            // mapNumber
            // 
            mapNumber.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            mapNumber.AutoSize = true;
            mapNumber.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            mapNumber.Location = new System.Drawing.Point(3, 24);
            mapNumber.Name = "mapNumber";
            mapNumber.Size = new System.Drawing.Size(115, 77);
            mapNumber.TabIndex = 11;
            mapNumber.Text = "01";
            // 
            // moveUp
            // 
            moveUp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            moveUp.BackgroundImage = Properties.Resources.upArrow48;
            moveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            moveUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(56, 56, 56);
            moveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            moveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            moveUp.ForeColor = System.Drawing.Color.White;
            moveUp.Location = new System.Drawing.Point(407, 13);
            moveUp.Name = "moveUp";
            moveUp.Size = new System.Drawing.Size(49, 49);
            moveUp.TabIndex = 12;
            moveUp.UseVisualStyleBackColor = true;
            // 
            // moveDown
            // 
            moveDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            moveDown.BackgroundImage = Properties.Resources.downArrow48;
            moveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            moveDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(56, 56, 56);
            moveDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            moveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            moveDown.ForeColor = System.Drawing.Color.White;
            moveDown.Location = new System.Drawing.Point(407, 68);
            moveDown.Name = "moveDown";
            moveDown.Size = new System.Drawing.Size(49, 49);
            moveDown.TabIndex = 13;
            moveDown.UseVisualStyleBackColor = true;
            // 
            // moveBottom
            // 
            moveBottom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            moveBottom.BackgroundImage = Properties.Resources.bottomArrow48;
            moveBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            moveBottom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(56, 56, 56);
            moveBottom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            moveBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            moveBottom.ForeColor = System.Drawing.Color.White;
            moveBottom.Location = new System.Drawing.Point(497, 68);
            moveBottom.Name = "moveBottom";
            moveBottom.Size = new System.Drawing.Size(49, 49);
            moveBottom.TabIndex = 15;
            moveBottom.UseVisualStyleBackColor = true;
            // 
            // moveTop
            // 
            moveTop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            moveTop.BackgroundImage = Properties.Resources.topArrow48;
            moveTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            moveTop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(56, 56, 56);
            moveTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(48, 48, 48);
            moveTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            moveTop.ForeColor = System.Drawing.Color.White;
            moveTop.Location = new System.Drawing.Point(497, 13);
            moveTop.Name = "moveTop";
            moveTop.Size = new System.Drawing.Size(49, 49);
            moveTop.TabIndex = 14;
            moveTop.UseVisualStyleBackColor = true;
            // 
            // MapControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(moveBottom);
            Controls.Add(moveTop);
            Controls.Add(moveDown);
            Controls.Add(moveUp);
            Controls.Add(mapNumber);
            Controls.Add(mapName);
            Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.White;
            Name = "MapControl";
            Size = new System.Drawing.Size(568, 124);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label mapName;
        private System.Windows.Forms.Label mapNumber;
        private System.Windows.Forms.Button moveUp;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.Button moveBottom;
        private System.Windows.Forms.Button moveTop;
    }
}
