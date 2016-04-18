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


        bool isCleared; //bool to test if all enemys have been cleared from the room
        public List<Enemy> enemies; //the list of all the enemies in the room
        int enemyNum;
        public Texture2D texture;
        Rectangle rect;
        public Room()
        {
            rect.Height = 900;
            rect.Width = 1600;
            enemies = new List<Enemy>();
            
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
            int x = 800;
            foreach(Enemy roomEnemy in enemies)
            {
                roomEnemy.loc.Center.Y = 200;
                roomEnemy.loc.Center.X = x;
                x += 200;
            }
            

        }
        public void SetWalls()
        {
            topWall.SetTopWall();
            bottomWall.SetBottomWall();
            leftWall.SetLeftWall();
            rightWall.SetRightWall();
        }

        public void DrawWalls(SpriteBatch spriteBatch)
        {

            DrawNWWall(topWall,spriteBatch);
            DrawSEWall(bottomWall,spriteBatch,SpriteEffects.FlipVertically);
            DrawSEWall(rightWall,spriteBatch,SpriteEffects.FlipHorizontally);
            DrawNWWall(leftWall,spriteBatch);

      }

        public void DrawNWWall(Wall wall, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wall.texture, wall.roomWall, Color.White);
            if (!RoomClear())
                spriteBatch.Draw(wall.wallDoor.sprite, wall.wallDoor.position, Color.White);
        }

        public void DrawSEWall(Wall wall, SpriteBatch spriteBatch, SpriteEffects myEffect)
        {
            spriteBatch.Draw(wall.texture, wall.roomWall, null, Color.White, 0.0f, new Vector2(0, 0), myEffect, 0.0f);
            if (!RoomClear())
                spriteBatch.Draw(wall.wallDoor.sprite, wall.wallDoor.position, null, Color.White, 0.0f, new Vector2(0,0), myEffect, 0.0f);
        }

        public void SetWallTexture(Texture2D hTexture, Texture2D vTexture)
        {
            topWall.texture = hTexture;
            bottomWall.texture = hTexture;
            rightWall.texture = vTexture;
            leftWall.texture = vTexture;
        }
    }
}
