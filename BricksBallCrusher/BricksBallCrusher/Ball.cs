using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBallCrusher
{
    public class Ball
    {
        public Point Center{ get; set; }
        public Color Color { get; set; }
        public int Radius = 10;
        public bool isNewGame { get; set; }
        

        public double Velocity { get; set; }
        public double Angle { get; set; }

        public float velocityX;
        public float velocityY;
       

        public Ball(Point p)
        {
            Center = p;
            Color = Color.White;
            Velocity = 10;
            Random r = new Random();            
            Angle = r.NextDouble() * 2 * Math.PI;

            while (Angle <= Math.PI)
            {
                Angle = r.NextDouble() * 2 * Math.PI;
            }
          
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);

            isNewGame = false;
            
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();
        }

        public void Move(int left, int top, int width, int height)
        {
            int nextX = (int)(Center.X + velocityX);
            int nextY = (int)(Center.Y + velocityY);
            int lft = left + Radius;
            int rgt = left + width - Radius;
            int tp = top + Radius;
            int btm = top + height - Radius;

            if (nextX <= lft)
            {
                nextX = lft + (lft - nextX);
                velocityX = -velocityX;
            }
            if (nextX >= rgt)
            {
                nextX = rgt - (nextX - rgt);
                velocityX = -velocityX;

            }
            if (nextY <= tp)
            {
                nextY = tp + (tp - nextY);
                velocityY = -velocityY;
            }

            if (nextY >= btm)
            {                
                isNewGame = true;
               

            }
            Center = new Point(nextX, nextY);
        }
        
    }
}
