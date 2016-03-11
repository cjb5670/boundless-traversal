using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Createing basic sprite objects These should be added to each class for the different objects
        Texture2D Floor; //Background used for each room
        Texture2D fullWall; //A wall that isnt open 
        Texture2D doorWall; //The wall with an opening for a door
        Texture2D sealedDoor; // a door that you cant walk through
        Texture2D openDoor; //Open door
        Texture2D Character; //The character's sprite
        Texture2D Enemy; //The enemy sprite
        Texture2D logo; //Game's logo
        //Game Objects
        Player player;
        KeyboardState kbState; //2 Keboard states for toggeling items
        KeyboardState previousKbState;
        enum GameState
        {
            MainMenu,
            PauseMenu,
            ItemMenu,
            PlayGame,
            Gameover
        }
        GameState state;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //This changes the size and location of the window dont mess with it
            graphics.HardwareModeSwitch = false;
            var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            form.Location = new System.Drawing.Point(-9, 0);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            state = GameState.MainMenu;
            player = new Player();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) //Readded for ease of update
                Exit();

            previousKbState = kbState;
            kbState = Keyboard.GetState();
            if (SingleKeyPress(Keys.F11)) //when F11 is pressed the game will toggle between fullscreen and windowed
            {
                graphics.ToggleFullScreen();
                graphics.ApplyChanges();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        //prevents a key from being pressed multiple times
        public bool SingleKeyPress(Keys k)
        {

            if (kbState.IsKeyDown(k) && previousKbState.IsKeyUp(k))
            { return true; }
            return false;
        }

        //Controls player wasd movement
        public void CharMovement(Character thing)
        {

        }
    }
}
