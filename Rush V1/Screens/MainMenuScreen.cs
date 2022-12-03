using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace SolarRush.Screens
{
    class MainMenuScreen:IScreen
    {
        public ScreenType ScreenType {get;}
        public Texture2D backround {get;}
        private SimpleButton buttonInventory;
        private Texture2D iconl;
        private Texture2D icon;

        public MainMenuScreen(ContentManager content)
        {
            ScreenType = ScreenType.MainMenuScreen;
            backround = content.Load<Texture2D>("Inventorius_small");
            iconl = content.Load<Texture2D>("inactive_button_small");
            // icon = new Texture2D(iconl.GraphicsDevice, 4, 4);
            // icon.SetData(new[] { Color.White });
            buttonInventory = new SimpleButton(iconl, "Inventory", 0, 0);

        }

        public void Update(float delta)
        {
            buttonInventory.Update(delta);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backround, new Vector2(0, 0), Color.White);
            buttonInventory.Draw(spriteBatch);
        }
    }
}