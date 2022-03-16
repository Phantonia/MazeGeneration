namespace Phantonia.MazeGeneration.UI
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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textboxWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxHeight = new System.Windows.Forms.TextBox();
            this.pictureboxVisuals = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxSeed = new System.Windows.Forms.TextBox();
            this.buttonRandomSeed = new System.Windows.Forms.Button();
            this.updownCycleNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxVisuals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownCycleNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(11, 17);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(111, 38);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            // 
            // textboxWidth
            // 
            this.textboxWidth.Location = new System.Drawing.Point(378, 21);
            this.textboxWidth.Name = "textboxWidth";
            this.textboxWidth.Size = new System.Drawing.Size(150, 31);
            this.textboxWidth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // textboxHeight
            // 
            this.textboxHeight.Location = new System.Drawing.Point(605, 21);
            this.textboxHeight.Name = "textboxHeight";
            this.textboxHeight.Size = new System.Drawing.Size(150, 31);
            this.textboxHeight.TabIndex = 4;
            // 
            // pictureboxVisuals
            // 
            this.pictureboxVisuals.Location = new System.Drawing.Point(11, 73);
            this.pictureboxVisuals.Name = "pictureboxVisuals";
            this.pictureboxVisuals.Size = new System.Drawing.Size(1406, 658);
            this.pictureboxVisuals.TabIndex = 6;
            this.pictureboxVisuals.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1104, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seed";
            // 
            // textboxSeed
            // 
            this.textboxSeed.Location = new System.Drawing.Point(1163, 22);
            this.textboxSeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textboxSeed.Name = "textboxSeed";
            this.textboxSeed.Size = new System.Drawing.Size(141, 31);
            this.textboxSeed.TabIndex = 8;
            // 
            // buttonRandomSeed
            // 
            this.buttonRandomSeed.Location = new System.Drawing.Point(128, 17);
            this.buttonRandomSeed.Name = "buttonRandomSeed";
            this.buttonRandomSeed.Size = new System.Drawing.Size(178, 38);
            this.buttonRandomSeed.TabIndex = 9;
            this.buttonRandomSeed.Text = "Get random seed";
            this.buttonRandomSeed.UseVisualStyleBackColor = true;
            // 
            // updownCycleNumber
            // 
            this.updownCycleNumber.Location = new System.Drawing.Point(917, 21);
            this.updownCycleNumber.Name = "updownCycleNumber";
            this.updownCycleNumber.Size = new System.Drawing.Size(180, 31);
            this.updownCycleNumber.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(761, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Number of cycles";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 743);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.updownCycleNumber);
            this.Controls.Add(this.buttonRandomSeed);
            this.Controls.Add(this.textboxSeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureboxVisuals);
            this.Controls.Add(this.textboxHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxWidth);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "MainForm";
            this.Text = "Maze generation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxVisuals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownCycleNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonGenerate;
        private TextBox textboxWidth;
        private Label label1;
        private Label label2;
        private TextBox textboxHeight;
        private PictureBox pictureboxVisuals;
        private Label label3;
        private TextBox textboxSeed;
        private Button buttonRandomSeed;
        private NumericUpDown updownCycleNumber;
        private Label label4;
    }
}