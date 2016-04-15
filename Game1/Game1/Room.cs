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

        public Wall topWall = new Wall();
        public Wall bottomWall = new Wall();
        public Wall leftWall = new Wall();
        public Wall rightWall = new Wall();


        bool isCleared; //bool to test if all enemys have been cleared from the room
        public List<Enemy> enemies; //the list of all the enemies in the room

        Texture2D texture;
        Rectangle rect;
        public Room()
        {
            rect.Height = 900;
            rect.Width = 1600;
            enemies = new List<Enemy>();
        }

        //Sets number of enemies with their properties for a room
        public void SetEnemies(Texture2D texture, int j)
        {
            enemies.Clear();
            for (int i = 0; i < j; i++)
            {
                Enemy roomEnemy = new Enemy(0, 0, 0);
                roomEnemy.SetSprite(texture);
                roomEnemy.healthPoints = 30;
                roomEnemy.attackDamage = 5;
                enemies.Add(roomEnemy);
            }
        }

        public Boolean RoomClear()
        {
            foreach (Enemy roomEnemy in enemies)
            {
                if (roomEnemy.checkAlive())
                    return true;

            }
            return false;
        }

        //Sets the position of the enemies
        public void SpawnEnemies()
        {

            enemies[0].loc.Center.X = 800;
            enemies[0].loc.Center.Y = 200;
            enemies[1].loc.Center.X = 1000;
            enemies[1].loc.Center.Y = 200;
            enemies[2].loc.Center.X = 1200;
            enemies[2].loc.Center.Y = 200;

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

            DrawSingleWall(topWall, spriteBatch);
            DrawSingleWall(bottomWall, spriteBatch);
            DrawSingleWall(rightWall, spriteBatch);
            DrawSingleWall(leftWall, spriteBatch);



        }

        public void DrawSingleWall(Wall wall, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(wall.texture, wall.roomWall, Color.White);
            if (RoomClear() == true)
                spriteBatch.Draw(wall.wallDoor.sprite, wall.wallDoor.position, wall.wallDoor.color);
        }

        public void SetWallTexure(Texture2D hTexture, Texture2D vTexture)
        {
            topWall.texture = hTexture;
            bottomWall.texture = hTexture;
            rightWall.texture = vTexture;
            leftWall.texture = vTexture;
        }

        public void Exit(Circle loc)
        {
           
        }
            
         
        
    }
}
