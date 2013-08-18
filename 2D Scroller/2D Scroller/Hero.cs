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
        const int HERO_SPEED = 100;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        bool RunningBack;
        bool IsJumping = false;

        internal Texture2D Standing;
        internal Texture2D RunningOne;
        internal Texture2D RunningTwo;
        internal Texture2D Jumping;

        Vector2 StartingPosition = Vector2.Zero;
        Vector2 StartingPositionTwo = Vector2.Zero;

        enum State
        {
            Standing,
            Running
        }

        State CurrentState = State.Standing;

        Vector2 Direction = Vector2.Zero;
        Vector2 Speed = Vector2.Zero;

        KeyboardState PreviousKeyboardState;

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
            if (!Current.IsKeyDown(Keys.Right) && !Current.IsKeyDown(Keys.Left))
            {
                CurrentState = State.Standing;
                Speed.X = 0;
                Direction.X = 0;
            }

            if (Current.IsKeyDown(Keys.Left))
            {
                if (SpritePosition.X <= Graphics.Viewport.Width / 4)
                {
                    Speed.X = 0;
                    Direction.X = 0;
                }
                else
                {
                    CurrentState = State.Running;
                    RunningBack = true;
                    Speed.X = HERO_SPEED;
                    Direction.X = MOVE_LEFT;
                }

            }

            if (Current.IsKeyDown(Keys.Right))
            {
                if (SpritePosition.X >= Graphics.Viewport.Width / 2)
                {
                    Speed.X = 0;
                    Direction.X = 0;
                }
                else
                {
                    CurrentState = State.Running;
                    RunningBack = false;
                    Speed.X = HERO_SPEED;
                    Direction.X = MOVE_RIGHT;
                }
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

        private void UpdateJump(KeyboardState Current)
        {
            if (Current.IsKeyDown(Keys.Up))
            {
                if (!IsJumping)
                {
                    Jump();
                }
            }

            if (IsJumping)
            {
                //Height of the jump.
                if (StartingPosition.Y - SpritePosition.Y > 40)
                    Direction.Y = MOVE_DOWN;
                //Reset to walking.
                if (SpriteVector.Y > StartingPosition.Y)
                {
                    IsJumping = false;
                    SpriteVector.Y = StartingPosition.Y;
                    Speed.Y = 0;
                    Direction.Y = 0;
                }
            }
        }

        private void Jump()
        {
            IsJumping = true;
            StartingPosition = SpriteVector;
            Speed.Y = HERO_SPEED;
            Direction.Y = MOVE_UP;

        }

        /*private void DoubleJump()
        {
            if (CurrentState == State.Jumping)
            {
                CurrentState = State.DoubleJumping;
                StartingPositionTwo = SpriteVector;
                Direction.Y = MOVE_UP;
                Speed = new Vector2(HERO_SPEED, HERO_SPEED);
            }
        }*/

        public override void Draw(SpriteBatch SBatch)
        {
            if (CurrentState == State.Standing)
                SBatch.Draw(Standing, SpritePosition, SpriteRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
            if (CurrentState == State.Running && !RunningBack)
                SBatch.Draw(RunningOne, SpritePosition, SpriteRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
            if (CurrentState == State.Running && RunningBack)
                SBatch.Draw(RunningOne, SpritePosition, SpriteRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
            if (IsJumping)
                SBatch.Draw(Jumping, SpritePosition, SpriteRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, 0.0f);
        }
    }
}
