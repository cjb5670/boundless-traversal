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
        public bool active = true;
        //walls
        public Wall()
        {
            wallDoor = new Door();
        }
        
        enum wallType { Full, Door, Open};


        public void SetTopWall()
        {
            roomWall = new Rectangle(0, 0, 1600, 50);
            if (active)
            {
                wallDoor = new Door(150, 50, 750, 0);
                exitBox = new Rectangle(750,0,150,80);
                
            }

        }

        public void SetBottomWall()
        {
            roomWall = new Rectangle(0, 850, 1600, 50);
            if (active)
            {
                wallDoor = new Door(150, 50, 750, 850);
                exitBox = new Rectangle(750, 900, 150, 80);
                
            }
            

        }

        public void SetLeftWall()
        {
            roomWall = new Rectangle(0, 0, 50, 900);
            if (active)
            {
                wallDoor = new Door(50, 150, 0, 400);
                exitBox = new Rectangle(0, 400, 80, 150);
                
            }
        }

        public void SetRightWall()
        {
            roomWall = new Rectangle(1550, 0, 50, 900);
            if (active)
            {
                wallDoor = new Door(50, 150, 1550, 400);
                exitBox = new Rectangle(1600, 400, 80, 150);
                
            }

        }

        


    }
}
