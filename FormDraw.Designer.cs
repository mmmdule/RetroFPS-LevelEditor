namespace LevelEditor {
    partial class FormDraw {
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            resizeCellsButton = new System.Windows.Forms.Button();
            radioButtonSelectMode = new System.Windows.Forms.RadioButton();
            numericUpDownCellSize = new System.Windows.Forms.NumericUpDown();
            radioButtonDrawMode = new System.Windows.Forms.RadioButton();
            cellSizeLabel = new System.Windows.Forms.Label();
            gameObjectsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button10 = new System.Windows.Forms.Button();
            button11 = new System.Windows.Forms.Button();
            button12 = new System.Windows.Forms.Button();
            button13 = new System.Windows.Forms.Button();
            button14 = new System.Windows.Forms.Button();
            button15 = new System.Windows.Forms.Button();
            button16 = new System.Windows.Forms.Button();
            button17 = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCellSize).BeginInit();
            gameObjectsFlowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.BackColor = System.Drawing.Color.Black;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(resizeCellsButton);
            groupBox1.Controls.Add(radioButtonSelectMode);
            groupBox1.Controls.Add(numericUpDownCellSize);
            groupBox1.Controls.Add(radioButtonDrawMode);
            groupBox1.Controls.Add(cellSizeLabel);
            groupBox1.Location = new System.Drawing.Point(1482, 38);
            groupBox1.Margin = new System.Windows.Forms.Padding(4);
            groupBox1.MaximumSize = new System.Drawing.Size(408, 1034);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(408, 973);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(8, 13);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(172, 18);
            label1.TabIndex = 7;
            label1.Text = "Game Object Properties:";
            // 
            // resizeCellsButton
            // 
            resizeCellsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            resizeCellsButton.AutoSize = true;
            resizeCellsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resizeCellsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            resizeCellsButton.Location = new System.Drawing.Point(281, 897);
            resizeCellsButton.Margin = new System.Windows.Forms.Padding(4);
            resizeCellsButton.Name = "resizeCellsButton";
            resizeCellsButton.Size = new System.Drawing.Size(93, 40);
            resizeCellsButton.TabIndex = 6;
            resizeCellsButton.Text = "Confirm";
            resizeCellsButton.UseVisualStyleBackColor = true;
            resizeCellsButton.Click += resizeCellsButton_Click;
            // 
            // radioButtonSelectMode
            // 
            radioButtonSelectMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            radioButtonSelectMode.AutoSize = true;
            radioButtonSelectMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonSelectMode.Image = Properties.Resources.cursor32;
            radioButtonSelectMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radioButtonSelectMode.Location = new System.Drawing.Point(18, 853);
            radioButtonSelectMode.Margin = new System.Windows.Forms.Padding(4);
            radioButtonSelectMode.Name = "radioButtonSelectMode";
            radioButtonSelectMode.Size = new System.Drawing.Size(141, 32);
            radioButtonSelectMode.TabIndex = 1;
            radioButtonSelectMode.Text = "Select Mode";
            radioButtonSelectMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            radioButtonSelectMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radioButtonSelectMode.UseVisualStyleBackColor = true;
            // 
            // numericUpDownCellSize
            // 
            numericUpDownCellSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            numericUpDownCellSize.BackColor = System.Drawing.Color.Black;
            numericUpDownCellSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numericUpDownCellSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownCellSize.ForeColor = System.Drawing.Color.White;
            numericUpDownCellSize.Location = new System.Drawing.Point(185, 904);
            numericUpDownCellSize.Margin = new System.Windows.Forms.Padding(4);
            numericUpDownCellSize.Maximum = new decimal(new int[] { 75, 0, 0, 0 });
            numericUpDownCellSize.Minimum = new decimal(new int[] { 13, 0, 0, 0 });
            numericUpDownCellSize.Name = "numericUpDownCellSize";
            numericUpDownCellSize.Size = new System.Drawing.Size(84, 28);
            numericUpDownCellSize.TabIndex = 5;
            numericUpDownCellSize.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // radioButtonDrawMode
            // 
            radioButtonDrawMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            radioButtonDrawMode.Checked = true;
            radioButtonDrawMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonDrawMode.Image = Properties.Resources.draw;
            radioButtonDrawMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radioButtonDrawMode.Location = new System.Drawing.Point(184, 842);
            radioButtonDrawMode.Margin = new System.Windows.Forms.Padding(4);
            radioButtonDrawMode.Name = "radioButtonDrawMode";
            radioButtonDrawMode.Size = new System.Drawing.Size(142, 52);
            radioButtonDrawMode.TabIndex = 0;
            radioButtonDrawMode.TabStop = true;
            radioButtonDrawMode.Text = "Draw Mode";
            radioButtonDrawMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            radioButtonDrawMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radioButtonDrawMode.UseVisualStyleBackColor = true;
            radioButtonDrawMode.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // cellSizeLabel
            // 
            cellSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            cellSizeLabel.AutoSize = true;
            cellSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cellSizeLabel.Location = new System.Drawing.Point(19, 904);
            cellSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            cellSizeLabel.Name = "cellSizeLabel";
            cellSizeLabel.Size = new System.Drawing.Size(141, 24);
            cellSizeLabel.TabIndex = 4;
            cellSizeLabel.Text = "Table Cell Size:";
            // 
            // gameObjectsFlowLayoutPanel
            // 
            gameObjectsFlowLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gameObjectsFlowLayoutPanel.AutoScroll = true;
            gameObjectsFlowLayoutPanel.BackColor = System.Drawing.Color.Black;
            gameObjectsFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gameObjectsFlowLayoutPanel.Controls.Add(button1);
            gameObjectsFlowLayoutPanel.Controls.Add(button2);
            gameObjectsFlowLayoutPanel.Controls.Add(button3);
            gameObjectsFlowLayoutPanel.Controls.Add(button4);
            gameObjectsFlowLayoutPanel.Controls.Add(button5);
            gameObjectsFlowLayoutPanel.Controls.Add(button6);
            gameObjectsFlowLayoutPanel.Controls.Add(button7);
            gameObjectsFlowLayoutPanel.Controls.Add(button8);
            gameObjectsFlowLayoutPanel.Controls.Add(button9);
            gameObjectsFlowLayoutPanel.Controls.Add(button10);
            gameObjectsFlowLayoutPanel.Controls.Add(button11);
            gameObjectsFlowLayoutPanel.Controls.Add(button12);
            gameObjectsFlowLayoutPanel.Controls.Add(button13);
            gameObjectsFlowLayoutPanel.Controls.Add(button14);
            gameObjectsFlowLayoutPanel.Controls.Add(button15);
            gameObjectsFlowLayoutPanel.Controls.Add(button16);
            gameObjectsFlowLayoutPanel.Controls.Add(button17);
            gameObjectsFlowLayoutPanel.Location = new System.Drawing.Point(14, 920);
            gameObjectsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            gameObjectsFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1572, 91);
            gameObjectsFlowLayoutPanel.Name = "gameObjectsFlowLayoutPanel";
            gameObjectsFlowLayoutPanel.Size = new System.Drawing.Size(1459, 91);
            gameObjectsFlowLayoutPanel.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button1.BackgroundImage = Properties.Resources.wallBrick;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(6, 7);
            button1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(68, 76);
            button1.TabIndex = 4;
            button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button2.BackColor = System.Drawing.Color.Transparent;
            button2.BackgroundImage = Properties.Resources.Imp;
            button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(86, 7);
            button2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(68, 76);
            button2.TabIndex = 5;
            button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button3.BackColor = System.Drawing.Color.Transparent;
            button3.BackgroundImage = Properties.Resources.Tri_horn;
            button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.ForeColor = System.Drawing.Color.White;
            button3.Location = new System.Drawing.Point(166, 7);
            button3.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(68, 76);
            button3.TabIndex = 6;
            button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button4.BackColor = System.Drawing.Color.Transparent;
            button4.BackgroundImage = Properties.Resources.ExitDoor;
            button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button4.ForeColor = System.Drawing.Color.White;
            button4.Location = new System.Drawing.Point(246, 7);
            button4.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(68, 76);
            button4.TabIndex = 7;
            button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button5.BackColor = System.Drawing.Color.Transparent;
            button5.BackgroundImage = Properties.Resources.Key;
            button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button5.ForeColor = System.Drawing.Color.White;
            button5.Location = new System.Drawing.Point(326, 7);
            button5.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(68, 76);
            button5.TabIndex = 8;
            button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button6.BackColor = System.Drawing.Color.Transparent;
            button6.BackgroundImage = Properties.Resources.DoorGate;
            button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button6.FlatAppearance.BorderSize = 2;
            button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button6.ForeColor = System.Drawing.Color.White;
            button6.Location = new System.Drawing.Point(406, 7);
            button6.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(68, 76);
            button6.TabIndex = 9;
            button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button7.BackColor = System.Drawing.Color.Transparent;
            button7.BackgroundImage = Properties.Resources.SmallMedkit;
            button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button7.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button7.FlatAppearance.BorderSize = 2;
            button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button7.ForeColor = System.Drawing.Color.White;
            button7.Location = new System.Drawing.Point(486, 7);
            button7.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(68, 76);
            button7.TabIndex = 10;
            button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button8.BackColor = System.Drawing.Color.Transparent;
            button8.BackgroundImage = Properties.Resources.ShotgunAmmo;
            button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button8.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button8.FlatAppearance.BorderSize = 2;
            button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button8.ForeColor = System.Drawing.Color.White;
            button8.Location = new System.Drawing.Point(566, 7);
            button8.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(68, 76);
            button8.TabIndex = 11;
            button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button9.BackColor = System.Drawing.Color.Transparent;
            button9.BackgroundImage = Properties.Resources.Bullets;
            button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button9.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button9.FlatAppearance.BorderSize = 2;
            button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button9.ForeColor = System.Drawing.Color.White;
            button9.Location = new System.Drawing.Point(646, 7);
            button9.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(68, 76);
            button9.TabIndex = 12;
            button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            button10.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button10.BackColor = System.Drawing.Color.Transparent;
            button10.BackgroundImage = Properties.Resources.Torch;
            button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button10.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button10.FlatAppearance.BorderSize = 2;
            button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button10.ForeColor = System.Drawing.Color.White;
            button10.Location = new System.Drawing.Point(726, 7);
            button10.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(68, 76);
            button10.TabIndex = 13;
            button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            button11.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button11.BackColor = System.Drawing.Color.Transparent;
            button11.BackgroundImage = Properties.Resources.Stone;
            button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button11.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button11.FlatAppearance.BorderSize = 2;
            button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button11.ForeColor = System.Drawing.Color.White;
            button11.Location = new System.Drawing.Point(806, 7);
            button11.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button11.Name = "button11";
            button11.Size = new System.Drawing.Size(68, 76);
            button11.TabIndex = 14;
            button11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            button12.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button12.BackColor = System.Drawing.Color.Transparent;
            button12.BackgroundImage = Properties.Resources.ArmorBlink;
            button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            button12.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button12.FlatAppearance.BorderSize = 2;
            button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button12.ForeColor = System.Drawing.Color.White;
            button12.Location = new System.Drawing.Point(886, 7);
            button12.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button12.Name = "button12";
            button12.Size = new System.Drawing.Size(68, 76);
            button12.TabIndex = 15;
            button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            button13.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button13.BackColor = System.Drawing.Color.Transparent;
            button13.BackgroundImage = Properties.Resources.ArchwaySingle;
            button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button13.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button13.FlatAppearance.BorderSize = 2;
            button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button13.ForeColor = System.Drawing.Color.White;
            button13.Location = new System.Drawing.Point(966, 7);
            button13.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button13.Name = "button13";
            button13.Size = new System.Drawing.Size(68, 76);
            button13.TabIndex = 16;
            button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            button14.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button14.BackColor = System.Drawing.Color.Transparent;
            button14.BackgroundImage = Properties.Resources.ArchwaySmall;
            button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button14.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button14.FlatAppearance.BorderSize = 2;
            button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button14.ForeColor = System.Drawing.Color.White;
            button14.Location = new System.Drawing.Point(1046, 7);
            button14.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button14.Name = "button14";
            button14.Size = new System.Drawing.Size(68, 76);
            button14.TabIndex = 17;
            button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            button15.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button15.BackColor = System.Drawing.Color.Transparent;
            button15.BackgroundImage = Properties.Resources.Cobweb_Wall;
            button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button15.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button15.FlatAppearance.BorderSize = 2;
            button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button15.ForeColor = System.Drawing.Color.White;
            button15.Location = new System.Drawing.Point(1126, 7);
            button15.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button15.Name = "button15";
            button15.Size = new System.Drawing.Size(68, 76);
            button15.TabIndex = 18;
            button15.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            button16.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button16.BackColor = System.Drawing.Color.Transparent;
            button16.BackgroundImage = Properties.Resources.EnergyBall;
            button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button16.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            button16.FlatAppearance.BorderSize = 2;
            button16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button16.ForeColor = System.Drawing.Color.White;
            button16.Location = new System.Drawing.Point(1206, 7);
            button16.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button16.Name = "button16";
            button16.Size = new System.Drawing.Size(68, 76);
            button16.TabIndex = 19;
            button16.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            button17.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button17.BackColor = System.Drawing.Color.Black;
            button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button17.FlatAppearance.BorderColor = System.Drawing.Color.White;
            button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74545F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button17.ForeColor = System.Drawing.Color.White;
            button17.Location = new System.Drawing.Point(1286, 7);
            button17.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            button17.Name = "button17";
            button17.Size = new System.Drawing.Size(68, 76);
            button17.TabIndex = 20;
            button17.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button17.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Location = new System.Drawing.Point(20, 48);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1453, 839);
            panel1.TabIndex = 3;
            // 
            // FormDraw
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ClientSize = new System.Drawing.Size(1902, 1036);
            Controls.Add(panel1);
            Controls.Add(gameObjectsFlowLayoutPanel);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            ForeColor = System.Drawing.Color.White;
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "FormDraw";
            ShowIcon = false;
            Text = "Level Editor - Grid Mode (FLOW)";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCellSize).EndInit();
            gameObjectsFlowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSelectMode;
        private System.Windows.Forms.RadioButton radioButtonDrawMode;
        private System.Windows.Forms.FlowLayoutPanel gameObjectsFlowLayoutPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Label cellSizeLabel;
        private System.Windows.Forms.NumericUpDown numericUpDownCellSize;
        private System.Windows.Forms.Button resizeCellsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}