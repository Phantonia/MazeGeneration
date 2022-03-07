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
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxVisuals)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(8, 10);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(78, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            // 
            // textboxWidth
            // 
            this.textboxWidth.Location = new System.Drawing.Point(137, 10);
            this.textboxWidth.Margin = new System.Windows.Forms.Padding(2);
            this.textboxWidth.Name = "textboxWidth";
            this.textboxWidth.Size = new System.Drawing.Size(106, 23);
            this.textboxWidth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // textboxHeight
            // 
            this.textboxHeight.Location = new System.Drawing.Point(296, 10);
            this.textboxHeight.Margin = new System.Windows.Forms.Padding(2);
            this.textboxHeight.Name = "textboxHeight";
            this.textboxHeight.Size = new System.Drawing.Size(106, 23);
            this.textboxHeight.TabIndex = 4;
            // 
            // pictureboxVisuals
            // 
            this.pictureboxVisuals.Location = new System.Drawing.Point(8, 44);
            this.pictureboxVisuals.Margin = new System.Windows.Forms.Padding(2);
            this.pictureboxVisuals.Name = "pictureboxVisuals";
            this.pictureboxVisuals.Size = new System.Drawing.Size(808, 395);
            this.pictureboxVisuals.TabIndex = 6;
            this.pictureboxVisuals.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seed";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(445, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 446);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureboxVisuals);
            this.Controls.Add(this.textboxHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxWidth);
            this.Controls.Add(this.buttonGenerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Maze generation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxVisuals)).EndInit();
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
        private TextBox textBox1;
    }
}