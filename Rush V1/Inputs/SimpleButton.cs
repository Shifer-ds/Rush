using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace SolarRush
{
    class SimpleButton:Game1, IInputs
    {
        
        private Texture2D backround {get;}
        private string name {get;set;}
        private int inputX {get;set;}
        private int inputY {get;set;}
        private bool active {get;set;}

        public SimpleButton(Texture2D backround, string name, int inputX, int inputY)
        {
            this.name = name;
            this.backround = backround;
            this.inputX = inputX;
            this.inputY = inputY;
            this.active = false;
        }
        public bool enterButton()
        {
            if (MouseInput.X < inputX + backround.Width &&
                    MouseInput.X > inputX &&
                    MouseInput.Y < inputY + backround.Height &&
                    MouseInput.Y > inputY)
            {
                return true;
            }
            return false;
        }

        public void Update(float delta)
        {
            if (enterButton() && MouseInput.LeftButton == ButtonState.Released && MouseInput.LeftButton == ButtonState.Pressed)
            {
                switch (name)
                {
                    case "Inventory": //the name of the button
                        
                        break;
                    default:
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backround, new Vector2(this.inputX, this.inputY), Color.Green);

        }
    
    }
}