using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using SolarRush.Screens;

namespace SolarRush.Managers
{
    public class ScreenManager
    {
        private IReadOnlyCollection<IScreen> _screens;
        private IScreen _activeScreen;
        private IScreen _nextScreen;
        
        public ScreenManager(IReadOnlyCollection<IScreen> screens)
        {
            _screens = screens;
        }

        public void SetScreen(ScreenType screenType)
        {
            foreach (var screen in _screens)
            {
                if (screen.ScreenType == screenType)
                {
                    _nextScreen = screen;
                    return;   
                }
            }
        }
        public void SwitchToNextScreen()
        {
            if(_nextScreen!= null){
                _activeScreen = _nextScreen;
            }
            _nextScreen = null;
        }
        
        internal void Update(float delta)
        {
            _activeScreen.Update(delta);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            _activeScreen.Draw(spriteBatch);
        }

    }
}