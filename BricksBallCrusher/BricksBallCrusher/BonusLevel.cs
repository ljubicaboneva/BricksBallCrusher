﻿using BricksBallCrusher.Properties;
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
    public partial class BonusLevel : Form
    {
        BonusGame BonusGame;
        Ball ball;
        Rectangle rectangle;
        
        int leftX;
        int topY;
        int width;
        int height;
        int isMoved;
        Timer timer;
        Timer timer2;
        Game game;
        Timer TimerImg;
        bool image;
        public BonusLevel()
        {
            InitializeComponent();
            BonusGame = new BonusGame();
          

            this.DoubleBuffered = true;
            leftX = 20;
            topY = 40;
            width = this.Width - (3 * leftX);
            height = this.Height - (int)(2.5 * topY);
            image = true;

            ball = new Ball(new Point(this.Width / 2, this.Height - 120));
            rectangle = new Rectangle(this.Width / 2 - 40, this.Height - 110);
            game = new Game();

            isMoved = 0;
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
           

            timer2 = new Timer();
            timer2.Interval = 1;
            timer2.Tick += new EventHandler(timer2_Tick);
           

            TimerImg = new Timer();
            TimerImg.Interval = 1500;
            TimerImg.Tick += new EventHandler(timerImg_Tick);
            TimerImg.Start();
            BackgroundImage = Resources.BonusRound;

        }

        private void timerImg_Tick(object sender, EventArgs e)
        {
            image = false;
            timer.Start();
            timer2.Start();
            Invalidate(true);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            TimerImg.Stop();
            Touched();
            BonusGame.Delete();
            BackToGame();
            Invalidate(true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isMoved == 1)
            {
                ball.Move(leftX, topY, width, height);
               
                rectangle.Rejected(ball);
            }
            Invalidate(true);
        }


        private void BonusLevel_Paint(object sender, PaintEventArgs e)
        {
            if (!image)
            {
                e.Graphics.Clear(Color.Black);
                Pen pen = new Pen(Color.White, 2);
                e.Graphics.DrawRectangle(pen, leftX, topY, width, height);
                pen.Dispose();
                ball.Draw(e.Graphics);
                rectangle.Draw(e.Graphics);
                BonusGame.Add();
                BonusGame.Draw(e.Graphics);
                lbltext.Text = "Points:";
                lblPointsBonus.Text = BonusGame.PointsBonus.ToString();

            }
        }

        public void BackToGame()
        {
            if (ball.isNewGame)
            {
                this.DialogResult = DialogResult.OK;
                ball.isNewGame = false;
                timer2.Stop();
                timer.Stop();
                this.Close();
            }
        }
       

        private void BonusLevel_KeyDown(object sender, KeyEventArgs e)
        {

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

        public void Touched()
        {
            foreach (Brick b in BonusGame.bricks)
            {
                b.SelectInBonus(ball);
            }
        }

    }
}