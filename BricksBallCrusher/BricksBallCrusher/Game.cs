using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBallCrusher
{
    public class Game
    {
        public List<Brick> Bricks { get; set; }
        public List<Ball> Balls { get; set; }
        public BonusGame bonusGame { get; set; }
        public Color CurrentColor { get; set; }
        public int Points { get; set; }
        
        public int flag;
        public int r { get; set; }
        public Random random { get; set; }
        public bool ShowImage { get; set; }
        public bool ShowBonus { get; set; }
        public bool EndGame { get; set; }


        public Game()
        {
            CurrentColor = Color.Red;
            Bricks = new List<Brick>();
            Balls = new List<Ball>();
            bonusGame = new BonusGame();
            flag = 0;
            EndGame = false;
            ShowBonus = false;
            random = new Random();
            //r = random.Next(0, 54);
            Points = 0;
            r = 32;
            ShowImage = true;
        }

        public void AddBall(Ball ball)
        {
            Balls.Add(ball);
        }

        public void Add()
        {
            int x = 43;
            int y = 60;
            while (flag < 5)
            {
                if (flag == 0)
                {
                    CurrentColor = Color.Blue;
                }
                else if (flag == 1)
                {
                    CurrentColor = Color.Aqua;
                }
                else if (flag == 2)
                {
                    CurrentColor = Color.Red;
                }
                else if (flag == 3)
                {
                    CurrentColor = Color.Yellow;
                }
                else if (flag == 4)
                {
                    CurrentColor = Color.Green;
                }
                for (int i = 0; i <10; i++)
                {
                    Brick brick = new Brick(x, y);
                    brick.Color = CurrentColor;
                    Bricks.Add(brick);
                    x += 77;
                }

                x = 43;
                y += 25;
                flag++;
            }

        }
        public void DrawBall(Graphics g)
        {
            foreach(Ball b in Balls)
            {
                b.Draw(g);
            }
        }
        public void Move(int left, int top, int width, int height)
        {
            foreach(Ball b in Balls)
            {
                b.Move(left, top, width, height);
            }
        }

        public void Draw(Graphics g)
        {
            for(int i=Bricks.Count-1;i>=0;--i)
            {
                if (i == r)
                {
                    if (ShowImage)
                    {
                        Bricks[i].DrawImage(g);
                    }
                    else if(!ShowImage)
                    {
                        Bricks[i].Draw(g);
                    }                   
                }
                else
                {
                    Bricks[i].Draw(g);
                }               
            }           
        }

        public void Delete()
        {
            
                for (int i = Bricks.Count - 1; i >= 0; --i)
                {
                    if (Bricks[i].isTouched)
                    {
                        Bricks.RemoveAt(i);
                        Points += 2;

                        if (r > i)
                        {
                            r--;
                        }
                        else if (r == i)
                        {

                            if (ShowImage)
                            {
                            ShowImage = false;
                            ShowBonus = true;

                            }

                        }
                    }
                }
                if(Bricks.Count == 0)
                {
                EndGame = true;
                }
        }
        public void ClearBall()
        {
            for (int i = Balls.Count - 1; i >= 0; --i)
            {

                if (Balls[i].isNewGame)
                {
                    Balls.RemoveAt(i);
                }

            }
        }

    }
}
