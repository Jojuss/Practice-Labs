using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Game
{
    public partial class Form1 : Form
    {
        const int WIDTH = 5;
        const int HEIGHT = 10;

        Rectangle[,] blocks;
        int player_x;
        int player_y;
        int player_speed;

        int ball_x;
        int ball_y;
        int[] ball_speed = new int[] { 4, -4 };

        int score = 0;

        bool gameover = false;
        bool game_win = false;
        

        Bitmap bm;
        Graphics g;
        Timer movementTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
            gameoverlabel.Hide();
            win_label.Hide();

            blocks = new Rectangle[WIDTH, HEIGHT];
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++) blocks[i, j] = new Rectangle(i * (pictureBox1.Width / WIDTH), j * 20, pictureBox1.Width / WIDTH - 2, 18);
            }
            player_x = 200;
            player_y = 700;
            ball_x = 200;
            ball_y = 650;

            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            this.KeyDown += new KeyEventHandler(processInputDown);
            this.KeyUp += new KeyEventHandler(processInputUp);

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(timerUpdate);
            timer1.Enabled = true;

            movementTimer.Interval = 10;
            movementTimer.Tick += new EventHandler(movementTick);
        }



        private void DrawEverything()
        {
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++) g.FillRectangle(Brushes.Gray, blocks[i, j]);
            }
            g.FillRectangle(Brushes.Black, new Rectangle(player_x, player_y, 100, 20));
            g.FillEllipse(Brushes.Black, new Rectangle(ball_x, ball_y, 20, 20));
            pictureBox1.Image = bm;
            scorelabel.Text = "Score: " + score;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkCollisions()
        {
            //Walls
            if (ball_x + ball_speed[0] + 20 > pictureBox1.Width || ball_x + ball_speed[0] < 0) ball_speed[0] *= -1;
            if (ball_y + ball_speed[1] < 0) ball_speed[1] *= -1;
            if (ball_y + ball_speed[1] > 740) gameover = true;

            //Player
            if ((player_y - ball_y) < 20 && ball_x + 10 < player_x + 100 && ball_x + 10 > player_x) ball_speed[1] *= -1;

            //Blocks
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    if (blocks[i, j] != null && ball_x + 10 > blocks[i, j].X && ball_x + 10 < blocks[i, j].X + blocks[i, j].Width && Math.Abs(ball_y - blocks[i, j].Y) < 10)
                    {
                        blocks[i, j] = Rectangle.Empty;
                        ball_speed[1] *= -1;
                        score += 50;
                    }
                }
            }

            ball_x += ball_speed[0];
            ball_y += ball_speed[1];
        }

        private void checkWin()
        {
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++) if (blocks[i, j] != Rectangle.Empty) return;
            }
            game_win = true;
        }

        private void timerUpdate(object sender, EventArgs e)
        {
            if (!gameover && !game_win)
            {
                checkCollisions();
                checkWin();
                DrawEverything();
            }
            else if (gameover)
            {
                gameoverlabel.Show();
            }
            else
            {
                win_label.Show();
            }
        }

        private void movementTick(object sender, EventArgs e) 
        {
            if (!gameover)
            {
                if (!(player_x + player_speed + 100 > pictureBox1.Width) && !(player_x + player_speed < 0))
                    player_x += player_speed;
                DrawEverything();
            }
        }
        
        private void processInputDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                player_speed = -5;
            }
            if (e.KeyCode == Keys.D)
            {
                player_speed = +5;
            }

            if ((gameover || game_win) && e.KeyCode == Keys.R)
            {
                ball_x = 200;
                ball_y = 650;
                score = 0;
                for (int i = 0; i < WIDTH; i++)
                {
                    for (int j = 0; j < HEIGHT; j++) blocks[i, j] = new Rectangle(i * (pictureBox1.Width / WIDTH), j * 20, pictureBox1.Width / WIDTH - 2, 18);
                }
                gameover = false;
                game_win = false;
                gameoverlabel.Hide();
                win_label.Hide();
                ball_speed = new int[] { 4, -4 };
            }

            UpdateTimer();
            DrawEverything();
        }

        private void processInputUp(object sender, KeyEventArgs e)
        {
            player_speed = 0;
            UpdateTimer();
            DrawEverything();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawEverything();
        }

        private void UpdateTimer()
        {
            movementTimer.Enabled = player_speed != 0;
        }

        private void gameoverlabel_Click(object sender, EventArgs e)
        {

        }
    }
}
