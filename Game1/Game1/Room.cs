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
            for(int i=0; i < j; i ++)
            {
                Enemy roomEnemy =new Enemy(0,0,0);
                roomEnemy.SetSprite(texture);
                roomEnemy.healthPoints = 10;
                roomEnemy.attackDamage = 5;
                enemies.Add(roomEnemy);
            }
        }

        public bool RoomClear()
        {
            foreach(Enemy roomEnemy in enemies)
            {
                if (roomEnemy.checkAlive())
                    return false;

            }
            return true;
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

            topWall.DrawWall(spriteBatch);
            bottomWall.DrawWall(spriteBatch);
            rightWall.DrawWall(spriteBatch);
            leftWall.DrawWall(spriteBatch);
        }

        public void SetWallTexure(Texture2D texture)
        {
            topWall.texture = texture;
            bottomWall.texture = texture;
            rightWall.texture = texture;
            leftWall.texture = texture;
        }
    }
}
