
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    public class Game1 : Game
    {

        #region DrawingObjects
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        //Texture objects

        Texture2D Floor; //Background used for each room
        Texture2D fullWall; //A wall that isn't open 
        Texture2D doorWall; //The wall with an opening for a door
        Texture2D sealedVDoor; // a vertical door that you cant walk through
        Texture2D sealedHDoor; // a horizontal door that you cant walk through
        //Texture2D openDoor; //Open door
        Texture2D openVDoor; //a vertical door that you CAN walk through
        Texture2D openHDoor; // a horizontal door that you CAN walk through
        Texture2D character; //The character's sprite
        Texture2D EnemySprite; //The enemy sprite
        Texture2D dropSprite;//Sprite for collectible
        Texture2D menuBG; //Background for menu screens
        Texture2D sword;
        Texture2D healthBar;
        Texture2D fullHealthBar;
        Texture2D wallTexture;
        Texture2D vWallTexture;
        //Game Objects

        Texture2D ItemMenu;
        Texture2D Logo;
        Texture2D MenuBack;
        Texture2D ButtonBack;
        Texture2D ButtonPressed;
        //Texture2D RIP;
        Texture2D Medal;
        Texture2D GoldMedal;
        Texture2D SilverMedal;
        Texture2D BronzeMedal;
        Texture2D TinMedal;
        Texture2D StatSetterup;
		Texture2D StatSetterdown;
        Rectangle LogoLoc;
        Rectangle StatsLoc;
        Rectangle FullScreen;
        //Rectangle RIPloc;
        Rectangle MedalLoc;
        Rectangle UpArrow;
        Rectangle DownArrow;
        Vector2 CenterScreen;
        string MainMenuText;
        string ItemMenuText;
        string PauseMenuText;
        string GameOverText;
        #endregion

        #region GameObjects


        Character mainChar;
        bool attackcd;
        KeyboardState kbState; //2 Keboard states for toggeling items
        KeyboardState previousKbState;
        Vector2 movement;
        Weapon blade;
        float movespeed;
        float rotate;
        float rotate2;
		MouseState ms;
		MouseState previousms;
        bool leftMousePress;
        bool rightMousePress;
        int cd;
        int enemyNo;
        Button SetStats;
        Button Play;
        Button Resume;
        Button Restart;
        Button Quit;
        public Button upStr;
        public Button downStr;
		public Button upDex;
		public Button downDex;
		public Button upCon;
		public Button downCon;
		Rectangle buttonPosSetStats;
		Rectangle buttonPosPlay;
		Rectangle buttonPosResume;
		Rectangle buttonPosRestart;
        Rectangle buttonPosQuit;
		public Rectangle upStrPos;
		public Rectangle downStrPos;
		public Rectangle upDexPos;
		public Rectangle downDexPos;
		public Rectangle upConPos;
		public Rectangle downConPos;
		StatList PlayerStats;
        Floor testFloor;
        int frameCountDraw;
        #endregion

        #region Animation
        // Animation
        Texture2D characterAnimated;    //walking animation spritesheet

        int frame;              // The current animation frame
        double timeCounter;     // The amount of time that has passed
        double fps;             // The speed of the animation
        double timePerFrame;    // The amount of time (in fractional seconds) per frame

        const int WalkFrameCount = 6;		// The number of frames in the animation
        const int vikingRectOffsetY = 0;	// How far down in the image are the frames?
        const int vikingRectHeight = 100;		// The height of a single frame
        const int vikingRectWidth = 100;        // The width of a single frame
        #endregion

        //enum for Game State
        enum GameState
        {
            MainMenu, PauseMenu, ItemMenu, PlayGame, Gameover
        }
        GameState state;

        //enum for player movement
        enum PlayerMovement
        {
            North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest, Static
        }
        PlayerMovement direction;


        //Constructor
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
        /// 
        protected override void Initialize()
        {
            //State initialization
            state = GameState.MainMenu;
            direction = PlayerMovement.Static;
            this.IsMouseVisible = true;

            //Game Object initialzation
            PlayerStats = new StatList();
            mainChar = new Character(500, 500, 35);
            mainChar.attackDamage = 10;
            mainChar.healthPoints = 50 * PlayerStats.constitution;
            mainChar.maxHP = mainChar.healthPoints;
            blade = new Weapon(mainChar);
            mainChar.XP = 0;
            mainChar.level = 1;
            movespeed = 10;
            cd = 0;
            attackcd = false;
            enemyNo = 3;

            //Animation Initialization
            fps = 10;
            timePerFrame = 1.0 / fps;
            

            //Setting walls

            // Menu Setup Buttons
            FullScreen = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            CenterScreen = new Vector2(280, 500);
            LogoLoc = new Rectangle(335, 250, 1000, 115);
            StatsLoc = new Rectangle(335, 85, 1000, 750);
            //RIPloc = new Rectangle(800, 250, 500, 500);
            MedalLoc = new Rectangle(900, 150, 500, 600);

			buttonPosSetStats = new Rectangle(650, 720, 280, 80);
			SetStats = new Button(buttonPosSetStats, buttonPosSetStats.X, buttonPosSetStats.Y);
			
			buttonPosPlay = new Rectangle(700, 745, 150, 80);
			Play = new Button(buttonPosPlay, buttonPosPlay.X, buttonPosPlay.Y);

			buttonPosResume = new Rectangle(700, 720, 240, 80);
			Resume = new Button(buttonPosResume, buttonPosResume.X, buttonPosResume.Y);
			
			//buttonPosRestart = new Rectangle(500, 720, 240, 80);
            buttonPosRestart = new Rectangle(350, 570, 230, 80);
            Restart = new Button(buttonPosRestart, buttonPosRestart.X, buttonPosRestart.Y);

            //buttonPosQuit = new Rectangle(900, 720, 140, 80);
            buttonPosQuit = new Rectangle(392, 680, 140, 80);
            Quit = new Button(buttonPosQuit, buttonPosQuit.X, buttonPosQuit.Y);



            // All stat buttons
            upStrPos = new Rectangle(1080, 393, 50, 50);
			downStrPos = new Rectangle(915, 393, 48, 48);
			upDexPos = new Rectangle(1080, 520, 50, 50);
			downDexPos = new Rectangle(915, 520, 48, 48);
			upConPos = new Rectangle(1080, 647, 50, 50);
			downConPos = new Rectangle(915, 647, 48, 48);

			
			upStr = new Button(upStrPos, upStrPos.X, upStrPos.Y);
			downStr = new Button(downStrPos, downStrPos.X, downStrPos.Y);
			upDex = new Button(upDexPos, upDexPos.X, upDexPos.Y);
			downDex = new Button(downDexPos, downDexPos.X, downDexPos.Y);
			upCon = new Button(upConPos, upConPos.X, upConPos.Y);
			downCon = new Button(downConPos, downDexPos.X, downConPos.Y);

            frameCountDraw = 61;


			testFloor = new Floor(3, 3, 1);           

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
            //character = Content.Load<Texture2D>("Character.png");
            character = Content.Load<Texture2D>("vikingCharacter.png");
            EnemySprite = Content.Load<Texture2D>("ratEnemy.png");
            font = Content.Load<SpriteFont>("Font");
            sword = Content.Load<Texture2D>("sword.png");
            sealedVDoor = Content.Load<Texture2D>("vClosedDoor.png");
            sealedHDoor = Content.Load<Texture2D>("hClosedDoor.png");
            openVDoor = Content.Load<Texture2D>("vOpenDoor.png");
            openHDoor = Content.Load<Texture2D>("hOpenDoor.png");
            MenuBack = Content.Load<Texture2D>("oldpaper.jpg");
            Logo = Content.Load<Texture2D>("PlaceholderLogo.png");
            ItemMenu = Content.Load<Texture2D>("PlaceholderStats.png");
            //RIP = Content.Load<Texture2D>("RIP.jpg");
            Medal = Content.Load<Texture2D>("gold-medal.jpg");
            GoldMedal = Content.Load<Texture2D>("medalGold.png");
            SilverMedal = Content.Load<Texture2D>("medalSilver.png");
            BronzeMedal = Content.Load<Texture2D>("medalBronze.png");
            TinMedal = Content.Load<Texture2D>("medalTin.png");
            ButtonBack = Content.Load<Texture2D>("buttonTemplate.png");
            StatSetterup = Content.Load<Texture2D>("arrowButtonUp.png");
			StatSetterdown = Content.Load<Texture2D>("arrowButtonDown.png");
            ButtonPressed = Content.Load<Texture2D>("Test.png");
            dropSprite = Content.Load<Texture2D>("heart.png");

            
            //Setting sprites
            blade.setWeaponSprite(sword);
            mainChar.SetSprite(character);
            //mainChar.SetSprite(characterAnimated);

            //Animation Content
            characterAnimated = Content.Load<Texture2D>("walkingAnim.png");
            //mainChar.SetSprite(characterAnimated);




            //Floor = Content.Load<Texture2D>(); //Background used for each room
            wallTexture = Content.Load<Texture2D>("hWall.png"); //A wall that isnt open
            vWallTexture = Content.Load<Texture2D>("vWall.png"); //vertical wall texture (not open)
            
            testFloor.currentRoom.SetWallTexture(wallTexture, vWallTexture);
            //testFloor.currentRoom.SetWalls();
            /*
            testFloor.currentRoom.leftWall.wallDoor.SetSprite(sealedVDoor);
            testFloor.currentRoom.topWall.wallDoor.SetSprite(sealedHDoor);
            testFloor.currentRoom.rightWall.wallDoor.SetSprite(sealedVDoor);
            testFloor.currentRoom.bottomWall.wallDoor.SetSprite(sealedHDoor);
            */

            testFloor.drawFloor(wallTexture, vWallTexture, sealedHDoor, sealedVDoor);
            
            //doorWall = Content.Load<Texture2D>(); //The wall with an opening for a door
            //sealedDoor = Content.Load<Texture2D>(); // a door that you cant walk through
            //openDoor = Content.Load<Texture2D>(); //Open door
            //Character = Content.Load<Texture2D>(); //The character's sprite
            //Enemy = Content.Load<Texture2D>(); //The enemy sprite
            //logo = Content.Load<Texture2D>(); //Game's logo

            //Setting room enemies and their textures   
            testFloor.enterRoom();
            testFloor.currentRoom.SetEnemies(EnemySprite, 3);
            testFloor.currentRoom.SpawnEnemies();
            int x = testFloor.currentRoom.xPos;
            int y = testFloor.currentRoom.yPos;

            if (testFloor.checkLeftDoor(x, y))
            {
                testFloor.currentRoom.SetDoor("left");
            }
            if (testFloor.checkUpperDoor(x, y))
            {
                testFloor.currentRoom.SetDoor("top");
            }
            if (testFloor.checkRightDoor(x, y))
            {
                testFloor.currentRoom.SetDoor("right");
            }
            if (testFloor.checkLowerDoor(x, y))
            {
                testFloor.currentRoom.SetDoor("bottom");
            }
            testFloor.currentRoom.SetEB();

            healthBar = Content.Load<Texture2D>("health.png");
            fullHealthBar = Content.Load<Texture2D>("health.png");
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
                #region MainMenu
                case GameState.MainMenu:
                    ResetGame();
					
					if (ButtonPress(SetStats) == true)
                    {
                        state = GameState.ItemMenu;
                    }
                    break;
                #endregion

                #region ItemMenu
                case GameState.ItemMenu:
					// Has button size


                    if (ButtonPress(Play) &&
                        PlayerStats.totalStats == 0)
                    {
                        ReCheckStats();
                        state = GameState.PlayGame;
                    }

					if (upStr.enterButton() && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
						PlayerStats.upStr();
					else if (downStr.enterButton() && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
						PlayerStats.downStr();
					else if (upDex.enterButton() && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
						PlayerStats.upDex();
					else if (downDex.enterButton() && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
						PlayerStats.downDex();
					else if (upCon.enterButton() && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
						PlayerStats.upCon();
					else if (downCon.enterButton() && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
						PlayerStats.downCon();


					break;
                #endregion

                #region PlayGame
                case GameState.PlayGame:
                    if (mainChar.healthPoints <= 0)
                    { state = GameState.Gameover; }
                    else if (SingleKeyPress(Keys.P) == true)
                    { state = GameState.PauseMenu; }


                    //Player walking animation
                    UpdateAnimation(gameTime);

                    //Function for player movement
                    CharacterMovement(mainChar);

                    if (testFloor.isFloorClear())
                    {
                        testFloor.changeFloors();
                        testFloor.currentRoom = testFloor.enterDoor(mainChar);
                        testFloor.currentRoom.SetEnemies(EnemySprite, 3);
                        testFloor.currentRoom.SpawnEnemies();

                    }

                    #region CharCollision
                    else if (testFloor.currentRoom.RoomClear())
                    {
                        if (testFloor.currentRoom.RoomExit(mainChar))
                        {
                            testFloor.currentRoom = testFloor.enterDoor(mainChar);                            
                            int x = testFloor.currentRoom.xPos;
                            int y = testFloor.currentRoom.yPos;

                            if (testFloor.checkLeftDoor(x, y))
                            {
                                testFloor.currentRoom.SetDoor("left");
                            }
                            if (testFloor.checkUpperDoor(x, y))
                            {
                                testFloor.currentRoom.SetDoor("top");
                            }
                            if (testFloor.checkRightDoor(x, y))
                            {
                                testFloor.currentRoom.SetDoor("right");
                            }
                            if (testFloor.checkLowerDoor(x, y))
                            {
                                testFloor.currentRoom.SetDoor("bottom");
                            }
                            testFloor.currentRoom.SetEB();
                            if (!testFloor.currentRoom.isCleared)
                            {
                                testFloor.currentRoom.SetEnemies(EnemySprite, 3);
                                testFloor.currentRoom.SpawnEnemies();
                            }
                            

                        }

                    }
                    else
                    {
                        //Player-Wall collision
                        mainChar.loc.Center.X = MathHelper.Clamp(mainChar.loc.Center.X, mainChar.loc.Radius + 50, 1550 - mainChar.loc.Radius);
                        mainChar.loc.Center.Y = MathHelper.Clamp(mainChar.loc.Center.Y, mainChar.loc.Radius + 50, 850 - mainChar.loc.Radius);
                    }

                    foreach (Collectible drop in testFloor.currentRoom.drops)
                    {
                        drop.playerIntersect(mainChar);                     

                    }

                    for(int i = 0; i < testFloor.currentRoom.drops.Count; i++)
                    {
                      
                        if(testFloor.currentRoom.drops[i].picked)
                            testFloor.currentRoom.drops.Remove(testFloor.currentRoom.drops[i]);

                    }
                    #endregion

                    //Rotates the character to the mouse
                    #region CharRotate
                    ms = Mouse.GetState();
                    float xdist = ms.X - mainChar.loc.Center.X;
                    float ydist = ms.Y - mainChar.loc.Center.Y;
                    rotate = (float)(System.Math.Atan2(ydist, xdist) + 1.570);
                    #endregion


                    blade.moveWeapon(mainChar, rotate);

                    if (ms.LeftButton == ButtonState.Pressed && cd == 0 )
                    {
                        attackcd = true;
                    }

                    if (attackcd)
                        {
                            if (blade.swingtime < 16)
                            {
                            movespeed = 5 + (2*PlayerStats.dexterity);
                                leftMousePress = true;
                                foreach (Enemy e in testFloor.currentRoom.enemies)
                                {

                                    if (e.playerIntersect(blade) && e.checkAlive())
                                    {
                                        Character.charHit(mainChar, e);

                                         if (!e.checkAlive())
                                         {
                                        mainChar.enemiesKilled++;
                                        testFloor.currentRoom.SpawnCollectible(dropSprite, e.loc.Center.X, e.loc.Center.Y);
                                         }

                                        if (mainChar.CheckXP())
                                         {
                                             PlayerStats.constitution++;
                                             PlayerStats.dexterity++;
                                             PlayerStats.strength++;
                                             frameCountDraw = 0;

                                    }

                                    }
                    

                                }
                                blade.swingtime++;
                               
                            }
                            else
                            {
                            movespeed = 10 + (2*PlayerStats.dexterity);
                                leftMousePress = false;
                                cd = 40 - PlayerStats.dexterity*5;
                                attackcd = false;
                            }

                        }
                    else
                    {
                        leftMousePress = false;
                        blade.swingtime = 0;
                        if (cd != 0)
                        {
                            cd--;
                        }
                    }

                    


                    #region EnemyAI
                    //Enemy AI function
                    for (int i = 0; i < testFloor.currentRoom.enemies.Count; i++)
                    {
                        //Rotates the enemy to the character
                        if (testFloor.currentRoom.enemies[i].checkAlive())
                        {

                            rotate2 = Character.getAngleBetween(mainChar, testFloor.currentRoom.enemies[i]);
                            testFloor.currentRoom.enemies[i].followChar(mainChar);

                        }

                    }

                    #endregion

                    break;


                #endregion

                #region PauseMenu
                                case GameState.PauseMenu:
                                    // Has button size
                    

                                    if (ButtonPress(Resume) == true || (SingleKeyPress(Keys.P) == true))
                                        state = GameState.PlayGame;
                                    break;
                #endregion

                #region Gameover
                case GameState.Gameover:
					
                    if (ButtonPress(Restart) == true)
                        state = GameState.MainMenu;

                    if (Quit.enterButton() && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
                        Exit();

                    break;
                    #endregion
            }



            //Exit on pressing escape
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) //Readded for ease of update
                Exit();



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            //States for animations and drawing
            switch (state)
            {
                #region Mainmenu
                case GameState.MainMenu:
                    //menu filler art

                    spriteBatch.Draw(MenuBack, FullScreen, Color.White);
                    MainMenuText = "       Fight off enemies and try not to die! \nWASD to move, and click to swing your sword.\n       Press 'Set Stats' to build a character.";
                    spriteBatch.Draw(Logo, LogoLoc, Color.White);

                    // Button drawing and logic
                    spriteBatch.Draw(ButtonBack, buttonPosSetStats, Color.White);
                    if (SetStats.enterButton() == true)
                    { spriteBatch.Draw(ButtonBack, buttonPosSetStats, Color.SandyBrown); }
                    if (SetStats.enterButton() == true && ms.LeftButton == ButtonState.Pressed)
                    { spriteBatch.Draw(ButtonPressed, buttonPosSetStats, Color.White); }
                    spriteBatch.DrawString(font, MainMenuText, CenterScreen, Color.SaddleBrown);
                    spriteBatch.DrawString(font, "Set Stats", new Vector2(buttonPosSetStats.X + 32, buttonPosSetStats.Y + 8), Color.Silver);

                    break;
                #endregion

                #region Itemmenu
                case GameState.ItemMenu:
					

					spriteBatch.Draw(MenuBack, FullScreen, Color.White);
					

					ItemMenuText = 
                        "\n \n" +                     
                        "                       Select where to allocate your stats!" +
                        "\n" +
                        "\n                               Points Left to Spend: " + PlayerStats.totalStats +
                        "\n \n" +
                        "                       Strength(Damage):          " + PlayerStats.strength +
                        "\n \n" +
                        "                       Dexterity(Speed):            " + PlayerStats.dexterity +
                        "\n \n" +
                        "                       Constitution(Health):       " + PlayerStats.constitution;

                    spriteBatch.DrawString(font, ItemMenuText, new Vector2(0, 0), Color.SaddleBrown);

                    // Has button location

                    if (PlayerStats.totalStats != 0) 
                    spriteBatch.Draw(ButtonBack, buttonPosPlay, Color.Gray);

                    else
                    {
                        spriteBatch.Draw(ButtonBack, buttonPosPlay, Color.White);
                        if (Play.enterButton() == true)
                        { spriteBatch.Draw(ButtonBack, buttonPosPlay, Color.SandyBrown); }
                        if (Play.enterButton() == true && ms.LeftButton == ButtonState.Pressed)
                        { spriteBatch.Draw(ButtonPressed, buttonPosPlay, Color.White); }
                    }
                    spriteBatch.DrawString(font, "Play", new Vector2(buttonPosPlay.X + 28, buttonPosPlay.Y + 8), Color.Silver);





                    // Button Draw Logic
                    spriteBatch.Draw(StatSetterup, upStrPos, Color.Brown);
                    if (upStr.enterButton() == true)
                        spriteBatch.Draw(StatSetterup, upStrPos, Color.SandyBrown);

                    spriteBatch.Draw(StatSetterdown, downStrPos, Color.Brown);
                    if (downStr.enterButton() == true)
                        spriteBatch.Draw(StatSetterdown, downStrPos, Color.SandyBrown);

                    spriteBatch.Draw(StatSetterup, upDexPos, Color.Brown);
                    if (upDex.enterButton() == true)
                        spriteBatch.Draw(StatSetterup, upDexPos, Color.SandyBrown);

                    spriteBatch.Draw(StatSetterdown, downDexPos, Color.Brown);
                    if (downDex.enterButton() == true)
                        spriteBatch.Draw(StatSetterdown, downDexPos, Color.SandyBrown);

                    spriteBatch.Draw(StatSetterup, upConPos, Color.Brown);
                    if (upCon.enterButton() == true)
                        spriteBatch.Draw(StatSetterup, upConPos, Color.SandyBrown);

                    spriteBatch.Draw(StatSetterdown, downConPos, Color.Brown);
                    if (downCon.enterButton() == true)
                        spriteBatch.Draw(StatSetterdown, downConPos, Color.SandyBrown);




                    break;
                #endregion

                #region Playgame
                case GameState.PlayGame:
                    //walls, doors textures
                    //floor texture
                    //health bar, current weapon box
                    //spriteBatch.Draw(Character, characterPos, Color.White);
                    //enemies
                    //collision animations (create a method for this)
                    string health = (mainChar.healthPoints).ToString();
                    if (testFloor.floorNum % 4 == 0)
                        GraphicsDevice.Clear(Color.Sienna);
                    else if (testFloor.floorNum % 3 == 0)
                        GraphicsDevice.Clear(Color.Maroon);
                    else if (testFloor.floorNum % 2 == 0)
                        GraphicsDevice.Clear(Color.IndianRed);
                    else
                        GraphicsDevice.Clear(Color.SaddleBrown);

                    spriteBatch.DrawString(font, health, new Vector2(50, 40), Color.White);



                    //Drawing Game Objects
                    //spriteBatch.Draw(mainChar.getSprite(), mainChar.loc.Center, null, Color.White, rotate, mainChar.origin, 1.0f, SpriteEffects.None, 0f);
                    DrawCharacterWalking(rotate, mainChar.origin);

                    //Drawing enemies
                    for (int i = 0; i < testFloor.currentRoom.enemies.Count; i++)
                    {
                        Enemy enemyTemp = testFloor.currentRoom.enemies[i];


                        if (enemyTemp.checkAlive())
                            spriteBatch.Draw(testFloor.currentRoom.enemies[i].getSprite(), testFloor.currentRoom.enemies[i].loc.Center, null, Color.White, rotate2, testFloor.currentRoom.enemies[i].origin, 1.0f, SpriteEffects.None, 0f);
                    }


                    if (leftMousePress)
                    {

                        spriteBatch.Draw(blade.getSprite(), blade.loc.Center, null, Color.White, rotate + 3.926f - 0.1047f * blade.swingtime, blade.origin, 0.65f, SpriteEffects.None, 0f);


                    }

                    // Healthbar
                    spriteBatch.Draw(fullHealthBar, new Rectangle(150, 50, (int)mainChar.maxHP * 2, 40), Color.Black);
                    spriteBatch.Draw(healthBar, new Rectangle(150, 50, (int)mainChar.healthPoints * 2, 40), Color.White);

                    // Other UI
                    spriteBatch.DrawString(font, "Level " + mainChar.level, new Vector2((int)mainChar.maxHP * 2 +200 , 40), Color.Green);
                    spriteBatch.DrawString(font, "Floor " + testFloor.floorNum, new Vector2((int)mainChar.maxHP * 2 + 400, 40), Color.Silver);

                    //Drawing walls
                    testFloor.currentRoom.DrawWalls(spriteBatch);
                    // testFloor.currentRoom.SetDoorSprite(sealedVDoor, sealedHDoor);
                    if (!testFloor.currentRoom.RoomClear())
                        testFloor.currentRoom.SetDoorSprite(sealedVDoor, sealedHDoor);
                    else
                        testFloor.currentRoom.SetDoorSprite(openVDoor, openHDoor);
                    testFloor.currentRoom.DrawAllDoors(spriteBatch);

                    //Drawing collectibles
                    foreach(Collectible drop in testFloor.currentRoom.drops)
                    {
                        drop.Draw(spriteBatch);
                    }

                    // Informs player of levelup

                    if (frameCountDraw < 60)
                    {
                        spriteBatch.DrawString(font, "Level up!", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), Color.Red);
                        frameCountDraw++;
                    }





                    break;
                #endregion

                #region Pausemenu
                case GameState.PauseMenu:


                    health = (mainChar.healthPoints).ToString();
                    GraphicsDevice.Clear(Color.CornflowerBlue);

                    spriteBatch.DrawString(font, health, new Vector2(50, 40), Color.White);



                    //Drawing Game Objects
                    spriteBatch.Draw(mainChar.getSprite(), mainChar.loc.Center, null, Color.White, rotate, mainChar.origin, 1.0f, SpriteEffects.None, 0f);

                    //Drawing enemies
                    for (int i = 0; i < testFloor.currentRoom.enemies.Count; i++)
                    {
                        Enemy enemyTemp = testFloor.currentRoom.enemies[i];


                        if (enemyTemp.checkAlive())
                            spriteBatch.Draw(testFloor.currentRoom.enemies[i].getSprite(), testFloor.currentRoom.enemies[i].loc.Center, null, Color.White, rotate2, testFloor.currentRoom.enemies[i].origin, 1.0f, SpriteEffects.None, 0f);
                    }


                    if (leftMousePress)
                    {

                        spriteBatch.Draw(blade.getSprite(), blade.loc.Center, null, Color.White, rotate + 3.926f - 0.1047f * blade.swingtime, blade.origin, 0.65f, SpriteEffects.None, 0f);


                    }

                    spriteBatch.Draw(fullHealthBar, new Rectangle(150, 50, (50 * PlayerStats.constitution), 40), Color.Black);
                    spriteBatch.Draw(healthBar, new Rectangle(150, 50, (int)mainChar.healthPoints * 2, 40), Color.White);

                    //Drawing walls
                    testFloor.currentRoom.DrawWalls(spriteBatch);
                    testFloor.currentRoom.DrawAllDoors(spriteBatch);

                    // Has button location
                    
                    spriteBatch.Draw(ButtonBack, buttonPosResume, Color.White);

                    if (Resume.enterButton() == true)
                    { spriteBatch.Draw(ButtonBack, buttonPosResume, Color.SandyBrown); }

                    if (Resume.enterButton() == true && ms.LeftButton == ButtonState.Pressed)
                    { spriteBatch.Draw(ButtonPressed, buttonPosResume, Color.White); }

                    spriteBatch.DrawString(font, "Resume", new Vector2(buttonPosResume.X + 28, buttonPosResume.Y + 8), Color.Silver);
                    PauseMenuText = "         The Game is Paused \n Press 'p' or 'Resume' to Resume.";
                    spriteBatch.DrawString(font, PauseMenuText, CenterScreen, Color.SaddleBrown);

                    foreach (Collectible drop in testFloor.currentRoom.drops)
                    {
                        drop.Draw(spriteBatch);
                    }
                    break;
                #endregion

                #region Gameover
                case GameState.Gameover:
                    //game over background texture
                    //final stats
                    //buttons, back to main menu
                    spriteBatch.Draw(MenuBack, FullScreen, Color.White);
                    GameOverText = "  Ur ded Scrub";
                    //CenterScreen == new Vector2(280, 500)
                    //spriteBatch.DrawString(font, GameOverText, CenterScreen, Color.SaddleBrown);
                    spriteBatch.DrawString(font, GameOverText, new Vector2(280, 150), Color.SaddleBrown);


                    int finalScore = ((testFloor.floorNum - 1) * 100) + mainChar.enemiesKilled;

                    //spriteBatch.Draw(RIP, RIPloc, Color.White);

                    //Reward Medals
                    if(finalScore >= 750)
                        spriteBatch.Draw(GoldMedal, MedalLoc, Color.White);
                    else if(finalScore >= 350)
                        spriteBatch.Draw(SilverMedal, MedalLoc, Color.White);
                    else if (finalScore >= 1)
                        spriteBatch.Draw(BronzeMedal, MedalLoc, Color.White);
                    else
                        spriteBatch.Draw(TinMedal, MedalLoc, Color.White);

                    testFloor.currentRoom = testFloor.floorLayout[1, 1];
                    testFloor.currentRoom.SetEnemies(EnemySprite, 3);
                    testFloor.currentRoom.SpawnEnemies();
					// Has button location
					
                    spriteBatch.Draw(ButtonBack, buttonPosRestart, Color.White);
                    if (Restart.enterButton() == true)
                    { spriteBatch.Draw(ButtonBack, buttonPosRestart, Color.SandyBrown); }
                    if (Restart.enterButton() == true && ms.LeftButton == ButtonState.Pressed)
                    { spriteBatch.Draw(ButtonPressed, buttonPosRestart, Color.White); }
                    spriteBatch.DrawString(font, "Restart", new Vector2(buttonPosRestart.X + 28, buttonPosRestart.Y + 8), Color.Silver);

                    spriteBatch.Draw(ButtonBack, buttonPosQuit, Color.White);
                    if (Quit.enterButton() == true)
                    { spriteBatch.Draw(ButtonBack, buttonPosQuit, Color.SandyBrown); }
                    if (Quit.enterButton() == true && ms.LeftButton == ButtonState.Pressed)
                    { spriteBatch.Draw(ButtonPressed, buttonPosQuit, Color.White); }
                    spriteBatch.DrawString(font, "Quit", new Vector2(buttonPosQuit.X + 20, buttonPosQuit.Y + 8), Color.Silver);



                    // 750 pts is gold, 350 is silver, 1 is bronze, 0 is tin.
                    spriteBatch.DrawString(font, "Final Score = " + finalScore, new Vector2(280, 350), Color.ForestGreen);
                    break;
                    #endregion
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
		/// Updates character's animation as necessary
		/// </summary>
		/// <param name="gameTime">Time information</param>
		private void UpdateAnimation(GameTime gameTime)
        {
            // Handle animation timing
            // - Add to the time counter
            // - Check if we have enough "time" to advance the frame
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= timePerFrame)
            {
                frame += 1;                     // Adjust the frame

                if (frame > WalkFrameCount)     // Check the bounds
                    frame = 1;                  // Back to 1 (since 0 is the "standing" frame)

                timeCounter -= timePerFrame;    // Remove the time we "used"
            }
        }

        private void DrawCharacterWalking(float rotation, Vector2 origin)
        {
            spriteBatch.Draw(
                characterAnimated,               // - The texture to draw (spritesheet)
                mainChar.loc.Center,             // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    frame * vikingRectWidth,   //   - This rectangle specifies
                    vikingRectOffsetY,        //	   where "inside" the spritesheet
                    vikingRectWidth,           //     to get pixels (We don't want to
                    vikingRectHeight),         //     draw the whole thing)
                Color.White,                    // - The color
                rotation,                       // - Rotation (none currently)
                origin,                   // - Origin inside the image (top left)
                1.0f,                           // - Scale (100% - no change)  
                SpriteEffects.None,             // - no effect
                0);                             // - Layer depth (unused)
        }


        #region game functionality methods
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

            //Basic movement code
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
                    movement = new Vector2(0, -movespeed);
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
                    movement = new Vector2(0, movespeed);

            }

            //move west
            else if (kbState.IsKeyDown(Keys.A))
            {
                movement = new Vector2(-movespeed, 0);
            }

            //move east
            else if (kbState.IsKeyDown(Keys.D))
            {
                movement = new Vector2(movespeed, 0);
            }

            //when player is static    
            else
            {
                movement = new Vector2(0, 0);
            }

            mc.loc.Center += movement;
        }

        //Resets values that change during gameplay
        public void ResetGame()
        {

            mainChar.loc = new Circle(new Vector2(500, 500), mainChar.loc.Radius);
            mainChar.attackDamage = 10;
            mainChar.healthPoints = 50 * PlayerStats.constitution;
            mainChar.maxHP = mainChar.healthPoints;
            movespeed = 10 + (2*PlayerStats.dexterity);
            enemyNo = 3;
            mainChar.enemiesKilled = 0;
            testFloor.floorNum = 0;
            Initialize();
            

        }

        /// <summary>
        /// Creates a button to advacne to the next screen.
        /// </summary>
        /// <param name="The rectangle to be used"></param>
        /// <param name="The Button object you want passed in"></param>
        /// <returns name="returns true if the button is clicked on"></returns>
        /// 
        public bool ButtonPress(Button SpecificButton)
        {
            previousms = ms;
            ms = Mouse.GetState();
            if (SpecificButton.enterButton() == true && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
            { return true; }
            return false;
        }

        /*
		SetStats = new Button(buttonPosSetStats, 650, 720);
		// Has button size
		buttonPosSetStats = new Rectangle(SetStats.buttonX, SetStats.buttonY, 280, 80);
		previousms = ms;
			ms = Mouse.GetState();
			if (SetStats.enterButton() == true && previousms.LeftButton == ButtonState.Pressed && ms.LeftButton == ButtonState.Released)
			{ state = GameState.ItemMenu; }
			*/

        public void ReCheckStats()
        {
            mainChar.attackDamage = 5 * PlayerStats.strength;
            mainChar.healthPoints = 50 * PlayerStats.constitution;
            mainChar.maxHP = mainChar.healthPoints;
            movespeed =(float)(10 + (PlayerStats.dexterity*1.5));
			
		}

        #endregion
    }

}
