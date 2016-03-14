
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        Texture2D menuBG; //Background for menu screens
        //Game Objects
        Player player;
        KeyboardState kbState; //2 Keboard states for toggeling items
        KeyboardState previousKbState;
        Vector2 movement;
        int movespeed;
        float rotate;
        MouseState ms;
        Wall walls;
        Rectangle topWall;
        Rectangle bottomWall;
        Rectangle leftWall;
        Rectangle rightWall;

        //enum for Game State
        enum GameState
        {
            MainMenu, PauseMenu, ItemMenu, PlayGame, Gameover
        }
        //enum for player movement
        enum PlayerMovement
        {
            North,South,East,West,NorthEast,NorthWest,SouthEast,SouthWest,Static
        }
        Character mainChar;
        PlayerMovement direction;
        GameState state;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //This changes the size and location of the window dont mess with it
            graphics.HardwareModeSwitch = false;

            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
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
            direction = PlayerMovement.Static;
            mainChar = new Character(500, 500, 34);
            this.IsMouseVisible = true;
            movespeed = 10;

            //wall object
            walls = new Wall();
            topWall = walls.SetTopWall();
            bottomWall = walls.SetBottomWall();
            leftWall = walls.SetLeftWall();
            rightWall = walls.SetRightWall();

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
            Character = Content.Load<Texture2D>("Character.png");
            mainChar.SetSprite(Character);
            // TODO: use this.Content to load your game content here
            
            //Floor = Content.Load<Texture2D>(); //Background used for each room
            fullWall = Content.Load<Texture2D>("wall.jpg"); //A wall that isnt open 
            //doorWall = Content.Load<Texture2D>(); //The wall with an opening for a door
            //sealedDoor = Content.Load<Texture2D>(); // a door that you cant walk through
            //openDoor = Content.Load<Texture2D>(); //Open door
            //Character = Content.Load<Texture2D>(); //The character's sprite
            //Enemy = Content.Load<Texture2D>(); //The enemy sprite
            //logo = Content.Load<Texture2D>(); //Game's logo
            menuBG = Content.Load<Texture2D>("oldpaper.jpg");
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
            previousKbState = kbState;
            kbState = Keyboard.GetState();

            switch (state)
            {
                case GameState.MainMenu:
                    break;
                case GameState.ItemMenu:
                    break;
                case GameState.PlayGame:
                     break;
                case GameState.PauseMenu:
                    break;
                case GameState.Gameover:
                    break;
            }

            CharacterMovement(mainChar);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) //Readded for ease of update
                Exit();
            ms = Mouse.GetState();
            //for some reason this gets more off when you move away from the origin so i put in a function to fix it while not exact, it works
            float xdist = ms.X - mainChar.loc.Center.X;  
            float ydist = ms.Y - mainChar.loc.Center.Y; 
            rotate = (float)(System.Math.Atan2(ydist, xdist) + 1.570);

            if (SingleKeyPress(Keys.F11)) //when F11 is pressed the game will toggle between fullscreen and windowed
            {
                graphics.ToggleFullScreen();
                graphics.ApplyChanges();
            }

            //walls.SetWalls(); //DON'T TOUCH THIS

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
            spriteBatch.Begin();
            spriteBatch.Draw(mainChar.getSprite(), mainChar.loc.Center, null, Color.White, rotate, mainChar.origin, 1.0f, SpriteEffects.None, 0f);            

            switch (state)
            {
                case GameState.MainMenu:
                    //spriteBatch.Draw(menuBG, destinationRectangle, null, Color.White);
                    //menu filler art
                    //spriteBatch.Draw(logo, logoPos, Color.White);
                    //main menu buttons
                    break;
                case GameState.ItemMenu:
                    //spriteBatch.Draw(menuBG, destinationRectangle, null, Color.White);
                    //spriteBatch.DrawString(font, "Item Menu:", textPos, Color.White);
                    break;
                case GameState.PlayGame:
                    //walls, doors textures
                    //floor texture
                    //health bar, current weapon box
                    //spriteBatch.Draw(Character, characterPos, Color.White);
                    //enemies
                    //collision animations (create a method for this)
                    break;
                case GameState.PauseMenu:
                    //spriteBatch.Draw(menuBG, destinationRectangle, null, Color.White);
                    //menu filler art
                    //spriteBatch.DrawString(font, "Game Paused", textPos, Color.White);
                    //pause menu buttons
                    break;
                case GameState.Gameover:
                    //game over background texture
                    //final stats
                    //buttons, back to main menu
                    break;
            }

            spriteBatch.Draw(fullWall, topWall, Color.White);
            spriteBatch.Draw(fullWall, bottomWall, Color.White);
            spriteBatch.Draw(fullWall, leftWall, Color.White);
            spriteBatch.Draw(fullWall, rightWall, Color.White);

            spriteBatch.End();


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
        public void CharacterMovement(Character mc)
        {
            /*Code when we choose to use enums for player movement when we implement animations
            switch(direction)
            {
                case PlayerMovement.North:
                    break;
                case PlayerMovement.South:
                    break;
                case PlayerMovement.West:
                    break;
                case PlayerMovement.East:
                    break;
                case PlayerMovement.NorthWest:
                    break;
                case PlayerMovement.NorthEast:
                    break;
                case PlayerMovement.SouthEast:
                    break;
                case PlayerMovement.SouthWest:
                    break;
                case PlayerMovement.Static:
                    break;
              }
            */
            //Basic movement code for testing
            float speedmodifier = (float)(Math.Cos(0.785398) * movespeed);
            if (kbState.IsKeyDown(Keys.W))
            {
                 if (kbState.IsKeyDown(Keys.A))
                    movement = new Vector2(-speedmodifier, -speedmodifier);
                else if (kbState.IsKeyDown(Keys.D))
                    movement = new Vector2(speedmodifier, -speedmodifier);
                else
                    movement = new Vector2(0, -10);
            }
            else if (kbState.IsKeyDown(Keys.S))
            {
                if (kbState.IsKeyDown(Keys.A))
                    movement = new Vector2(-speedmodifier, speedmodifier);
                else if (kbState.IsKeyDown(Keys.D))
                    movement = new Vector2(speedmodifier, speedmodifier);
                else
                    movement = new Vector2(0, 10);

            }
            else if (kbState.IsKeyDown(Keys.A))
            {
                if (kbState.IsKeyDown(Keys.W))
                    movement = new Vector2(-speedmodifier, -speedmodifier);
                else if (kbState.IsKeyDown(Keys.S))
                    movement = new Vector2(-speedmodifier, speedmodifier);
                else
                    movement = new Vector2(-10, 0);
            }
            else if (kbState.IsKeyDown(Keys.D))
            {
                if (kbState.IsKeyDown(Keys.W))
                    movement = new Vector2(speedmodifier, -speedmodifier);
                else if (kbState.IsKeyDown(Keys.S))
                    movement = new Vector2(speedmodifier, speedmodifier);
                else
                    movement = new Vector2(10, 0);
                
            }
            else
            {
                movement = new Vector2(0, 0);
            }

            mc.loc.Center += movement;
        }
    }
}
