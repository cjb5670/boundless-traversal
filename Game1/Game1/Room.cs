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

        public Wall roomWall = new Wall();
        
        Rectangle topWall;
        Rectangle bottomWall;
        Rectangle leftWall;
        Rectangle rightWall; 

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
            topWall=roomWall.SetTopWall();
            bottomWall=roomWall.SetBottomWall();
            leftWall=roomWall.SetLeftWall();
            rightWall=roomWall.SetRightWall();
        }
        public void DrawWalls(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(roomWall.texture, topWall, Color.White);
            spriteBatch.Draw(roomWall.texture, bottomWall, Color.White);
            spriteBatch.Draw(roomWall.texture, leftWall, Color.White);
            spriteBatch.Draw(roomWall.texture, rightWall, Color.White);
        }
    }
}
