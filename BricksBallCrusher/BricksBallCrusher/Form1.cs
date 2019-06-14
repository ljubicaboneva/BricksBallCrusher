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
        Timer timer3;
        Ball ball_2;
        Ball newball;
        bool isBall2;
        bool isNewBall;
        int CountTwo = 1;
        int CountMore = 0;
        BonusGame bonusGame;
        int max = 0;
        public static int SetValueForFinalePoints = 0;


        public Form1()
        {
            
            InitializeComponent();          
            this.DoubleBuffered = true;
            game = new Game();
            bonusGame = new BonusGame();
            isBall2 = false;
            isNewBall = false;

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            timer2 = new Timer();
            timer2.Interval = 1;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

            //timer3 = new Timer();
            //timer3.Interval = 25;
            //timer3.Tick += new EventHandler(timer3_Tick);
            //timer3.Start();


            leftX = 20;
            topY = 40;
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);

            ball = new Ball(new Point(this.Width / 2, this.Height - 120));
            rectangle = new Rectangle(this.Width / 2-40, this.Height - 110);
            Misses = 3;
        }
        //private void timer3_Tick(object sender, EventArgs e)
        //{
        //    CountMore = 0;
        //    Invalidate(true);
        //}

        private void timer2_Tick(object sender, EventArgs e)
        {
            Touched();
            game.Delete();
            Bonus();
            EndGame();
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
                if (isNewBall)
                {
                    newball.Move(leftX, topY, width, height);
                    rectangle.Rejected(newball);
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
                if (Misses > 1 && !game.EndGame)
                {
                    
                    ball = new Ball(new Point(this.Width / 2, this.Height - 120));
                    rectangle = new Rectangle(this.Width / 2 - 40, this.Height - 110);
                    isMoved = 0;
                    Misses--;
                }
                else if(game.EndGame || Misses == 0)
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
                        CountTwo = 1;
                        CountMore = 0;
                        SetValueForFinalePoints = 0;

                    }
                    else
                    {
                        Menu menu = new Menu();
                        FinalScore final = new FinalScore();
                       
                        if (game.Points >= max)
                        {
                            SetValueForFinalePoints = game.Points;
                            max = SetValueForFinalePoints;
                        }
                        this.Hide();
                        menu.ShowDialog();
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
                DialogResult result = MessageBox.Show(string.Format("You have earnd {0} extra points!!!",BonusLevel.SetValueForPoints), "BONUS", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    timer.Start();
                    timer2.Start();
                    flag = 0;
                    game.Points += BonusLevel.SetValueForPoints;
                }
                
            }
          
        }

        private void lblTwo_Click(object sender, EventArgs e)
        {
            if (CountTwo == 1 && isMoved == 0)
            {
                ball_2 = new Ball(new Point(this.Width / 2, this.Height - 120));
                ball_2.Color = Color.YellowGreen;
                game.AddBall(ball_2);
                isBall2 = true;
                CountTwo--;
            }

            Invalidate();
        }

        //private void lblMore_Click(object sender, EventArgs e)
        //{
        //    while (CountMore == 5)
        //    {
        //        newball = new Ball(new Point(this.Width / 2, this.Height - 120));
        //        newball.Color = Color.YellowGreen;
        //        newball.Angle = ball.Angle;
        //        isNewBall = true;
        //        game.AddBall(newball);
        //        CountMore++;

        //    }
        //    Misses--;
        //    Invalidate();
        //}

        private void lblMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            DialogResult result = MessageBox.Show("Are you sure you want to end your game?", "Back to Menu?", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {

                if (game.Points >= max)
                {
                    SetValueForFinalePoints = game.Points;
                    max = SetValueForFinalePoints;
                }
                timer.Stop();
                timer2.Stop();
               // timer3.Stop();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
         }

        public void EndGame()
        {
            if (game.EndGame)
            {
                NewGame();
            }
        }
    }
}
