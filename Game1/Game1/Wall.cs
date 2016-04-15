using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Wall
    {
        public Door wallDoor; 
        public Rectangle roomWall;
        public Texture2D texture;
        //walls
        public Wall()
        {
            wallDoor = new Door();
        }
        
        enum wallType { Full, Door, Open};


        public void SetTopWall()
        {
            roomWall = new Rectangle(0, 0, 1600, 50);
            if (wallDoor != null)
                wallDoor = new Door(150, 51, 750, 0);


        }

        public void SetBottomWall()
        {
            roomWall = new Rectangle(0, 850, 1600, 50);
            if(wallDoor != null)
                wallDoor = new Door(150, 51, 750, 850); 
            

        }

        public void SetLeftWall()
        {
            roomWall = new Rectangle(0, 0, 50, 900);
            if (wallDoor != null)
                wallDoor = new Door(51, 150, 0, 400);
        }

        public void SetRightWall()
        {
            roomWall = new Rectangle(1550, 0, 50, 900);
            if (wallDoor != null)
                wallDoor = new Door(51, 150, 1550, 400);

        }
        
        public void DrawWall(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, roomWall, Color.White);
            spriteBatch.Draw(wallDoor.sprite, wallDoor.position, Color.White);
        }
    }
}
