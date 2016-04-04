using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class FirstGame : Game
    {
        public Microsoft.Xna.Framework.Content.ContentManager getContentManager { get { return Content; } }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public World world { get; set; }
        Texture2D CrossHair;
        Texture2D DebugSelected;
        SpriteFont font;
        Texture2D empty;
        public static bool debugmode;
        public static bool mapcreation;

        public FirstGame()
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

            world = new World();

            base.Initialize();

            debugmode = true;
            mapcreation = true;

            this.Window.Position = new Point(0, 0);

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;

            //graphics.PreferredBackBufferWidth = 1280;
            //graphics.PreferredBackBufferHeight = 720;


            graphics.ApplyChanges();
            this.graphics.IsFullScreen = true;
            IsMouseVisible = false;
            this.graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            world.LoadWorld(Content);
            CrossHair = Content.Load<Texture2D>("crosshair.png");
            DebugSelected = Content.Load<Texture2D>("Selected.png");
            font = Content.Load<SpriteFont>("test");

            empty = Content.Load<Texture2D>("empty.png");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            world.UpdateWorld(gameTime);




            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            world.DrawWorld(spriteBatch);
            
            MouseState mouse = Mouse.GetState();
            spriteBatch.Draw(CrossHair, new Rectangle(mouse.X-16, mouse.Y-16, 32, 32), Color.White);

            if(debugmode)
            {
                spriteBatch.Draw(DebugSelected, Logic.Gridiffy((int)Math.Floor((double)(mouse.X / 64)), (int)Math.Floor((double)(mouse.Y / 64))), Color.White);
                spriteBatch.DrawString(font, gameTime.TotalGameTime.Milliseconds + "", new Vector2(10, 10), Color.Black);
            }

            //spriteBatch.Draw(empty, new Rectangle(world.Entities.player.testcoll1, new Point(5, 5)), new Rectangle(0, 0, 4, 4), Color.Red, 0, new Vector2(2, 2), SpriteEffects.None, 0);
            //spriteBatch.Draw(empty, new Rectangle(world.Entities.player.testcoll2, new Point(5, 5)), new Rectangle(0, 0, 4, 4), Color.Red, 0, new Vector2(2, 2), SpriteEffects.None, 0);
            //spriteBatch.Draw(empty, new Rectangle(world.Entities.player.testcoll3, new Point(5, 5)), new Rectangle(0, 0, 4, 4), Color.Red, 0, new Vector2(2, 2), SpriteEffects.None, 0);

            spriteBatch.Draw(empty, new Rectangle(20, 20, 100, 20), Color.Red);
            spriteBatch.Draw(empty, new Rectangle(20, 20, (int)(world.Entities.player.HP/10), 20),Color.Green);
            spriteBatch.End();


            base.Draw(gameTime);
        }

        
    }
}
