using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GSM
{
    public interface IScreens
    {
        // ScreenType ScreenType {get;}
        bool Translucent { get; set; }
        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}