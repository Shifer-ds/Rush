using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace GSM
{
    /// <summary>
    /// This class is a collection/stack of active screens in the game.
    /// A game should have one screen manager and control the active screens by 
    /// adding and removing screens from this manager.
    /// 
    /// The top screen of the stack will be updated and the top screens that are 
    /// translucent will be drawn. The first screen on the stack that isn't translucent
    /// will stop the drawing.
    /// 
    /// In Game:
    /// public ScreenManager Screens { get; private set; }
    /// 
    /// In Game.Initialize():
    /// this.Components.Add( this.Screens = new ScreenManager(this, new StartScreen(this)) );
    /// 
    /// </summary>
    /// By Koen Bollen, 2011
    public class ScreenManager
    {
        /// <summary>
        /// This boolean is set when the Initialize() method is called.
        /// </summary>
        public bool Initialized { get; private set; }

        /// <summary>
        /// This is the list of active screens in the game.
        /// </summary>
        private Stack<IScreens> screens;

        public ScreenManager(Game game)
        {
            this.screens = new Stack<IScreens>();
            this.Initialized = false;
        }

        /// <summary>
        /// Only update the top of the screen stack.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            this.screens.Peek().Update(gameTime);
        }

        /// <summary>
        /// Draw all visible screens. A screen that is not translucent will stop the iteration of screens.
        /// </summary>
        public void Draw(GameTime gameTime)
        {
            List<IScreens> visible = new List<IScreens>();
            foreach (IScreens s in this.screens)
            {
                visible.Add(s);
                if (!s.Translucent)
                    break;
            }

            // Draw from back to front:
            for( int i = visible.Count-1; i >= 0; i-- )
                visible[i].Draw(gameTime);

        }

        /// <summary>
        /// Add a screen to the top of the stack, if the manager is initialized but the screen isn't initialize it.
        /// Also set it's manager to this.
        /// </summary>
        /// <param name="screen">The screen to add.</param>
        public void Push(IScreens screen)
        {
            this.screens.Push(screen);
        }

        /// <summary>
        /// Get the top of the screen stack. The most active screen.
        /// </summary>
        /// <returns>The active screen.</returns>
        public IScreens Peek()
        {
            return this.screens.Peek();
        }

        /// <summary>
        /// Remove a screen from the screen stack.
        /// </summary>
        /// <returns>The removed screen.</returns>
        public IScreens Pop()
        {
            return this.screens.Pop();
        }
    }
}