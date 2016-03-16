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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        World world;
        Texture2D CrossHair;
        Texture2D DebugSelected;
        SpriteFont font;
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
                spriteBatch.DrawString(font, (int)Math.Floor((double)(mouse.X / 64)) + ", " + (int)Math.Floor((double)(mouse.Y / 64)), new Vector2(10, 10), Color.Black);
            }
            
            

            

            spriteBatch.End();


            base.Draw(gameTime);
        }

        
    }
}
