using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Room
    {
        
        public Wall topWall=new Wall();
        public Wall bottomWall=new Wall();
        public Wall leftWall=new Wall();
        public Wall rightWall=new Wall();

        public Door topDoor;
        public Door rightDoor;
        public Door leftDoor;
        public Door bottomDoor;

        //Texture2D EnemySprite; //The enemy sprite
        public int xPos;
        public int yPos;

        public bool isCleared; //bool to test if all enemys have been cleared from the room
        public List<Enemy> enemies; //the list of all the enemies in the room
        public List<Collectible> drops;
        //Constructor
        public Room(int x, int y)
        {
            xPos = x;
            yPos = y;
            enemies = new List<Enemy>();
            drops = new List<Collectible>();
            isCleared = false;

            topDoor=null;
            rightDoor=null;
            leftDoor=null;
            bottomDoor=null;
    }

        //Sets number of enemies with their properties for a room
        public void SetEnemies(Texture2D texture,int j)
        {
            enemies.Clear();
            for(int i=0; i < j; i ++)
            {
                Enemy roomEnemy =new Enemy(0,0,0);
                roomEnemy.SetSprite(texture);
                roomEnemy.healthPoints = 30;
                roomEnemy.attackDamage = 5;
                enemies.Add(roomEnemy);
            }
        }

        //Checks if the enemies are dead
        public Boolean RoomClear()
        {
            foreach(Enemy roomEnemy in enemies)
            {
                if (roomEnemy.checkAlive())
                    return false;

            }
            isCleared = true;
            return true;
        }

        //Sets the position of the enemies
        public void SpawnEnemies()
        {
            int x = 550;
            foreach(Enemy roomEnemy in enemies)
            {
                roomEnemy.loc.Center.Y = 450;
                roomEnemy.loc.Center.X = x;
                x += 200;
            }
            

        }



        //Setting wall values
        public void SetWalls()
        {
            topWall.SetTopWall();
            bottomWall.SetBottomWall();
            leftWall.SetLeftWall();
            rightWall.SetRightWall();
        }

        //Draw all walls
        public void DrawWalls(SpriteBatch spriteBatch)
        {

            DrawNWWall(topWall,spriteBatch);
            DrawSEWall(bottomWall,spriteBatch,SpriteEffects.FlipVertically);
            DrawSEWall(rightWall,spriteBatch,SpriteEffects.FlipHorizontally);
            DrawNWWall(leftWall,spriteBatch);

      }
       
        //Draw all 4 doors if possible
       public void DrawAllDoors(SpriteBatch spriteBatch)
        {
            if (topDoor != null)
                DrawDoor(topDoor, spriteBatch);
            if (leftDoor != null)
                DrawDoor(leftDoor, spriteBatch);
            if (rightDoor != null)
                DrawDoor(rightDoor, spriteBatch, SpriteEffects.FlipHorizontally);
            if (bottomDoor != null)
                DrawDoor(bottomDoor, spriteBatch, SpriteEffects.FlipVertically);

        }

        //Setting door sprites
        public void SetDoorSprite(Texture2D vdoor, Texture2D hdoor)
        {
            if (topDoor != null)
                topDoor.SetSprite(hdoor);
            if (leftDoor != null)
                leftDoor.SetSprite(vdoor);
            if (rightDoor != null)
                rightDoor.SetSprite(vdoor);
            if (bottomDoor != null)
                bottomDoor.SetSprite(hdoor);
        }
        
       //Draw a door 
       public void DrawDoor(Door door,SpriteBatch spriteBatch)
       {
           
                spriteBatch.Draw(door.sprite, door.position, Color.White);

        }

        //Draw a door-overloaded
        public void DrawDoor(Door door, SpriteBatch spriteBatch, SpriteEffects spriteEffect)
        {
            
                spriteBatch.Draw(door.sprite,door.position, null, Color.White, 0.0f, new Vector2(0, 0), spriteEffect, 0.0f);
        }

        public void SetDoor(string door)
        {
            switch(door)
            {
                case "top": topDoor = new Door(150, 50, 750, 0);
                    break;
                case "left":
                    leftDoor = new Door(50, 150, 0, 400);
                    break;
                case "right":
                    rightDoor = new Door(50, 150, 1550, 400);
                    break;
                case "bottom": bottomDoor = new Door(150, 50, 750, 850);
                    break;
            }                                                   
                    
        }

        public void SetEB()
        {
            if (topDoor != null)
                topDoor.TopEB();
            if (leftDoor != null)
                leftDoor.LeftEB();
            if (rightDoor != null)
                rightDoor.RightEB();
            if (bottomDoor != null)
                bottomDoor.BottomEB();
        }
        //Draw top-left walls
        public void DrawNWWall(Wall wall, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wall.texture, wall.roomWall, Color.White);
           
            
            
        }

        //Draw bottom-right walls
        public void DrawSEWall(Wall wall, SpriteBatch spriteBatch, SpriteEffects myEffect)
        {
            spriteBatch.Draw(wall.texture, wall.roomWall, null, Color.White, 0.0f, new Vector2(0, 0), myEffect, 0.0f);
            
        }
        
        //Setting Wall textures
        public void SetWallTexture(Texture2D hTexture, Texture2D vTexture)
        {
            topWall.texture = hTexture;
            bottomWall.texture = hTexture;
            rightWall.texture = vTexture;
            leftWall.texture = vTexture;
        }
        
        //Function for leaving a room
        public bool RoomExit(Character mainChar)
        {

            if (topDoor != null)
            {
                if (CRIntersect(mainChar.loc, topDoor.exitBox))
                {

                    mainChar.loc.Center.X = MathHelper.Clamp(mainChar.loc.Center.X, 750 + mainChar.loc.Radius, 900 - mainChar.loc.Radius);
                    return true;

                }
            }
            if (bottomDoor != null)
            { 
              if (CRIntersect(mainChar.loc, bottomDoor.exitBox))
                {
                    mainChar.loc.Center.X = MathHelper.Clamp(mainChar.loc.Center.X, 750 + mainChar.loc.Radius, 900 - mainChar.loc.Radius);
                    return true;
                }
            }
            if (rightDoor != null)
            { 
              if (CRIntersect(mainChar.loc, rightDoor.exitBox))
                {
                    mainChar.loc.Center.Y = MathHelper.Clamp(mainChar.loc.Center.Y, mainChar.loc.Radius + 400, 550 - mainChar.loc.Radius);
                    return true;

                }
            }
            if (leftDoor != null)
            { 
              if (CRIntersect(mainChar.loc, leftDoor.exitBox))
                {

                    mainChar.loc.Center.Y = MathHelper.Clamp(mainChar.loc.Center.Y, mainChar.loc.Radius + 400, 550 - mainChar.loc.Radius);
                    return true;
                }
            }

            mainChar.loc.Center.X = MathHelper.Clamp(mainChar.loc.Center.X, mainChar.loc.Radius + 50, 1550 - mainChar.loc.Radius);
            mainChar.loc.Center.Y = MathHelper.Clamp(mainChar.loc.Center.Y, mainChar.loc.Radius + 50, 850 - mainChar.loc.Radius);
            return false;

           
        }

        //Circle rectangle intersection
        //http://stackoverflow.com/questions/401847/circle-rectangle-collision-detection-intersection/402010#402010
        public bool CRIntersect(Circle circle, Rectangle rect)
        {
            if (rect == null)
                return false;
            double circleDistancex = Math.Abs(circle.Center.X - rect.X);
            double circleDistancey = Math.Abs(circle.Center.Y - rect.Y);

            if (circleDistancex > (rect.Width / 2.0 + circle.Radius))
                return false;
            if (circleDistancey > (rect.Height / 2.0 + circle.Radius))
                return false;

            if (circleDistancex <= (rect.Width / 2.0))
                return true;
            if (circleDistancey <= (rect.Height / 2.0))
                return true;

            double cornerDistance_sq = Math.Pow((circleDistancex - rect.Width / 2.0), 2) + Math.Pow((circleDistancey - rect.Height / 2.0), 2);
            return (cornerDistance_sq <= Math.Pow(circle.Radius, 2));
        }

        public void SpawnCollectible(Texture2D colltect,float x, float y)
        {
            Random rng = new Random();

            if(rng.Next(4)==3)
            drops.Add(new Collectible(colltect, x, y));
        }
    }
}
