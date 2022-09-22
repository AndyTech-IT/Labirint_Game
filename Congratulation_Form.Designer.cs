
namespace Labirint_Game
{
    partial class Congratulation_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Rety_Button = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Next_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(148, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вы выбрались из лабиринта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(190, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Куда пойдёте дальше?";
            // 
            // Rety_Button
            // 
            this.Rety_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rety_Button.Location = new System.Drawing.Point(106, 200);
            this.Rety_Button.Name = "Rety_Button";
            this.Rety_Button.Size = new System.Drawing.Size(100, 30);
            this.Rety_Button.TabIndex = 2;
            this.Rety_Button.Text = "Повторить";
            this.Rety_Button.UseVisualStyleBackColor = true;
            this.Rety_Button.Click += new System.EventHandler(this.Rety_Button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit_Button.Location = new System.Drawing.Point(277, 200);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(100, 30);
            this.Exit_Button.TabIndex = 3;
            this.Exit_Button.Text = "Выйти";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Next_Button
            // 
            this.Next_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next_Button.Location = new System.Drawing.Point(448, 200);
            this.Next_Button.Name = "Next_Button";
            this.Next_Button.Size = new System.Drawing.Size(100, 30);
            this.Next_Button.TabIndex = 4;
            this.Next_Button.Text = "Далее";
            this.Next_Button.UseVisualStyleBackColor = true;
            this.Next_Button.Click += new System.EventHandler(this.Next_Button_Click);
            // 
            // Congratulation_Form
            // 
            this.AcceptButton = this.Next_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Exit_Button;
            this.ClientSize = new System.Drawing.Size(607, 275);
            this.Controls.Add(this.Next_Button);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Rety_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Congratulation_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Победа";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Congratulation_Form_FormClosing);
            this.Shown += new System.EventHandler(this.Congratulation_Form_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Rety_Button;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button Next_Button;
    }
}