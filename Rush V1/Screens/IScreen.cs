using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SolarRush.Screens
{
    public interface IScreen
    {
        ScreenType ScreenType {get;}
        Texture2D backround {get;}



        void Update(float delta);

        void Draw(SpriteBatch spriteBatch);
    }
}