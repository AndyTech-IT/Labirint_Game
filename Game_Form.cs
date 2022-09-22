using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint_Game
{
    public partial class Game_Form : Form
    {
        Labirint _labirint;
        SelectSize_Form _size_dialog;
        Congratulation_Form _congratulation_dialog;
        int _score;

        public Game_Form()
        {
            InitializeComponent();
            _size_dialog = new SelectSize_Form();
            _congratulation_dialog = new Congratulation_Form();
            _labirint = new Labirint(Labirint_PB);
            Size = new Size(1024, 720);
            _score = 0;
            Result_TB.Text = "Результат: 0";
        }

        private void NewGame_TSMI_Click(object sender, EventArgs e)
        {
            if (_size_dialog.ShowDialog() == DialogResult.OK)
            {
                _labirint.Start(_size_dialog.Result.Width, _size_dialog.Result.Height);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_labirint.Is_Ready == false)
                return;

            Move_Dir direction;
            switch(e.KeyChar)
            {
                case 'w':
                case 'W':
                case 'ц':
                case 'Ц':
                        direction = Move_Dir.Top;
                    break;

                case 'd':
                case 'D':
                case 'в':
                case 'В':
                    direction = Move_Dir.Right;
                    break;

                case 's':
                case 'S':
                case 'ы':
                case 'Ы':
                    direction = Move_Dir.Down;
                    break;

                case 'a':
                case 'A':
                case 'ф':
                case 'Ф':
                    direction = Move_Dir.Left;
                    break;
                default:
                    return;
            }
            _labirint.Move(direction);
            if (_labirint.Is_Victory)
            {
                _score += _labirint.Size.Width * _labirint.Size.Height / 10;
                Result_TB.Text = $"Результат: {_score}";
                DialogResult resut = _congratulation_dialog.ShowDialog();
                switch(resut)
                {
                    case DialogResult.OK:
                        NewGame_TSMI_Click(sender, e);
                        break;
                    case DialogResult.Retry:
                        _labirint.Restart();
                        break;
                    case DialogResult.Abort:
                        Close();
                        break;
                }
            }
        }

        private void RestartGame_TSMI_Click(object sender, EventArgs e)
        {
            if (_labirint.Is_Ready)
                _labirint.Restart();
        }
    }
}
