using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBallCrusher
{
     public class Rectangle
    {
        public static int Width = 80;
        public int Height = 10;
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }


        public Rectangle(int x, int y)
        {
            Color = Color.White;
            X = x;
            Y = y;
            
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillRectangle(brush, X, Y, Width, Height);
            brush.Dispose();
        }
       

        public void Move(int left, int width,int x)
        {
            X += x;
            int nextX =X;
            
            int lft = left;
            int rgt = left + width - Width;

            if (nextX <= lft)
            {             
                X -= x;
            }
            if (nextX >= rgt)
            {               
                X -= x;
            }
        }


        public void Rejected(Ball ball)
        {           
            if (ball.Center.X+ball.Radius >= X && ball.Center.X - ball.Radius <= X + Width && ball.Center.Y + ball.Radius >= Y && ball.Center.Y - ball.Radius <= Y + Height)
            {
                ball.velocityY = -ball.velocityY;
            }
        }

    }
}
