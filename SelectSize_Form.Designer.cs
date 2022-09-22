
namespace Labirint_Game
{
    partial class SelectSize_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Height_NUD = new System.Windows.Forms.NumericUpDown();
            this.Width_NUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Height_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // Height_NUD
            // 
            this.Height_NUD.Location = new System.Drawing.Point(143, 61);
            this.Height_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Height_NUD.Name = "Height_NUD";
            this.Height_NUD.Size = new System.Drawing.Size(120, 20);
            this.Height_NUD.TabIndex = 0;
            this.Height_NUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Width_NUD
            // 
            this.Width_NUD.Location = new System.Drawing.Point(143, 142);
            this.Width_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Width_NUD.Name = "Width_NUD";
            this.Width_NUD.Size = new System.Drawing.Size(120, 20);
            this.Width_NUD.TabIndex = 1;
            this.Width_NUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Высота";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ширина";
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(169, 226);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 4;
            this.OK_Button.Text = "ОК";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Введите размер";
            // 
            // SelectSize_Form
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Width_NUD);
            this.Controls.Add(this.Height_NUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectSize_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Size selecting";
            ((System.ComponentModel.ISupportInitialize)(this.Height_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Width_NUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Height_NUD;
        private System.Windows.Forms.NumericUpDown Width_NUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label label3;
    }
}