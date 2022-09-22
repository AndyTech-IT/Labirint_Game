using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint_Game
{
    class Labirint
    {
        private OpenFileDialog _load_dialog;
        private SaveFileDialog _save_dialog;
        private Random _random;

        private PictureBox _canvas;
        private Bitmap _map_layer;

        private const int _cel_size = 50;
        private const int _border_size = 4;
        private const int _player_padding = 4;

        private Wall[][] _map;
        private bool[][] _visits_map;
        private Size _map_size;
        private Size _screen_size;

        private Point _start_point;
        private Point _finish_point;
        private Point _player_position;

        private bool _is_inited;
        private bool _victory;

        public bool Is_Ready => _is_inited;
        public bool Is_Victory => _victory;
        public Size Size => _screen_size;

        public Point Game_To_Screen_Cords(Point game_cords) => new Point(
            game_cords.X * (_cel_size + _border_size) + _border_size / 2,
            game_cords.Y * (_cel_size + _border_size) + _border_size / 2);

        public Point Game_To_Screen_Cords(int row, int col) => Game_To_Screen_Cords(new Point(row, col));

        public int Cels_Visited
        {
            get
            {
                int result = 0;
                for (int i = 0; i < _screen_size.Height; i++)
                    for (int j = 0; j < _screen_size.Width; j++)
                    {
                        if (_visits_map[i][j])
                            result++;
                    }
                return result;
            }
        }

        public Labirint(PictureBox canvas)
        {
            _load_dialog = new OpenFileDialog();
            _save_dialog = new SaveFileDialog();
            _canvas = canvas;
            _is_inited = false;
        }

        public void Start(int width, int height)
        {
            width++;
            height++;
            _map = new Wall[height][];
            for (int i = 0; i < height; i++)
            {
                _map[i] = new Wall[width];
                for (int j = 0; j < width; j++)
                {
                    _map[i][j] = new Wall();
                }
            }
            _random = new Random();

            _visits_map = new bool[height][];
            for (int i = 0; i < height; i++)
            {
                _visits_map[i] = new bool[width];
            }
            _map_size = new Size(width, height);
            _screen_size = new Size(width - 1, height - 1);

            Clear_Visiting();

            Point edge_point = Game_To_Screen_Cords(_screen_size.Width, _screen_size.Height);
            Size layer_size = new Size(edge_point.X + _border_size / 2, edge_point.Y + _border_size / 2);

            _canvas.Size = layer_size;
            _map_layer = new Bitmap(layer_size.Width, layer_size.Height);
            _canvas.Image = new Bitmap(layer_size.Width, layer_size.Height);

            _is_inited = false;
            _victory = false;

            new Thread(GenerateMap).Start();
        }

        public Move_Result Move(Move_Dir direction, bool generation = false)
        {
            if (_is_inited == false && generation == false)
                throw new Exception("Labirint is not inited!");

            switch (direction)
            {
                case Move_Dir.Top:
                    if (_player_position.Y <= 0)
                    {
                        return Move_Result.Edge;
                    }
                    if (_map[_player_position.Y][_player_position.X].Top)
                    {
                        return Move_Result.Border;
                    }
                    _player_position.Y--;
                    break;
                case Move_Dir.Right:
                    if (_player_position.X >= _screen_size.Width - 1)
                    {
                        return Move_Result.Edge;
                    }
                    if (_map[_player_position.Y][_player_position.X + 1].Left)
                    {
                        return Move_Result.Border;
                    }
                    _player_position.X++;
                    break;
                case Move_Dir.Down:
                    if (_player_position.Y >= _screen_size.Height - 1)
                    {
                        return Move_Result.Edge;
                    }
                    if (_map[_player_position.Y + 1][_player_position.X].Top)
                    {
                        return Move_Result.Border;
                    }
                    _player_position.Y++;
                    break;
                case Move_Dir.Left:
                    if (_player_position.X <= 0)
                    {
                        return Move_Result.Edge;
                    }
                    if (_map[_player_position.Y][_player_position.X].Left)
                    {
                        return Move_Result.Border;
                    }
                    _player_position.X--;
                    break;
            }
            _visits_map[_player_position.Y][_player_position.X] = true;
            if (generation == false)
                Update();
            if (_player_position == _finish_point)
            {
                _victory = true;
                return Move_Result.Finish;
            }
            if (_player_position == _start_point)
                return Move_Result.Start;
            return Move_Result.Sucess;
        }

        public void Restart()
        {
            if (_is_inited == false)
                throw new Exception("Labirint is not inited!");
            _player_position = _start_point;
            _victory = false;
            Update();
        }

        private void Clear_Visiting()
        {
            for (int i = 0; i < _map_size.Height; i++)
                for (int j = 0; j < _map_size.Width; j++)
                {
                    _visits_map[i][j] = false;
                }
        }

        private void Update()
        {
            using (var g = Graphics.FromImage(_canvas.Image))
            {
                g.DrawImage(_map_layer, Point.Empty);

                SolidBrush b = new SolidBrush(Color.Blue);

                Point p_start = Game_To_Screen_Cords(_player_position);
                Point start = new Point(p_start.X + _player_padding + _border_size / 2, p_start.Y + _player_padding + _border_size / 2);
                Rectangle p_rect = new Rectangle(start, new Size(_cel_size - _player_padding * 2, _cel_size - _player_padding * 2));
                g.FillRectangle(b, p_rect);
                g.DrawRectangle(new Pen(Color.Black, _border_size), p_rect);
            }
            _canvas.Invoke((MethodInvoker)(() => _canvas.Refresh()));

        }

        private Move_Dir Get_RandomDir(Move_Dir[] exist = null)
        {
            Move_Dir[] choise = new Move_Dir[] { Move_Dir.Top, Move_Dir.Right, Move_Dir.Down, Move_Dir.Left }.Where(d => exist.Contains(d) == false).ToArray();
            return choise[_random.Next(0, choise.Length)];
        }

        private bool Get_Next_Visited(Point cel, Move_Dir enter_direction)
        {
            switch (enter_direction)
            {
                case Move_Dir.Top:
                    return _visits_map[cel.Y - 1][cel.X];
                case Move_Dir.Right:
                    return _visits_map[cel.Y][cel.X + 1];
                case Move_Dir.Down:
                    return _visits_map[cel.Y + 1][cel.X];
                case Move_Dir.Left:
                    return _visits_map[cel.Y][cel.X - 1];
                default:
                    return false;
            }
        }

        private void Open_Wall(Point cel, Move_Dir wall_direction)
        {
            switch (wall_direction)
            {
                case Move_Dir.Top:
                    _map[cel.Y][cel.X].Top = false;
                    break;
                case Move_Dir.Right:
                    _map[cel.Y][cel.X + 1].Left = false;
                    break;
                case Move_Dir.Down:
                    _map[cel.Y + 1][cel.X].Top = false;
                    break;
                case Move_Dir.Left:
                    _map[cel.Y][cel.X].Left = false;
                    break;
            }
        }

        private void Move_Back(Move_Dir back_dir)
        {
            switch(back_dir)
            {
                case Move_Dir.Top:
                    _player_position.Y++;
                    break;
                case Move_Dir.Right:
                    _player_position.X--;
                    break;
                case Move_Dir.Down:
                    _player_position.Y--;
                    break;
                case Move_Dir.Left:
                    _player_position.X++;
                    break;
            }
        }

        private void Generate_With_RandomStack()
        {
            _start_point = new Point(0, 0);
            _visits_map[0][0] = true;
            _finish_point = new Point(_screen_size.Width - 1, _screen_size.Height - 1);
            _player_position = _start_point;
            Stack<Move_Dir> stac = new Stack<Move_Dir>();
            Move_Dir[] tryed = new Move_Dir[0];
            Point p = _start_point;
            bool first_step = true;
            try
            {
                while (true)
                {
                    Move_Dir dir = Get_RandomDir(tryed);
                    Point curent_pos = _player_position;
                    Move_Result result = Move(dir, true);
                    // Что там?
                    switch (result)
                    {
                        // Открываем стену и заходим
                        case Move_Result.Border:
                            // Мы там были?
                            if (Get_Next_Visited(curent_pos, dir))
                            {
                                tryed = tryed.Append(dir).ToArray();
                                if (_random.Next(50) == 0) { }
                                else
                                    break;
                            }
                            Open_Wall(_player_position, dir);
                            // Мы достигли финиш, идём назад
                            if (Move(dir, true) == Move_Result.Finish)
                            {
                                Move_Back(stac.Pop());
                            }
                            else
                            {
                                tryed = new Move_Dir[0];
                                stac.Push(dir);
                            }
                            first_step = false;
                            break;

                        // Мы там уже побывали, назад...
                        case Move_Result.Finish:
                            // Мы там были?
                            if (Get_Next_Visited(curent_pos, dir))
                            {
                                tryed = tryed.Append(dir).ToArray();
                                Move_Back(dir);
                                break;
                            }
                            throw new Exception("Finish not visited on generation WTF!");

                        // Туда ходу нет пробуем ещё...
                        case Move_Result.Edge:
                            tryed = tryed.Append(dir).ToArray();
                            break;

                        // Мы там уже были, назад!
                        case Move_Result.Start:
                            // Мы там были?
                            if (Get_Next_Visited(curent_pos, dir))
                            {
                                Move_Back(dir);
                                tryed = tryed.Append(dir).ToArray();
                                break;
                            }
                            throw new Exception("Start not visited on generation WTF!");
                        // Мы там уже были, назад!
                        case Move_Result.Sucess:
                            // Мы там были?
                            if (Get_Next_Visited(curent_pos, dir))
                            {
                                tryed = tryed.Append(dir).ToArray();
                                Move_Back(dir);
                                break;
                            }
                            throw new Exception($"Opend cel{curent_pos} not visited on generation WTF!");
                    }
                    // Мы всё проверили, назад!
                    if (tryed.Length == 4)
                    {
                        Move_Back(stac.Pop());
                        tryed = new Move_Dir[0];

                    }
                    // Мы везде побывали?
                    if (first_step == false && stac.Count == 0)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                _map[i][j].Left = false;
                                _map[i][j].Top = false;
                            }
                        }
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"{e.Message}\n{e.StackTrace}");
            }
        }

        private void GenerateMap()
        {
            Generate_With_RandomStack();

            {   // Clear top side
                int row = 0;
                for (int col = 0; col < _map_size.Width; col++)
                {
                    _map[row][col].Top = true;
                }

            }
            {   // Clear right side
                int col = _map_size.Width - 1;
                for (int row = 0; row < _map_size.Height; row++)
                {
                    _map[row][col].Top = false;
                    _map[row][col].Left = true;
                }
            }
            {   // Clear down side
                int row = _map_size.Height - 1;
                for (int col = 0; col < _map_size.Width; col++)
                {
                    _map[row][col].Top = true;
                    _map[row][col].Left = false;
                }
            }
            {   // Clear left side
                int col = 0;
                for (int row = 0; row < _map_size.Height; row++)
                {
                    _map[row][col].Left = true;
                }
            }
            Clear_Visiting();
            Draw_Background();
            Draw_Borders();

            _victory = false;
            _player_position = _start_point;
            _is_inited = true;
            Update();
        }

        private void Draw_Background()
        {
            Color[] bg_colors = new Color[] { Color.AliceBlue, Color.Aqua, Color.CadetBlue, Color.DarkCyan, Color.DarkGreen, Color.Magenta };
            using (var g = Graphics.FromImage(_map_layer))
            {
                g.Clear(bg_colors[_random.Next(bg_colors.Length)]);

                Point start_point = Game_To_Screen_Cords(_start_point);
                Point end_point = Game_To_Screen_Cords(_finish_point);
                g.FillRectangle(new SolidBrush(Color.Red), new Rectangle
                    (
                    start_point.X + _border_size/2, start_point.Y + _border_size/2,
                    _cel_size, _cel_size
                    ));
                g.FillRectangle(new SolidBrush(Color.Green), new Rectangle
                    (
                    end_point.X + _border_size/2, end_point.Y + _border_size/2,
                    _cel_size, _cel_size
                    ));
            }
        }

        private void Draw_Borders()
        {
            using (var g = Graphics.FromImage(_map_layer))
            {
                Pen p = new Pen(Color.Black, _border_size);
                for (int row = 0; row < _map_size.Height; row++)
                {
                    for (int col = 0; col < _map_size.Width; col++)
                    {
                        Wall wall = _map[row][col];
                        Point start = Game_To_Screen_Cords(new Point(col, row));
                        if (wall.Left)
                            g.DrawLine(p, start, new Point(start.X, start.Y + _cel_size + _border_size));

                        if (wall.Top)
                            g.DrawLine(p, start, new Point(start.X + _cel_size + _border_size, start.Y));
                    }
                }
            }
        }
    }
}
