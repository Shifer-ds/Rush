using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace SolarRush
{
    public interface IInputs
    {
        // Texture2D backround {get;}
        // string name {get;set;}
        // int inputX {get;set;}
        // int inputY {get;set;}
        // bool active {get;set;}

        void Update(float delta);

        void Draw(SpriteBatch spriteBatch);
    }
}