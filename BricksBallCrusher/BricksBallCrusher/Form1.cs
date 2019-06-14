using BricksBallCrusher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BricksBallCrusher
{
    public partial class Form1 : Form
    {
        Ball ball;
        Rectangle rectangle;
        Game game;
        int leftX;
        int topY;
        int width;
        int height;
        Timer timer;
        int isMoved;
        int Misses;
        Timer timer2;
        int flag = 0;
        Ball ball_2;
        bool isBall2;
        int Count = 1;
        BonusGame bonusGame;
       
       
        public Form1()
        {
            
            InitializeComponent();          
            this.DoubleBuffered = true;
            game = new Game();
            bonusGame = new BonusGame();
            isBall2 = false;

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            timer2 = new Timer();
            timer2.Interval = 1;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

            leftX = 20;
            topY = 40;
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);

            ball = new Ball(new Point(this.Width / 2, this.Height - 120));
            rectangle = new Rectangle(this.Width / 2-40, this.Height - 110);
            Misses = 3;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Touched();
            game.Delete();
            Bonus();
            Invalidate(true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            if (isMoved == 1)
            {
                ball.Move(leftX, topY, width, height);
                if (isBall2)
                {
                    ball_2.Move(leftX, topY, width, height);
                    rectangle.Rejected(ball_2);

                }
                NewGame();
                rectangle.Rejected(ball);
                
            }
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            Pen pen = new Pen(Color.White, 2);
            e.Graphics.DrawRectangle(pen, leftX, topY, width, height);
            pen.Dispose();
            game.AddBall(ball);
            game.DrawBall(e.Graphics);
            rectangle.Draw(e.Graphics);
            game.Add();
            game.Draw(e.Graphics);
           
            
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                isMoved = 1;
                rectangle.Move(leftX,width,-10);

            }
            else if (e.KeyCode == Keys.Right)
            {
                isMoved = 1;
                rectangle.Move(leftX, width, 10);
            }
            Invalidate();
        }

       public void NewGame()
        {
            if (ball.isNewGame)
            {

                game.ClearBall();
                if (Misses > 1)
                {
                    
                    ball = new Ball(new Point(this.Width / 2, this.Height - 120));
                    rectangle = new Rectangle(this.Width / 2 - 40, this.Height - 110);
                    isMoved = 0;
                    Misses--;
                }
                else
                {

                    timer.Stop();
                    DialogResult dialogResault = MessageBox.Show("Do you want to play again?", "GAME OVER", MessageBoxButtons.RetryCancel);
                    if (dialogResault == DialogResult.Retry)
                    {
                        game.ClearBall();
                        ball = new Ball(new Point(this.Width / 2, this.Height - 120));
                        rectangle = new Rectangle(this.Width / 2 - 40, this.Height - 110);
                        game.Add();
                        timer.Start();
                        Misses = 3;                        
                        isMoved = 0;
                        ball.isNewGame = false;
                        game.flag = 0;                          
                        game.random = new Random();
                        game.ShowImage = true;
                        game.Points = 0;
                        Count = 1;

                    }
                    else
                    {
                        this.Close();
                    }
                    
                }
                if (isBall2)
                {
                    game.Balls.Remove(ball_2);
                    isBall2 = false;
                }

            }
            lblLives.Text = Misses.ToString();
            lblPoints.Text = game.Points.ToString();

        }

        public void Touched()
        {
            foreach(Brick b in game.Bricks)
            {
                b.Select(ball);
                if(isBall2)
                b.Select(ball_2);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Bonus()
        {
            BonusLevel bonus = new BonusLevel();
            if (game.ShowBonus)
            {
                timer.Stop();
                timer2.Stop();
                this.Hide();
               
                bonus.ShowDialog();
                this.Show();
                game.ShowBonus = false;
                flag = 1;

             }
        
            if (flag == 1)
            {
                DialogResult result = MessageBox.Show(string.Format("You have earnd {0} extra points!!!",bonusGame.PointsBonus), "BONUS", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    timer.Start();
                    timer2.Start();
                    flag = 0;
                    game.Points += bonusGame.PointsBonus;
                }
                
            }
          
        }

        private void lblTwo_Click(object sender, EventArgs e)
        {
            if (Count == 1)
            {
                ball_2 = new Ball(new Point(this.Width / 2, this.Height - 120));
                ball_2.Color = Color.YellowGreen;
                game.AddBall(ball_2);
                isBall2 = true;
                Count--;
            }

            Invalidate();


        }
    }
}
