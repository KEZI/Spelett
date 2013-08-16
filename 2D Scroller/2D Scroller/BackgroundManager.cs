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
    class BackgroundManager
    {
        #region Constants
        const int HERO_SPEED = 150;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        #endregion        

        public class Horizontal : List<Sprite>
        {
            internal static Horizontal Horizontals = new Horizontal();

            public void SpritePosition(Rectangle Position)
            {
                foreach (Sprite BG in Horizontals)
                {
                    BG.SpritePosition = Position;
                }
            }

            public void SpriteRectangle(Rectangle Rectangle)
            {
                foreach (Sprite BG in Horizontals)
                {
                    BG.SpriteRectangle = Rectangle;
                }
            }
        }
        #region Later Code
        /*internal class Vertical : List<Sprite>
        {
            Vertical VerticalList = new Vertical();

            public void SpritePosition(Rectangle Position)
            {
                foreach (Sprite BG in VerticalList)
                {
                    BG.SpritePosition = Position;
                }
            }

            public void SpriteRectangle(Rectangle Rectangle)
            {
                foreach (Sprite BG in VerticalList)
                {
                    BG.SpriteRectangle = Rectangle;
                }
            }
        }*/

        #endregion
        #region Later Code
        //public Vertical VerticalList = new Vertical(); 
        #endregion

        internal Horizontal HorizontalList = Horizontal.Horizontals;

        Vector2 Speed = Vector2.Zero;
        Vector2 Direction = Vector2.Zero;

        public void Update(GameTime GameTime, GraphicsDevice Graphics, Hero Hero)
        {
            Speed = Vector2.Zero;
            Direction = Vector2.Zero;

            #region Right Movement
            if (Hero.SpritePosition.X < Graphics.Viewport.Width / 2)
            {
                Speed.X = HERO_SPEED;
                Direction.X = MOVE_RIGHT;

                foreach (Sprite BG in HorizontalList)
                {
                    BG.Update(GameTime, Speed, Direction);
                }
            } 
            #endregion
            #region Left Movement
            if (Hero.SpritePosition.X > Graphics.Viewport.Width / 4)
            {
                Speed.X = HERO_SPEED;
                Direction.X = MOVE_LEFT;

                foreach (Sprite BG in HorizontalList)
                {
                    BG.Update(GameTime, Speed, Direction);
                }
            } 
            #endregion
            #region Later Code
            /*if (true)
            {
                foreach (Sprite BG in VerticalList)
                {
                    BG.Update(GameTime, Speed, Direction);
                }
            }
            if (true)
            {
                foreach (Sprite BG in VerticalList)
                {
                    BG.Update(GameTime, Speed, Direction);
                }
            }*/

            #endregion
        }

        public void Draw(SpriteBatch SBatch)
        {
            foreach (Sprite BG in HorizontalList)
            {
                BG.Draw(SBatch);
            }
            #region LaterCode
            /*foreach (Sprite BG in VerticalList)
            {
                BG.Draw(SBatch);
            }*/

            #endregion
        }
    }
}
