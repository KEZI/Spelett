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
    class Screen
    {
        //Stores the PlayerIndex for the controlling player, i.e. Player One
        protected static PlayerIndex PlayerOne;

        //The event associated with the Screen. This event is used to raise events
        //back in the main game class to notify the game that something has changed
        //or needs to be changed
        protected EventHandler ScreenEvent;
        public Screen(EventHandler SEvent)
        {
            ScreenEvent = SEvent;
        }

        //Update any information specific to the screen
        public virtual void Update(GameTime Time)
        {
        }

        //Draw any objects specific to the screen
        public virtual void Draw(SpriteBatch SBatch)
        {
        }
    }
}
