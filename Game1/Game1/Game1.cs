
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
        SpriteFont font;
        //Texture objects

        Texture2D Floor; //Background used for each room
        Texture2D fullWall; //A wall that isn't open 
        Texture2D doorWall; //The wall with an opening for a door
        Texture2D sealedDoor; // a door that you cant walk through
        Texture2D openDoor; //Open door
        Texture2D character; //The character's sprite
        Texture2D Enemy; //The enemy sprite
        Texture2D logo; //Game's logo
        Texture2D menuBG; //Background for menu screens

        //Game Objects

        Character mainChar;
        Enemy z1;
        KeyboardState kbState; //2 Keboard states for toggeling items
        KeyboardState previousKbState;
        Vector2 movement;
        int movespeed;
        float rotate;
        float rotate2;
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
        GameState state;

        //enum for player movement
        enum PlayerMovement
        {
            North,South,East,West,NorthEast,NorthWest,SouthEast,SouthWest,Static
        }
        PlayerMovement direction;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //This changes the size and location of the window don't mess with it
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
            //State initialization
            state = GameState.MainMenu;
            direction = PlayerMovement.Static;
            this.IsMouseVisible = true;

            //Game Object initialzation
            mainChar = new Character(500, 500, 34);
            mainChar.attackDamage = 10;
            mainChar.healthPoints = 100;

           
            

            movespeed = 10;
            

            //Setting walls
            walls = new Wall();
            topWall = walls.SetTopWall();
            bottomWall = walls.SetBottomWall();
            leftWall = walls.SetLeftWall();
            rightWall = walls.SetRightWall();
           
            z1 = new Enemy(800, 200, 123);
            z1.healthPoints = 10;
            z1.attackDamage = 5;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Creating Game Object sprites
            character = Content.Load<Texture2D>("Character.png");
            Enemy = Content.Load<Texture2D>("Enemy.png");
            font = Content.Load<SpriteFont>("Font");
            //Setting sprites
            mainChar.SetSprite(character);
            z1.SetSprite(Enemy);

            
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
            //Keyboard states
            previousKbState = kbState;
            kbState = Keyboard.GetState();

            //Gameplay states
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

            //Function for player movement
            CharacterMovement(mainChar);

            //Player-Wall collision
            mainChar.loc.Center.X = MathHelper.Clamp(mainChar.loc.Center.X, mainChar.loc.Radius+50, 1550-mainChar.loc.Radius);
            mainChar.loc.Center.Y = MathHelper.Clamp(mainChar.loc.Center.Y, mainChar.loc.Radius+50, 850 - mainChar.loc.Radius);

            //Exit on pressing escape
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) //Readded for ease of update
                Exit();

            //Rotates the character to the mouse
            ms = Mouse.GetState();
            float xdist = ms.X - mainChar.loc.Center.X;  
            float ydist = ms.Y - mainChar.loc.Center.Y; 
            rotate = (float)(System.Math.Atan2(ydist, xdist) + 1.570);

            //Rotates the enemy to the character
            rotate2 = Character.getAngleBetween(mainChar, z1);


            //Enemy AI function
            z1.followChar(mainChar);


            //Toggle between fullscreen and windowed with F11
            if (SingleKeyPress(Keys.F11)) 
            {
                graphics.ToggleFullScreen();
                graphics.ApplyChanges();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            string health = (mainChar.healthPoints).ToString();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(font,health , new Vector2(50, 40), Color.White);
            //Drawing Game Objects
            spriteBatch.Draw(mainChar.getSprite(), mainChar.loc.Center, null, Color.White, rotate, mainChar.origin, 1.0f, SpriteEffects.None, 0f);            
            spriteBatch.Draw(z1.getSprite(), z1.loc.Center, null, Color.White, rotate2, z1.origin, 1.0f, SpriteEffects.None, 0f);

            //States for animations and drawing
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

            //Drawing walls
            spriteBatch.Draw(fullWall, topWall, Color.White);
            spriteBatch.Draw(fullWall, bottomWall, Color.White);
            spriteBatch.Draw(fullWall, leftWall, Color.White);
            spriteBatch.Draw(fullWall, rightWall, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //Prevents a key from being pressed multiple times
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

            //move north
            if (kbState.IsKeyDown(Keys.W))
            {
                //move north west
                 if (kbState.IsKeyDown(Keys.A))
                {
                    movement = new Vector2(-speedmodifier, -speedmodifier);
                    
                }
                //move north east
                else if (kbState.IsKeyDown(Keys.D))
                    movement = new Vector2(speedmodifier, -speedmodifier);

                else
                    movement = new Vector2(0, -10);
            }

            //move south
            else if (kbState.IsKeyDown(Keys.S))
            {
                //move southwest
                if (kbState.IsKeyDown(Keys.A))
                    movement = new Vector2(-speedmodifier, speedmodifier);

                //move southeast
                else if (kbState.IsKeyDown(Keys.D))
                    movement = new Vector2(speedmodifier, speedmodifier);

                else
                    movement = new Vector2(0, 10);

            }

            //move west
            else if (kbState.IsKeyDown(Keys.A))
            {
                    movement = new Vector2(-10, 0);
            }

            //move east
            else if (kbState.IsKeyDown(Keys.D))
            {
                    movement = new Vector2(10, 0);
            }
            
            //when player is static    
            else
            {
                movement = new Vector2(0, 0);
            }

            mc.loc.Center += movement;
        }
        

    }
}
