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
        Random randomSuprise;
        int suprise;
        int supriseCount;
        int flag = 0;
        Timer timer2;
        Ball ball_2;
        Ball newball;
        bool isBall2;
        bool isNewBall;
        int CountTwo = 1;
        int CountMore = 0;
        int moreCounter;
        BonusGame bonusGame;
        int max = 0;
        public static int SetValueForFinalePoints = 0;
        public static bool isClickedMore;
        public static int Path = 0;


        public Form1()
        {

            InitializeComponent();
            this.DoubleBuffered = true;
            game = new Game();
            bonusGame = new BonusGame();
            isBall2 = false;
            isNewBall = false;
            isClickedMore = false;

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();


            timer2 = new Timer();
            timer2.Interval = 100;
            timer2.Tick += new EventHandler(timer2_Tick);


            leftX = 20;
            topY = 40;
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);

            ball = new Ball(new Point(this.Width / 2, this.Height - 120));
            rectangle = new Rectangle(this.Width / 2 - 40, this.Height - 110);
            Misses = 3;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Touched();
            game.Delete();
            Bonus();
            EndGame();
            ProgressChanged();


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

            if (isClickedMore)
            {
                foreach (Ball b in game.BallsMore)
                {
                    b.Move(leftX, topY, width, height);
                }
            }
            if (game.BallsMore.Count == 0)
            {
                isClickedMore = false;
            }
            Invalidate(true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(128,128,255));
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
            timer.Stop();
            timer.Start();
            if (e.KeyCode == Keys.Left)
            {
                isMoved = 1;
                rectangle.Move(leftX, width, -10);

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
            timer.Stop();
            timer.Start();
            if (ball.isNewGame)
            {
                timer.Start();
                game.ClearBall();
                if (Misses > 1)
                {
                    ball = new Ball(new Point(this.Width / 2, this.Height - 120));
                    rectangle = new Rectangle(this.Width / 2 - 40, this.Height - 110);
                    isMoved = 0;
                    Misses--;
                }
                else if (Misses == 1)
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
                        suprise = 0;
                        supriseCount = 0;

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
            timer.Stop();
            timer.Start();
            foreach (Brick b in game.Bricks)
            {
                b.Select(ball);
                if (isBall2)
                    b.Select(ball_2);
                foreach (Ball b1 in game.BallsMore)
                {
                    b.Select(b1);
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Bonus()
        {
            timer.Stop();
            timer.Start();
            BonusLevel bonus = new BonusLevel();
            if (game.ShowBonus)
            {
                timer.Stop();
                this.Hide();
                bonus.ShowDialog();
                this.Show();
                game.ShowBonus = false;
                flag = 1;

            }

            if (flag == 1)
            {
                DialogResult result = MessageBox.Show(string.Format("You have earnd {0} extra points!!!", BonusLevel.SetValueForPoints), "BONUS", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    timer.Start();
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

            Invalidate(true);
        }

        private void lblMore_Click(object sender, EventArgs e)
        {
            moreCounter++;
            isClickedMore = true;
            Path = 1;
            if (moreCounter < 2)
            {
                for (int i = 1; i <= 10; i++)
                {
                    newball = new Ball(new Point(75 * i, this.Height - 120));
                    newball.Color = Color.YellowGreen;
                    newball.isMoreBall = true;
                    game.AddBallMore(newball);
                }
            }
            Path = 0;
            Invalidate(true);
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            DialogResult result = MessageBox.Show("Are you sure you want to end your game?", "Back to Menu?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                if (game.Points >= max)
                {
                    SetValueForFinalePoints = game.Points;
                    max = SetValueForFinalePoints;
                }
                timer.Stop();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            Invalidate();
        }

        public void EndGame()
        {
            if (game.EndGame)
            {
                timer.Stop();
                DialogResult dialogResault = MessageBox.Show(string.Format("Your score is {0}", game.Points), "END GAME", MessageBoxButtons.OK);
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

        private void lblSuprise_Click(object sender, EventArgs e)
        {
            
            supriseCount++;
            randomSuprise = new Random();
            suprise = randomSuprise.Next(1, 6);
            if (supriseCount <= 4) { 

            if (suprise == 1)
            {
                    timer2.Start();
                    timer.Interval = 20;
                rectangle.Width = 120;
                rectangle.Color = Color.Blue;
            }
            if (suprise == 2)
            {
                if (Misses > 1)
                {
                    timer.Interval = 20;
                    Misses--;
                }
            }
            if (suprise == 3)
            {
                    timer2.Start();
                    timer.Interval = 20;
                rectangle.Color = Color.Red;
                rectangle.Width = 60;
            }
            if (suprise == 4)
            {
                    timer2.Start();
                    timer.Interval = 80;
            }
            if (suprise == 5)
            {
                    Misses++;
            }
        }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progrssBar.Increment(1);
        }

        void ProgressChanged()
        {
            if (ball.isNewGame)
            {
                timer2.Stop();
                progrssBar.Value = 0;
            }
            if (progrssBar.Value == progrssBar.Maximum)
            {
                if (suprise == 1)
                {
                    timer2.Stop();
                    timer.Interval = 20;
                    rectangle.Width = 80;
                    rectangle.Color = Color.White;
                    progrssBar.Value = 0;
                }
               
                if (suprise == 3)
                {
                    timer2.Stop();
                    timer.Interval = 20;
                    rectangle.Color = Color.White;
                    rectangle.Width = 80;
                    progrssBar.Value = 0;
                }
                if (suprise == 4)
                {
                    timer2.Stop();
                    timer.Interval = 20;
                    progrssBar.Value = 0;
                }
               
            }

        }

    }
}