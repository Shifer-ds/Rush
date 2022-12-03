using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace lib.Graphics
{
    public sealed class Sprites : IDisposable
    {
        private bool isDisposed;
        private Game game;
        private SpriteBatch _Sprites;
        private BasicEffect effect;
        private SpriteFont gameFont;
        public Sprites(Game game)
        {
            if(game is null)
            {
                throw new ArgumentNullException("game");
            }
            this.game = game;
            this.isDisposed = false;
            this._Sprites = new SpriteBatch(this.game.GraphicsDevice);
            this.effect = new BasicEffect(this.game.GraphicsDevice);
            this.effect.FogEnabled = false;
            this.effect.TextureEnabled = true;
            this.effect.LightingEnabled = false;
            this.effect.VertexColorEnabled = true;
            this.effect.World = Matrix.Identity;
            this.effect.Projection = Matrix.Identity;
            this.effect.View = Matrix.Identity;
        }
        public void Dispose()
        {
            if(this.isDisposed)
            {
                return;
            }
            this.effect?.Dispose();
            this._Sprites?.Dispose();
            this.isDisposed = true;
        }
        public void setFont(SpriteFont font)
        {
            this.gameFont = font;
        }
        public void Begin(bool isTextureFileteringEnabled)
        {
            SamplerState sampler = SamplerState.PointClamp;
            if(isTextureFileteringEnabled)
            {
                sampler = SamplerState.LinearClamp;
            }
            Viewport vp = this.game.GraphicsDevice.Viewport;
            this.effect.Projection = Matrix.CreateOrthographicOffCenter(0,vp.Width, 0, vp.Height, 0f, 1f);
            this._Sprites.Begin(blendState: BlendState.AlphaBlend, samplerState: sampler, rasterizerState: RasterizerState.CullNone, effect:this.effect);

        }
        public void End()
        {
            this._Sprites.End();
        }
        public void Draw(Texture2D texture, Vector2 origin, Vector2 position, Color color)
        {
            this._Sprites.Draw(texture, position, null, color, 0f, origin, 1f, SpriteEffects.FlipVertically, 0f);
        }


        
        public void Draw(Texture2D texture, Rectangle? sourceRectangle, Rectangle destinationRectangle, Color color)
        {
            this._Sprites.Draw(texture, destinationRectangle, sourceRectangle, color, 0f, Vector2.Zero, SpriteEffects.FlipVertically, 0f);
        }

        // if you need only part of texture
        public void Draw(Texture2D texture, Rectangle? sourceRectangle, Vector2 origin, Vector2 position, float rotation, Vector2 scale, Color color)
        {
            this._Sprites.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, SpriteEffects.FlipVertically, 0f);
        }
        public void DrawString(SpriteFont gameFont, string name, Vector2 origin, Vector2 position, float rotation, Vector2 scale, Color color)
        {
            this._Sprites.DrawString(gameFont, name, position, color, rotation, origin, scale, SpriteEffects.FlipVertically, 0f);
        }
        public void DrawString(string name, Vector2 position, Color color)
        {
            this._Sprites.DrawString(this.gameFont, name, position, color, 0f,new Vector2(0,0), new Vector2(1f,1f), SpriteEffects.FlipVertically, 0f);
        }

    }
}
