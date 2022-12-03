using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using lib.Graphics;
namespace GSM
{
    /// <summary>
    /// This is a screen that can be added to the ScreenManager. Extend it and add components 
    /// to it in the Initialize() method. You can also override the Update() and Draw() method.
    /// </summary>
    public class MainScreen : IScreens
    {
        private Texture2D BackroundImage;
        private Texture2D Pixel;
        private Sprites sprites;
        private WindowRez window;
        /// <summary>
        /// Set this member to true if this screen doesn't cover the entire screen.
        /// </summary>
        public bool Translucent { get; set; }

        /// <summary>
        /// A reference to the ScreenManager.
        /// </summary>
        public ScreenManager screenManager { get; internal set; }


        public MainScreen(Game game, ScreenManager screenManager, Sprites _sprites, WindowRez _window)
        {
            this.screenManager = screenManager;
            window = _window;
            sprites = _sprites;
            Translucent = false;
            BackroundImage = game.Content.Load<Texture2D>("textureFalse");
            Pixel = new Texture2D(BackroundImage.GraphicsDevice, 1, 1);
            Pixel.SetData(new[] { Color.White });

        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            sprites.Draw(Pixel,null, new Rectangle(0,0,window.Width,window.Height),Color.Black);
            sprites.DrawString("lmaoooaoaa",new Vector2(0,0), Color.White);
            sprites.Draw(BackroundImage, null,Vector2.Zero ,new Vector2((int)(window.Width-BackroundImage.Width/2)/2,(int)(window.Height-BackroundImage.Height/2)/2),0f,new Vector2(0.5f,0.5f),Color.White);    
 
        }
    }
}