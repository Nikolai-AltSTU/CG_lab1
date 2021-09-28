
namespace lab1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.стартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стопToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelMoveX = new System.Windows.Forms.Label();
            this.labelMoveY = new System.Windows.Forms.Label();
            this.labelMoveZ = new System.Windows.Forms.Label();
            this.labelMoveTo = new System.Windows.Forms.Label();
            this.maskedTextBoxMoveX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMoveY = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMoveZ = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRotX = new System.Windows.Forms.Label();
            this.labelRotY = new System.Windows.Forms.Label();
            this.labelRotZ = new System.Windows.Forms.Label();
            this.maskedTextBoxRotX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxRotY = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxRotZ = new System.Windows.Forms.MaskedTextBox();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonRot = new System.Windows.Forms.Button();
            this.pictureBoxOfScene = new System.Windows.Forms.PictureBox();
            this.timerOfPainting = new System.Windows.Forms.Timer(this.components);
            this.buttonXMinus = new System.Windows.Forms.Button();
            this.buttonXPlus = new System.Windows.Forms.Button();
            this.buttonYMinus = new System.Windows.Forms.Button();
            this.buttonYPlus = new System.Windows.Forms.Button();
            this.buttonZMinus = new System.Windows.Forms.Button();
            this.buttonZPlus = new System.Windows.Forms.Button();
            this.buttonRolMaxZ = new System.Windows.Forms.Button();
            this.buttonRolMinZ = new System.Windows.Forms.Button();
            this.buttonRolMaxY = new System.Windows.Forms.Button();
            this.buttonRolMinY = new System.Windows.Forms.Button();
            this.buttonRolMaxX = new System.Windows.Forms.Button();
            this.buttonRolMinX = new System.Windows.Forms.Button();
            this.timerForAnimation = new System.Windows.Forms.Timer(this.components);
            this.maskedTextBoxAnimX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxAnimY = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxAnimZ = new System.Windows.Forms.MaskedTextBox();
            this.сбросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOfScene)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стартToolStripMenuItem,
            this.стопToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.сбросToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // стартToolStripMenuItem
            // 
            this.стартToolStripMenuItem.Name = "стартToolStripMenuItem";
            this.стартToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.стартToolStripMenuItem.Text = "Старт";
            this.стартToolStripMenuItem.Click += new System.EventHandler(this.стартToolStripMenuItem_Click);
            // 
            // стопToolStripMenuItem
            // 
            this.стопToolStripMenuItem.Name = "стопToolStripMenuItem";
            this.стопToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.стопToolStripMenuItem.Text = "Стоп";
            this.стопToolStripMenuItem.Click += new System.EventHandler(this.стопToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.информацияToolStripMenuItem.Text = "Информация";
            this.информацияToolStripMenuItem.Click += new System.EventHandler(this.информацияToolStripMenuItem_Click_1);
            // 
            // labelMoveX
            // 
            this.labelMoveX.AutoSize = true;
            this.labelMoveX.Location = new System.Drawing.Point(424, 4);
            this.labelMoveX.Name = "labelMoveX";
            this.labelMoveX.Size = new System.Drawing.Size(14, 15);
            this.labelMoveX.TabIndex = 1;
            this.labelMoveX.Text = "X";
            // 
            // labelMoveY
            // 
            this.labelMoveY.AutoSize = true;
            this.labelMoveY.Location = new System.Drawing.Point(470, 4);
            this.labelMoveY.Name = "labelMoveY";
            this.labelMoveY.Size = new System.Drawing.Size(14, 15);
            this.labelMoveY.TabIndex = 2;
            this.labelMoveY.Text = "Y";
            // 
            // labelMoveZ
            // 
            this.labelMoveZ.AutoSize = true;
            this.labelMoveZ.Location = new System.Drawing.Point(515, 5);
            this.labelMoveZ.Name = "labelMoveZ";
            this.labelMoveZ.Size = new System.Drawing.Size(14, 15);
            this.labelMoveZ.TabIndex = 3;
            this.labelMoveZ.Text = "Z";
            // 
            // labelMoveTo
            // 
            this.labelMoveTo.AutoSize = true;
            this.labelMoveTo.Location = new System.Drawing.Point(318, 4);
            this.labelMoveTo.Name = "labelMoveTo";
            this.labelMoveTo.Size = new System.Drawing.Size(87, 15);
            this.labelMoveTo.TabIndex = 4;
            this.labelMoveTo.Text = "Перемещение";
            // 
            // maskedTextBoxMoveX
            // 
            this.maskedTextBoxMoveX.Location = new System.Drawing.Point(411, 22);
            this.maskedTextBoxMoveX.Name = "maskedTextBoxMoveX";
            this.maskedTextBoxMoveX.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBoxMoveX.TabIndex = 5;
            // 
            // maskedTextBoxMoveY
            // 
            this.maskedTextBoxMoveY.Location = new System.Drawing.Point(457, 22);
            this.maskedTextBoxMoveY.Name = "maskedTextBoxMoveY";
            this.maskedTextBoxMoveY.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBoxMoveY.TabIndex = 6;
            this.maskedTextBoxMoveY.ValidatingType = typeof(int);
            // 
            // maskedTextBoxMoveZ
            // 
            this.maskedTextBoxMoveZ.Location = new System.Drawing.Point(502, 22);
            this.maskedTextBoxMoveZ.Name = "maskedTextBoxMoveZ";
            this.maskedTextBoxMoveZ.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBoxMoveZ.TabIndex = 7;
            this.maskedTextBoxMoveZ.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Вращение";
            // 
            // labelRotX
            // 
            this.labelRotX.AutoSize = true;
            this.labelRotX.Location = new System.Drawing.Point(663, 4);
            this.labelRotX.Name = "labelRotX";
            this.labelRotX.Size = new System.Drawing.Size(14, 15);
            this.labelRotX.TabIndex = 9;
            this.labelRotX.Text = "X";
            // 
            // labelRotY
            // 
            this.labelRotY.AutoSize = true;
            this.labelRotY.Location = new System.Drawing.Point(707, 4);
            this.labelRotY.Name = "labelRotY";
            this.labelRotY.Size = new System.Drawing.Size(14, 15);
            this.labelRotY.TabIndex = 10;
            this.labelRotY.Text = "Y";
            // 
            // labelRotZ
            // 
            this.labelRotZ.AutoSize = true;
            this.labelRotZ.Location = new System.Drawing.Point(754, 5);
            this.labelRotZ.Name = "labelRotZ";
            this.labelRotZ.Size = new System.Drawing.Size(14, 15);
            this.labelRotZ.TabIndex = 11;
            this.labelRotZ.Text = "Z";
            // 
            // maskedTextBoxRotX
            // 
            this.maskedTextBoxRotX.Location = new System.Drawing.Point(651, 22);
            this.maskedTextBoxRotX.Name = "maskedTextBoxRotX";
            this.maskedTextBoxRotX.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBoxRotX.TabIndex = 12;
            this.maskedTextBoxRotX.ValidatingType = typeof(int);
            // 
            // maskedTextBoxRotY
            // 
            this.maskedTextBoxRotY.Location = new System.Drawing.Point(696, 21);
            this.maskedTextBoxRotY.Name = "maskedTextBoxRotY";
            this.maskedTextBoxRotY.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBoxRotY.TabIndex = 13;
            this.maskedTextBoxRotY.ValidatingType = typeof(int);
            // 
            // maskedTextBoxRotZ
            // 
            this.maskedTextBoxRotZ.Location = new System.Drawing.Point(741, 22);
            this.maskedTextBoxRotZ.Name = "maskedTextBoxRotZ";
            this.maskedTextBoxRotZ.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBoxRotZ.TabIndex = 14;
            this.maskedTextBoxRotZ.ValidatingType = typeof(int);
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(318, 21);
            this.buttonMove.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(90, 23);
            this.buttonMove.TabIndex = 15;
            this.buttonMove.Text = "Сдвинуть на";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRot
            // 
            this.buttonRot.Location = new System.Drawing.Point(547, 22);
            this.buttonRot.Name = "buttonRot";
            this.buttonRot.Size = new System.Drawing.Size(98, 23);
            this.buttonRot.TabIndex = 16;
            this.buttonRot.Text = "Повернуть на";
            this.buttonRot.UseVisualStyleBackColor = true;
            this.buttonRot.Click += new System.EventHandler(this.buttonRot_Click);
            // 
            // pictureBoxOfScene
            // 
            this.pictureBoxOfScene.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxOfScene.Location = new System.Drawing.Point(0, 56);
            this.pictureBoxOfScene.Name = "pictureBoxOfScene";
            this.pictureBoxOfScene.Size = new System.Drawing.Size(800, 500);
            this.pictureBoxOfScene.TabIndex = 17;
            this.pictureBoxOfScene.TabStop = false;
            // 
            // timerOfPainting
            // 
            this.timerOfPainting.Interval = 20;
            this.timerOfPainting.Tick += new System.EventHandler(this.timerPainting_Tick);
            // 
            // buttonXMinus
            // 
            this.buttonXMinus.Location = new System.Drawing.Point(411, 5);
            this.buttonXMinus.Name = "buttonXMinus";
            this.buttonXMinus.Size = new System.Drawing.Size(17, 19);
            this.buttonXMinus.TabIndex = 19;
            this.buttonXMinus.Text = "-";
            this.buttonXMinus.UseVisualStyleBackColor = true;
            this.buttonXMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXMinus_MouseDown);
            this.buttonXMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXMinus_MouseUp);
            // 
            // buttonXPlus
            // 
            this.buttonXPlus.Location = new System.Drawing.Point(434, 5);
            this.buttonXPlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonXPlus.Name = "buttonXPlus";
            this.buttonXPlus.Size = new System.Drawing.Size(16, 20);
            this.buttonXPlus.TabIndex = 20;
            this.buttonXPlus.Text = "+";
            this.buttonXPlus.UseVisualStyleBackColor = true;
            this.buttonXPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonXPlus_MouseDown);
            this.buttonXPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonXPlus_MouseUp);
            // 
            // buttonYMinus
            // 
            this.buttonYMinus.Location = new System.Drawing.Point(456, 5);
            this.buttonYMinus.Name = "buttonYMinus";
            this.buttonYMinus.Size = new System.Drawing.Size(16, 20);
            this.buttonYMinus.TabIndex = 21;
            this.buttonYMinus.Text = "-";
            this.buttonYMinus.UseVisualStyleBackColor = true;
            this.buttonYMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonYMinus_MouseDown);
            this.buttonYMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonYMinus_MouseUp);
            // 
            // buttonYPlus
            // 
            this.buttonYPlus.Location = new System.Drawing.Point(480, 5);
            this.buttonYPlus.Name = "buttonYPlus";
            this.buttonYPlus.Size = new System.Drawing.Size(16, 20);
            this.buttonYPlus.TabIndex = 22;
            this.buttonYPlus.Text = "+";
            this.buttonYPlus.UseVisualStyleBackColor = true;
            this.buttonYPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonYPlus_MouseDown);
            this.buttonYPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonYPlus_MouseUp);
            // 
            // buttonZMinus
            // 
            this.buttonZMinus.Location = new System.Drawing.Point(502, 5);
            this.buttonZMinus.Name = "buttonZMinus";
            this.buttonZMinus.Size = new System.Drawing.Size(16, 20);
            this.buttonZMinus.TabIndex = 23;
            this.buttonZMinus.Text = "-";
            this.buttonZMinus.UseVisualStyleBackColor = true;
            this.buttonZMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZMinus_MouseDown);
            this.buttonZMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonZMinus_MouseUp);
            // 
            // buttonZPlus
            // 
            this.buttonZPlus.Location = new System.Drawing.Point(525, 5);
            this.buttonZPlus.Name = "buttonZPlus";
            this.buttonZPlus.Size = new System.Drawing.Size(16, 20);
            this.buttonZPlus.TabIndex = 24;
            this.buttonZPlus.Text = "+";
            this.buttonZPlus.UseVisualStyleBackColor = true;
            this.buttonZPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZPlus_MouseDown);
            this.buttonZPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonZPlus_MouseUp);
            // 
            // buttonRolMaxZ
            // 
            this.buttonRolMaxZ.Location = new System.Drawing.Point(764, 5);
            this.buttonRolMaxZ.Name = "buttonRolMaxZ";
            this.buttonRolMaxZ.Size = new System.Drawing.Size(16, 20);
            this.buttonRolMaxZ.TabIndex = 30;
            this.buttonRolMaxZ.Text = "+";
            this.buttonRolMaxZ.UseVisualStyleBackColor = true;
            this.buttonRolMaxZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRolMaxZ_MouseDown);
            this.buttonRolMaxZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRolMaxZ_MouseUp);
            // 
            // buttonRolMinZ
            // 
            this.buttonRolMinZ.Location = new System.Drawing.Point(741, 5);
            this.buttonRolMinZ.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRolMinZ.Name = "buttonRolMinZ";
            this.buttonRolMinZ.Size = new System.Drawing.Size(16, 20);
            this.buttonRolMinZ.TabIndex = 29;
            this.buttonRolMinZ.Text = "-";
            this.buttonRolMinZ.UseVisualStyleBackColor = true;
            this.buttonRolMinZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRolMinZ_MouseDown);
            this.buttonRolMinZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRolMinZ_MouseUp);
            // 
            // buttonRolMaxY
            // 
            this.buttonRolMaxY.Location = new System.Drawing.Point(717, 5);
            this.buttonRolMaxY.Name = "buttonRolMaxY";
            this.buttonRolMaxY.Size = new System.Drawing.Size(16, 20);
            this.buttonRolMaxY.TabIndex = 28;
            this.buttonRolMaxY.Text = "+";
            this.buttonRolMaxY.UseVisualStyleBackColor = true;
            this.buttonRolMaxY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRolMaxY_MouseDown);
            this.buttonRolMaxY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRolMaxY_MouseUp);
            // 
            // buttonRolMinY
            // 
            this.buttonRolMinY.Location = new System.Drawing.Point(694, 5);
            this.buttonRolMinY.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRolMinY.Name = "buttonRolMinY";
            this.buttonRolMinY.Size = new System.Drawing.Size(16, 20);
            this.buttonRolMinY.TabIndex = 27;
            this.buttonRolMinY.Text = "-";
            this.buttonRolMinY.UseVisualStyleBackColor = true;
            this.buttonRolMinY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRolMinY_MouseDown);
            this.buttonRolMinY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRolMinY_MouseUp);
            // 
            // buttonRolMaxX
            // 
            this.buttonRolMaxX.Location = new System.Drawing.Point(674, 5);
            this.buttonRolMaxX.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRolMaxX.Name = "buttonRolMaxX";
            this.buttonRolMaxX.Size = new System.Drawing.Size(16, 20);
            this.buttonRolMaxX.TabIndex = 26;
            this.buttonRolMaxX.Text = "+";
            this.buttonRolMaxX.UseVisualStyleBackColor = true;
            this.buttonRolMaxX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRolMaxX_MouseDown);
            this.buttonRolMaxX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRolMaxX_MouseUp);
            // 
            // buttonRolMinX
            // 
            this.buttonRolMinX.Location = new System.Drawing.Point(650, 5);
            this.buttonRolMinX.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRolMinX.Name = "buttonRolMinX";
            this.buttonRolMinX.Size = new System.Drawing.Size(16, 20);
            this.buttonRolMinX.TabIndex = 25;
            this.buttonRolMinX.Text = "-";
            this.buttonRolMinX.UseVisualStyleBackColor = true;
            this.buttonRolMinX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRolMinX_MouseDown);
            this.buttonRolMinX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRolMinX_MouseUp);
            // 
            // timerForAnimation
            // 
            this.timerForAnimation.Interval = 20;
            this.timerForAnimation.Tick += new System.EventHandler(this.timerForAnimation_Tick);
            // 
            // maskedTextBoxAnimX
            // 
            this.maskedTextBoxAnimX.Location = new System.Drawing.Point(169, 26);
            this.maskedTextBoxAnimX.Name = "maskedTextBoxAnimX";
            this.maskedTextBoxAnimX.Size = new System.Drawing.Size(40, 23);
            this.maskedTextBoxAnimX.TabIndex = 31;
            // 
            // maskedTextBoxAnimY
            // 
            this.maskedTextBoxAnimY.Location = new System.Drawing.Point(224, 26);
            this.maskedTextBoxAnimY.Name = "maskedTextBoxAnimY";
            this.maskedTextBoxAnimY.Size = new System.Drawing.Size(36, 23);
            this.maskedTextBoxAnimY.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Точка анимации, (X , Y, Z) ";
            // 
            // maskedTextBoxAnimZ
            // 
            this.maskedTextBoxAnimZ.Location = new System.Drawing.Point(273, 26);
            this.maskedTextBoxAnimZ.Name = "maskedTextBoxAnimZ";
            this.maskedTextBoxAnimZ.Size = new System.Drawing.Size(39, 23);
            this.maskedTextBoxAnimZ.TabIndex = 35;
            // 
            // сбросToolStripMenuItem
            // 
            this.сбросToolStripMenuItem.Name = "сбросToolStripMenuItem";
            this.сбросToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.сбросToolStripMenuItem.Text = "     Сброс";
            this.сбросToolStripMenuItem.Click += new System.EventHandler(this.сбросToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 570);
            this.Controls.Add(this.maskedTextBoxAnimZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBoxAnimY);
            this.Controls.Add(this.maskedTextBoxAnimX);
            this.Controls.Add(this.buttonRolMaxZ);
            this.Controls.Add(this.buttonRolMinZ);
            this.Controls.Add(this.buttonRolMaxY);
            this.Controls.Add(this.buttonRolMinY);
            this.Controls.Add(this.buttonRolMaxX);
            this.Controls.Add(this.buttonRolMinX);
            this.Controls.Add(this.buttonZPlus);
            this.Controls.Add(this.buttonZMinus);
            this.Controls.Add(this.buttonYPlus);
            this.Controls.Add(this.buttonYMinus);
            this.Controls.Add(this.buttonXPlus);
            this.Controls.Add(this.buttonXMinus);
            this.Controls.Add(this.pictureBoxOfScene);
            this.Controls.Add(this.buttonRot);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.maskedTextBoxRotZ);
            this.Controls.Add(this.maskedTextBoxRotY);
            this.Controls.Add(this.maskedTextBoxRotX);
            this.Controls.Add(this.labelRotZ);
            this.Controls.Add(this.labelRotY);
            this.Controls.Add(this.labelRotX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBoxMoveZ);
            this.Controls.Add(this.maskedTextBoxMoveY);
            this.Controls.Add(this.maskedTextBoxMoveX);
            this.Controls.Add(this.labelMoveTo);
            this.Controls.Add(this.labelMoveZ);
            this.Controls.Add(this.labelMoveY);
            this.Controls.Add(this.labelMoveX);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Лабораторная работа №1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOfScene)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem стартToolStripMenuItem;
        private System.Windows.Forms.Label labelMoveX;
        private System.Windows.Forms.Label labelMoveY;
        private System.Windows.Forms.Label labelMoveZ;
        private System.Windows.Forms.Label labelMoveTo;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMoveX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMoveY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMoveZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRotX;
        private System.Windows.Forms.Label labelRotY;
        private System.Windows.Forms.Label labelRotZ;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRotX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRotY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRotZ;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonRot;
        private System.Windows.Forms.PictureBox pictureBoxOfScene;
        private System.Windows.Forms.Timer timerOfPainting;
        private System.Windows.Forms.ToolStripMenuItem стопToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.Button buttonXMinus;
        private System.Windows.Forms.Button buttonXPlus;
        private System.Windows.Forms.Button buttonYMinus;
        private System.Windows.Forms.Button buttonYPlus;
        private System.Windows.Forms.Button buttonZMinus;
        private System.Windows.Forms.Button buttonZPlus;
        private System.Windows.Forms.Button buttonRolMaxZ;
        private System.Windows.Forms.Button buttonRolMinZ;
        private System.Windows.Forms.Button buttonRolMaxY;
        private System.Windows.Forms.Button buttonRolMinY;
        private System.Windows.Forms.Button buttonRolMaxX;
        private System.Windows.Forms.Button buttonRolMinX;
        private System.Windows.Forms.Timer timerForAnimation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAnimY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAnimX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAnimZ;
        private System.Windows.Forms.ToolStripMenuItem сбросToolStripMenuItem;
    }
}

