using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using lib.Graphics;
using System.Diagnostics;
using System;
namespace GSM
{
    /// <summary>
    /// This is a screen that can be added to the ScreenManager. Extend it and add components 
    /// to it in the Initialize() method. You can also override the Update() and Draw() method.
    /// </summary>
    public class SplashScreen : IScreens
    {
        private Texture2D splashImage;
        private Texture2D Pixel;
        private Sprites sprites;
        private WindowRez window;
        private Game game;
        private float elapse;
        private float opacity;
        /// <summary>
        /// Set this member to true if this screen doesn't cover the entire screen.
        /// </summary>
        public bool Translucent { get; set; }

        /// <summary>
        /// A reference to the ScreenManager.
        /// </summary>
        public ScreenManager screenManager { get; internal set; }


        public SplashScreen(Game _game, ScreenManager screenManager, Sprites _sprites, WindowRez _window)
        {
            this.screenManager = screenManager;
            window = _window;
            sprites = _sprites;
            game = _game;
            Translucent = false;
            splashImage = game.Content.Load<Texture2D>("fernNPeek");
            Pixel = new Texture2D(splashImage.GraphicsDevice, 1, 1);
            Pixel.SetData(new[] { Color.White });
            opacity = 0f;

        }

        public void Update(GameTime gameTime)
        {
            elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(elapse>5000)
            {
                IScreens mainScreen = new MainScreen(this.game,this.screenManager, this.sprites, this.window);
                this.screenManager.Push(mainScreen);
            } else if(elapse<2000){
                opacity = (float)elapse/2000;
            } else{
                opacity = 1f;
            }
            
        }

        public void Draw(GameTime gameTime)
        {
            sprites.Draw(Pixel,null, new Rectangle(0,0,window.Width,window.Height),Color.Black);
            sprites.Draw(splashImage, null,Vector2.Zero ,new Vector2((int)(window.Width-splashImage.Width/2)/2,(int)(window.Height-splashImage.Height/2)/2),0f,new Vector2(0.5f,0.5f),Color.White*opacity);    
 
        }
    }
}