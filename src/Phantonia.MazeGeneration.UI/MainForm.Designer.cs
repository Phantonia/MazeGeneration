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
            this.comboboxDrawKind = new System.Windows.Forms.ComboBox();
            this.pictureboxVisuals = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxVisuals)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(12, 16);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(112, 34);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            // 
            // textboxWidth
            // 
            this.textboxWidth.Location = new System.Drawing.Point(196, 16);
            this.textboxWidth.Name = "textboxWidth";
            this.textboxWidth.Size = new System.Drawing.Size(150, 31);
            this.textboxWidth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // textboxHeight
            // 
            this.textboxHeight.Location = new System.Drawing.Point(423, 16);
            this.textboxHeight.Name = "textboxHeight";
            this.textboxHeight.Size = new System.Drawing.Size(150, 31);
            this.textboxHeight.TabIndex = 4;
            // 
            // comboboxDrawKind
            // 
            this.comboboxDrawKind.FormattingEnabled = true;
            this.comboboxDrawKind.Items.AddRange(new object[] {
            "Maze",
            "Graph"});
            this.comboboxDrawKind.Location = new System.Drawing.Point(591, 14);
            this.comboboxDrawKind.Name = "comboboxDrawKind";
            this.comboboxDrawKind.Size = new System.Drawing.Size(182, 33);
            this.comboboxDrawKind.TabIndex = 5;
            // 
            // pictureboxVisuals
            // 
            this.pictureboxVisuals.Location = new System.Drawing.Point(12, 74);
            this.pictureboxVisuals.Name = "pictureboxVisuals";
            this.pictureboxVisuals.Size = new System.Drawing.Size(1154, 658);
            this.pictureboxVisuals.TabIndex = 6;
            this.pictureboxVisuals.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.pictureboxVisuals);
            this.Controls.Add(this.comboboxDrawKind);
            this.Controls.Add(this.textboxHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxWidth);
            this.Controls.Add(this.buttonGenerate);
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
        private ComboBox comboboxDrawKind;
        private PictureBox pictureboxVisuals;
    }
}