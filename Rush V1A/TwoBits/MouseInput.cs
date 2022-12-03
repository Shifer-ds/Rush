using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using lib.Graphics;

namespace lib.Input
{
    public sealed class MouseInput
    {
        private static readonly Lazy<MouseInput> Lazy = new Lazy<MouseInput>(()=> new MouseInput());
        public static MouseInput Instance
        {
            get {return Lazy.Value;}
        }
        private MouseState prevMouseState;
        private MouseState currMouseState;

        public Point windowPosition
        {
            get { return this.currMouseState.Position; }
        }

        public MouseInput()
        {
            this.prevMouseState = Mouse.GetState();
            this.currMouseState = this.prevMouseState;
        }
        public void Update()
        {
            this.prevMouseState = this.currMouseState;
            this.currMouseState = Mouse.GetState();
        }
        public bool IsLeftButtonDown()
        {
            return this.currMouseState.LeftButton == ButtonState.Pressed;
        }
        public bool LeftButtonClick()
        {
            return this.currMouseState.LeftButton == ButtonState.Pressed && this.prevMouseState.LeftButton == ButtonState.Released;
        }

        public bool IsRightButtonDown()
        {
            return this.currMouseState.RightButton == ButtonState.Pressed;
        }
        public bool RightButtonClick()
        {
            return this.currMouseState.RightButton == ButtonState.Pressed && this.prevMouseState.RightButton == ButtonState.Released;
        }
        public Vector2 GetScreenPosition(WindowRez screen)
        {
            Rectangle screenDestinationRectangle = screen.CalculateDestinationRectangle();
            Point windowPosition = this.windowPosition;
            float sx = (float)windowPosition.X - screenDestinationRectangle.X;
            float sy = (float)windowPosition.Y - screenDestinationRectangle.Y;

            sx /= (float)screenDestinationRectangle.Width;
            sy /= (float)screenDestinationRectangle.Height;

            sx *= (float)screen.Width;
            sy *= (float)screen.Height;

            sy = (float)screen.Height -sy;
            return new Vector2(sx,sy);

        }
    }
}