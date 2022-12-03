using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using SolarRush.Managers;
using SolarRush.Screens;
namespace SolarRush
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager _screenManager;
        public MouseState MouseInput;
        public int gameWidth;
        public int gameHeight;
        private ushort[] widths;
        private ushort[] heights;
        public int Score;
        public SpriteFont gameFont;
        private SimpleButton button1;
        private ScoreCount ScoreCount;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        void ChangeResolution(byte newResolution)
        {
            widths = new ushort[] {480, 360, 720};
            heights = new ushort[] {800, 640, 1280 };
            // Only change resolution if the newResolution is between 0 and the length of the widths array
            if (newResolution >= 0 && newResolution < widths.Length)
                {
                // Change the width and height to the new values in the array
                _graphics.PreferredBackBufferWidth = widths[newResolution];
                _graphics.PreferredBackBufferHeight = heights[newResolution];
                // Apply the changes
                _graphics.ApplyChanges();
                System.Console.WriteLine("New resolution: {0} x {1}", _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
                }
        }
        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            gameWidth = 480;
            gameHeight = 800;
            _graphics.PreferredBackBufferWidth = gameWidth;
            _graphics.PreferredBackBufferHeight = gameHeight;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
            // _screenManager = new ScreenManager(new IScreen[] {
            //     new SplashScreen(Content),
            //     new MainMenuScreen(Content)
            // });

            // _screenManager.SetScreen(ScreenType.Splash);
            // _screenManager.SwitchToNextScreen();
            gameFont = Content.Load<SpriteFont>("galleryFont");
            Score =0;
            ScoreCount = new ScoreCount();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Keys[] FunctionKeys = new Keys[] { Keys.A, Keys.B, Keys.C};
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
                {
                    Score++;
                    // _screenManager.SetScreen(ScreenType.MainMenuScreen);
                    // _screenManager.SwitchToNextScreen();
                    // ChangeResolution(i);
                }
            // // This for loop will check if one of the keys in the FunctionKeys array is pressed.
            // for (byte i = 0; i < FunctionKeys.Length; i++)
            // {
                
            //     // If one of the keys in FunctionKeys is pressed it will change the resolution based on the index of that key
            //     if (Keyboard.GetState().IsKeyDown(FunctionKeys[i]))
            //     {
            //         Score++;
            //         // _screenManager.SetScreen(ScreenType.MainMenuScreen);
            //         // _screenManager.SwitchToNextScreen();
            //         // ChangeResolution(i);
            //     }
            // }
            // MouseInput = Mouse.GetState();
            // _screenManager.Update(1.0f);
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            // _screenManager.Draw(_spriteBatch);
            _spriteBatch.DrawString(gameFont, Score.ToString(), new Vector2(10, 10), Color.Blue);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }


}
