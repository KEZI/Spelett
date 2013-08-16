using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2D_Scroller
{
    class BoxManager
    {
        public class BoxList : List<Sprite>
        {
            internal static BoxList Boxes = new BoxList();

            public void MoveBox(string BoxName, Point Point)
            {
                foreach (Sprite B in Boxes)
                {
                    if (B.SpriteName == BoxName)
                    {
                        Point P = new Point(B.SpritePosition.X + Point.X, B.SpritePosition.Y + Point.Y);
                        B.SpriteVector.X = P.X;
                        B.SpriteVector.Y = P.Y;
                    }
                }
            }

            public void MoveAllBoxes(Point Point)
            {
                foreach (Sprite B in Boxes)
                {
                    Point P = new Point(B.SpritePosition.X + Point.X, B.SpritePosition.Y + Point.Y);
                    B.SpriteVector.X = P.X;
                    B.SpriteVector.Y = P.Y;
                }
            }
        }

        public void Update(GameTime GameTime)
        {

        }
    }
}
