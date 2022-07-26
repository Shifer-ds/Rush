using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Utilities;

namespace lib.Graphics
{
    public sealed class WindowRez : IDisposable
    {
        private readonly static int MinDim = 64;
        private readonly static int MaxDim = 4096;

        private bool isDisposed;
        private bool isSet;          
        private Game game;
        private RenderTarget2D target;
        public int Height
        {
            get {return this.target.Height;}
        }
        public int Width
        {
            get {return this.target.Width;}
        }

        public WindowRez(Game game, int width, int height)
        {
            width = Utils.Clamp(width, WindowRez.MinDim, WindowRez.MaxDim);
            height = Utils.Clamp(height, WindowRez.MinDim, WindowRez.MaxDim);

            this.game = game ?? throw new ArgumentNullException("no game!!!");

            this.target = new RenderTarget2D(this.game.GraphicsDevice, width, height);
            this.isSet = false;
        }
        public void Dispose()
        {
            if(this.isDisposed)
            {
                return;
            }
            this.target?.Dispose();
            this.isDisposed = true;
        }
        public void Set()
        {
            if(this.isSet)
            {
                throw new Exception("Render target is already set");
            }
            this.game.GraphicsDevice.SetRenderTarget(this.target);
            this.isSet = true;
        }
        public void unSet()
        {
            if(!this.isSet)
            {
                throw new Exception("Render target is already UNset");
            }
            this.game.GraphicsDevice.SetRenderTarget(null);
            this.isSet = false;
        }
        public void Present(Sprites _sprites, bool isTextureFileteringEnabled= true)
        {
            if(_sprites is null)
            {
                throw new ArgumentNullException("sprites is null");
            }
#if DEBUG
            this.game.GraphicsDevice.Clear(Color.HotPink);
#else
            this.game.GraphicsDevice.Clear(Color.Black);
#endif
            Rectangle destinationRectangle = this.CalculateDestinationRectangle();
            _sprites.Begin(isTextureFileteringEnabled);
            _sprites.Draw(this.target,null,destinationRectangle, Color.White);
            _sprites.End();
        }
        public Rectangle CalculateDestinationRectangle()
        {
            Rectangle backbufferBounds = this.game.GraphicsDevice.PresentationParameters.Bounds;
            float backbufferAspectRatio = (float)backbufferBounds.Width/ backbufferBounds.Height;
            float screenAspectRatio = (float)this.Width/this.Height;
            float rx = 0f;
            float ry = 0f;
            float rw = backbufferBounds.Width;
            float rh = backbufferBounds.Height;

            if(backbufferAspectRatio> screenAspectRatio)
            {
                rw = rh * screenAspectRatio;
                rx = ((float)backbufferBounds.Width-rw)/ 2f;
            }
            if(backbufferAspectRatio< screenAspectRatio)
            {
                rh = rw / screenAspectRatio;
                ry = ((float)backbufferBounds.Height-rh)/ 2f;
                
            }

            Rectangle result = new Rectangle((int)rx,(int)ry,(int)rw,(int)rh);
            return result;
        }

    }
}
