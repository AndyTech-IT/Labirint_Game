
namespace Labirint_Game
{
    partial class Game_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Labirint_PB = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGame_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartGame_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Result_TB = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Labirint_PB)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Labirint_PB
            // 
            this.Labirint_PB.Location = new System.Drawing.Point(0, 0);
            this.Labirint_PB.Name = "Labirint_PB";
            this.Labirint_PB.Size = new System.Drawing.Size(642, 305);
            this.Labirint_PB.TabIndex = 0;
            this.Labirint_PB.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.Result_TB});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame_TSMI,
            this.RestartGame_TSMI});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // NewGame_TSMI
            // 
            this.NewGame_TSMI.Name = "NewGame_TSMI";
            this.NewGame_TSMI.Size = new System.Drawing.Size(110, 22);
            this.NewGame_TSMI.Text = "New";
            this.NewGame_TSMI.Click += new System.EventHandler(this.NewGame_TSMI_Click);
            // 
            // RestartGame_TSMI
            // 
            this.RestartGame_TSMI.Name = "RestartGame_TSMI";
            this.RestartGame_TSMI.Size = new System.Drawing.Size(110, 22);
            this.RestartGame_TSMI.Text = "Restart";
            this.RestartGame_TSMI.Click += new System.EventHandler(this.RestartGame_TSMI_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Labirint_PB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 425);
            this.panel1.TabIndex = 3;
            // 
            // Result_TB
            // 
            this.Result_TB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Result_TB.Name = "Result_TB";
            this.Result_TB.ReadOnly = true;
            this.Result_TB.Size = new System.Drawing.Size(100, 23);
            // 
            // Game_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Game_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабиринт";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Labirint_PB)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Labirint_PB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewGame_TSMI;
        private System.Windows.Forms.ToolStripMenuItem RestartGame_TSMI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripTextBox Result_TB;
    }
}

