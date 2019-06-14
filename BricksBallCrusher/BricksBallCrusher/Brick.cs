using BricksBallCrusher.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBallCrusher
{
    public class Brick
    {
        public static int Width = 60;
        public int Height = 15;
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public BonusGame bonus { get; set; }
        public bool isTouched { get; set; }
        public Image bomba;
        

        public Brick(int x,int y)
        {
            Color = Color.White;
            X = x;
            Y = y;
            isTouched=false;
            bomba = Resources.Bomba;
            bonus = new BonusGame();
           
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillRectangle(brush, X, Y, Width, Height);
            brush.Dispose();
        }

        public void DrawImage(Graphics g)
        {

            g.DrawImageUnscaled(bomba, X, Y, Width, Height);
            
        }

        public void Select(Ball ball)
        {

            if (ball.Center.X +ball.Radius >= X && ball.Center.X -ball.Radius <= X + Width && ball.Center.Y +ball.Radius>= Y && ball.Center.Y-ball.Radius <= Y + Height)
            {
                
                    ball.velocityY = -ball.velocityY;
                    isTouched = !isTouched;
         }

            if(ball.Center.X + ball.Radius <= X && ball.Center.X - ball.Radius >= X + Width && ball.Center.Y + ball.Radius <= Y && ball.Center.Y - ball.Radius >= Y + Height)
            {
                
                    ball.velocityY = -ball.velocityY;
            }

        }
        public void SelectInBonus(Ball ball)
        {

            if (ball.Center.X + ball.Radius >= X && ball.Center.X - ball.Radius <= X + Width && ball.Center.Y + ball.Radius >= Y && ball.Center.Y - ball.Radius <= Y + Height)
            {
                isTouched = !isTouched;
            }

           
        }





    }
}
