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
    class Hero : Sprite
    {
        const string HERO_ASSETNAME = "ShadowZelda";
        const int HERO_SPEED = 150;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        Vector2 StartingPosition = Vector2.Zero;
        Vector2 StartingPositionTwo = Vector2.Zero;

        enum State
        {
            Walking,
            Jumping,
            DoubleJumping
        }

        State CurrentState = State.Walking;

        Vector2 Direction = Vector2.Zero;
        Vector2 Speed = Vector2.Zero;

        KeyboardState PreviousKeyboardState;

        public virtual void LoadContent(ContentManager ContentManager)
        {
            base.LoadContent(ContentManager, HERO_ASSETNAME);
        }

        public virtual void Update(GameTime GameTime, GraphicsDevice Graphics)
        {
            KeyboardState CurrentKeyboardState = Keyboard.GetState();

            UpdateMovement(CurrentKeyboardState, Graphics);
            UpdateJump(CurrentKeyboardState);

            PreviousKeyboardState = CurrentKeyboardState;

            base.Update(GameTime, Speed, Direction);
        }

        private void UpdateMovement(KeyboardState Current, GraphicsDevice Graphics)
        {
            if (CurrentState == State.Walking)
            {
                Speed = Vector2.Zero;
                Direction = Vector2.Zero;

                if (SpritePosition.X > Graphics.Viewport.Width / 4 && Current.IsKeyDown(Keys.Left) == true)
                {
                    Speed.X = HERO_SPEED;
                    Direction.X = MOVE_LEFT;
                }

                if (SpritePosition.X <= Graphics.Viewport.Width / 4 && Current.IsKeyUp(Keys.Left) == true)
                {
                    SpriteVector.X = Graphics.Viewport.Width / 4 + 1;
                }

                if (SpritePosition.X < Graphics.Viewport.Width / 2 && Current.IsKeyDown(Keys.Right) == true)
                {
                    Speed.X = HERO_SPEED;
                    Direction.X = MOVE_RIGHT;
                }

                if (SpritePosition.X >= Graphics.Viewport.Width / 2 && Current.IsKeyDown(Keys.Right) == false)
                {
                    SpriteVector.X = Graphics.Viewport.Width / 2 - 1;
                }
                #region Later Code
                /*if (CurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {
                    Speed.Y = HERO_SPEED;
                    Direction.Y = MOVE_UP;
                }
                else if (CurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {
                    Speed.Y = HERO_SPEED;
                    Direction.Y = MOVE_DOWN;
                }*/
                #endregion
            }
        }

        private void UpdateJump(KeyboardState CurrentKeyboardState)
        {
            if (CurrentState == State.Walking)
            {
                if (CurrentKeyboardState.IsKeyDown(Keys.Up))
                    Jump();
            }

            if (CurrentState == State.Jumping)
            {
                if (!CurrentKeyboardState.IsKeyDown(Keys.Space) && PreviousKeyboardState.IsKeyDown(Keys.Space))
                    DoubleJump();
            }

            if (CurrentState == State.Jumping)
            {
                //Height of the jump.
                if (StartingPosition.Y - SpritePosition.Y > 40)
                    Direction.Y = MOVE_DOWN;
                //Reset to walking.
                if (SpriteVector.Y > StartingPosition.Y)
                {
                    SpriteVector.Y = StartingPosition.Y;
                    CurrentState = State.Walking;
                    Direction = Vector2.Zero;
                }
            }

            else if (CurrentState == State.DoubleJumping)
            {
                //Height of the jump.
                if (StartingPositionTwo.Y - SpritePosition.Y > 80)
                    Direction.Y = MOVE_DOWN;
                //Reset to walking.
                if (SpritePosition.Y > StartingPosition.Y)
                {
                    SpriteVector.Y = StartingPosition.Y;
                    CurrentState = State.Walking;
                    Direction = Vector2.Zero;
                }
            }
        }

        private void Jump()
        {
            if (CurrentState != State.Jumping)
            {
                CurrentState = State.Jumping;
                StartingPosition = SpriteVector;
                Direction.Y = MOVE_UP;
                Speed = new Vector2(HERO_SPEED, HERO_SPEED);
            }
        }

        private void DoubleJump()
        {
            if (CurrentState == State.Jumping)
            {
                CurrentState = State.DoubleJumping;
                StartingPositionTwo = SpriteVector;
                Direction.Y = MOVE_UP;
                Speed = new Vector2(HERO_SPEED, HERO_SPEED);
            }
        }
    }
}
