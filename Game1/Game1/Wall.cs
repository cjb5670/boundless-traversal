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
        public Rectangle exitBox;
        public Texture2D texture;
        //walls
        public Wall()
        {
            
        }
        
        enum wallType { Full, Door, Open};


        public void SetTopWall()
        {
            roomWall = new Rectangle(0, 0, 1600, 50);
            wallDoor = new Door(150, 100, 750, 0);


        }

        public void SetBottomWall()
        {
            roomWall = new Rectangle(0, 850, 1600, 50);
            wallDoor = new Door(150, 50, 750,850);
            exitBox = new Rectangle(150, 100, 900, 850);

        }

        public void SetLeftWall()
        {
            roomWall = new Rectangle(0, 0, 50, 900);
            wallDoor = new Door(50, 150, 0, 400);
        }

        public void SetRightWall()
        {
            roomWall = new Rectangle(1550, 0, 50, 900);
            wallDoor = new Door(50, 150, 1550, 400);

        }

       
    }
}
