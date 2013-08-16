using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _2D_Scroller
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch SBatch;

        //Screen CurrentScreen;
        //TitleScreen TitleScreen;

        Sprite BoxOne;
        Sprite BoxTwo;
        Sprite BoxThree;
        BoxManager BoxMan;

        Sprite BackgroundOne;
        Sprite BackgroundTwo;
        Sprite BackgroundThree;
        BackgroundManager BGMan;

        Hero Zelda;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //TitleScreen = new TitleScreen(Content, new EventHandler(TitleScreenEvent));

            Zelda = new Hero();
            BackgroundOne = new Sprite();
            BackgroundTwo = new Sprite();
            BackgroundThree = new Sprite();
            BGMan = new BackgroundManager();
            BoxOne = new Sprite();
            BoxTwo = new Sprite();
            BoxThree = new Sprite();
            BoxMan = new BoxManager();

            // Create a new SpriteBatch, which can be used to draw textures.
            SBatch = new SpriteBatch(GraphicsDevice);

            //CurrentScreen = TitleScreen;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            BackgroundOne.LoadContent(this.Content, "Background");
            BackgroundTwo.LoadContent(this.Content, "Background");
            BackgroundThree.LoadContent(this.Content, "Background");
            BackgroundOne.SpritePosition = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            BackgroundTwo.SpritePosition = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            BackgroundThree.SpritePosition = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            BackgroundTwo.SpriteVector = new Vector2(BackgroundOne.SpritePosition.X + GraphicsDevice.Viewport.Width, 0);
            BackgroundThree.SpriteVector = new Vector2(BackgroundTwo.SpritePosition.X + GraphicsDevice.Viewport.Width, 0);

            Sprite[] Horizontals = { BackgroundOne, BackgroundTwo, BackgroundThree };

            BGMan.HorizontalList.AddRange(Horizontals);
            BGMan.HorizontalList.SpriteRectangle(new Rectangle(1540, 500, 500, 485));

            Zelda.LoadContent(this.Content);
            Zelda.SpriteRectangle = new Rectangle(0, 0, 33, 26);
            Zelda.SpritePosition = new Rectangle(0, 0, Zelda.SpriteRectangle.Width, Zelda.SpriteRectangle.Height);
            Zelda.SpriteVector = new Vector2(GraphicsDevice.Viewport.Width / 3, GraphicsDevice.Viewport.Bounds.Bottom - Zelda.SpriteRectangle.Height);

            BoxOne.LoadContent(this.Content, "Box");
            BoxOne.SpriteVector = new Vector2(200, 450);
            BoxTwo.LoadContent(this.Content, "Box");
            BoxTwo.SpriteVector = new Vector2(250, 400);
            BoxThree.LoadContent(this.Content, "Box");
            BoxThree.SpriteVector = new Vector2(300, 350);

            Sprite[] Boxes = { BoxOne, BoxTwo, BoxThree };

            //BoxMan.BoxList.AddRange(Boxes);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            #region Background Movement Rules
            if (BackgroundOne.SpritePosition.X < -BackgroundOne.SpritePosition.Width)
                BackgroundOne.SpriteVector.X = BackgroundThree.SpritePosition.X + BackgroundThree.SpritePosition.Width;
            else if (BackgroundOne.SpritePosition.X > BackgroundOne.SpritePosition.Width)
                BackgroundOne.SpriteVector.X = BackgroundTwo.SpritePosition.X - BackgroundTwo.SpritePosition.Width;

            if (BackgroundTwo.SpritePosition.X < -BackgroundTwo.SpritePosition.Width)
                BackgroundTwo.SpriteVector.X = BackgroundOne.SpritePosition.X + BackgroundOne.SpritePosition.Width;
            else if (BackgroundTwo.SpritePosition.X > BackgroundTwo.SpritePosition.Width)
                BackgroundTwo.SpriteVector.X = BackgroundThree.SpritePosition.X - BackgroundThree.SpritePosition.Width;

            if (BackgroundThree.SpritePosition.X < -BackgroundThree.SpritePosition.Width)
                BackgroundThree.SpriteVector.X = BackgroundTwo.SpritePosition.X + BackgroundTwo.SpritePosition.Width;
            else if (BackgroundThree.SpritePosition.X > BackgroundThree.SpritePosition.Width)
                BackgroundThree.SpriteVector.X = BackgroundOne.SpritePosition.X - BackgroundOne.SpritePosition.Width;
            #endregion

            BGMan.Update(gameTime, graphics.GraphicsDevice, Zelda);
            Zelda.Update(gameTime, graphics.GraphicsDevice);
            base.Update(gameTime);
        }

        public void TitleScreenEvent(object obj, EventArgs e)
        {
            //Switch to the controller detect screen, the Title screen is finished being displayed
            //CurrentScreen = TitleScreen;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SBatch.Begin();
            BGMan.Draw(SBatch);
            Zelda.Draw(SBatch);
            SBatch.End();

            base.Draw(gameTime);
        }
    }
}
