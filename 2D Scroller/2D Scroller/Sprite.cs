using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_Scroller
{
    class Sprite
    {
        public string SpriteName;
        public string AssetName;
        public Rectangle SpritePosition;
        public Rectangle SpriteRectangle {get;set;}
        public Vector2 SpriteVector;

        Texture2D SpriteTexture { get; set; }

        public void LoadContent(ContentManager ConMan, string Assetname)
        {
            AssetName = Assetname;
            SpriteTexture = ConMan.Load<Texture2D>(Assetname);
        }

        public void LoadContent(ContentManager ConMan, string Assetname, string Name)
        {
            SpriteName = Name;
            AssetName = Assetname;
            SpriteTexture = ConMan.Load<Texture2D>(Assetname);
        }

        public void Update(GameTime theGameTime, Vector2 Speed, Vector2 Direction)
        {
            SpriteVector += Direction * Speed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            SpritePosition.X = Convert.ToInt32(SpriteVector.X);
            SpritePosition.Y = Convert.ToInt32(SpriteVector.Y);
        }

        public void Draw(SpriteBatch Batch)
        {
            Batch.Draw(SpriteTexture, SpritePosition, SpriteRectangle, Color.White);
        }
    }
}
