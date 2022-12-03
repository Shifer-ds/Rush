using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using lib.Graphics;
using lib.Input;
using GSM;
namespace SolarRushAmerica
{
    public class SolarRush : Game
    {
        private GraphicsDeviceManager _graphics;
        private Sprites _sprites;
        public ScreenManager _screenManager;
        private WindowRez _window;
        private Vector2 mousePosition;
        private Texture2D texture;
        private SpriteFont gameFont;
        private bool IsDebug;
        public SolarRush()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this._graphics.PreferredBackBufferWidth = 650;
            this._graphics.PreferredBackBufferHeight = 520;
            this._graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            _sprites = new Sprites(this);
            _sprites.setFont(gameFont);
            _window = new WindowRez(this, 640,480);
            _screenManager = new ScreenManager(this);
            IScreens screen = new SplashScreen(this, _screenManager, _sprites, _window);
            _screenManager.Push(screen);

            IsDebug = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            texture = this.Content.Load<Texture2D>("textureFalse");
            gameFont = this.Content.Load<SpriteFont>("galleryFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseInput _mouse =  MouseInput.Instance;
            _mouse.Update();
            mousePosition = new Vector2((int)_mouse.GetScreenPosition(this._window).X,(int)_mouse.GetScreenPosition(this._window).Y);
            if(_mouse.RightButtonClick())
            {
                IsDebug = !IsDebug;
            }
            _screenManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this._window.Set();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _sprites.Begin(false);
            _sprites.Draw(texture, new Rectangle(0,0,400,400), Vector2.Zero, new Vector2(40f,40f), 0f, new Vector2(0.5f,0.5f), Color.White);
            _sprites.DrawString(gameFont, "Missing Texture",new Vector2(0, 0), new Vector2(350, 450), -0.8f,new Vector2(1f,1f), Color.HotPink);
            _sprites.DrawString(gameFont, "Missing You",new Vector2(0, 0), new Vector2(300, 400), -0.8f,new Vector2(2f,2f), Color.HotPink);
            _screenManager.Draw(gameTime);
            if(IsDebug)
            {
                _sprites.DrawString(gameFont, $"({mousePosition.X},{mousePosition.Y})",new Vector2(0, 0), new Vector2(0, 0), 0f,new Vector2(1f,1f), Color.White);
            }
            _sprites.End();
            this._window.unSet();
            this._window.Present(this._sprites);
            base.Draw(gameTime);
        }
    }
}
