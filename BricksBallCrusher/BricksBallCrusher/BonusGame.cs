using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricksBallCrusher
{
    public class BonusGame
    {
        public List<Brick> bricks { get; set; }
        public Color CurrentColor { get; set; }
        public int PointsBonus { get; set; }
        public int flag = 0;
        public int R { get; set; }

        public int G { get; set; }

        public int B { get; set; }

        public Game game { get; set; }
        
        
        public BonusGame()
        {
            bricks = new List<Brick>();
            CurrentColor = Color.DarkRed;
            PointsBonus = 0;
            Random r = new Random();
            R = r.Next(256);
            G = r.Next(256);
            B = r.Next(256);
        }
        public void Add()
        {
            int x = 40;
            int y = 60;
            while (flag < 7)
            {
                
                for (int i = 0; i < 11; i++)
                {
                    Random r = new Random();
                    R += 5;
                    G += 10;
                    B += 15;
                    R = R % 256;
                    G = G % 256;
                    B = B % 256;
                    CurrentColor = Color.FromArgb(R, G, B);
                    Brick brick = new Brick(x, y);
                    brick.Color = CurrentColor;
                    bricks.Add(brick);
                    x += 65;
                }

                x = 40;
                y += 25;
                flag++;
            }

        }
        public void Draw(Graphics g)
        {
            foreach (Brick b in bricks)
            {
                b.Draw(g);
            }
        }
        public void Delete()
        {

            for (int i = bricks.Count - 1; i >= 0; --i)
            {
                if (bricks[i].isTouched)
                {
                    bricks.RemoveAt(i);
                    PointsBonus++;
                    
                }
            }
          
            
        }
    }
}
