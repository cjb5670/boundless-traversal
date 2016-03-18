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
        Door wallDoor; 
        Rectangle roomWall;
        public Texture2D texture;
        //walls
        public Wall()
        {

        }
        
        enum wallType { Full, Door, Open};


        public Rectangle SetTopWall()
        {
            roomWall = new Rectangle(0, 0, 1600, 50);
            return roomWall;
            
        }

        public Rectangle SetBottomWall()
        {
            roomWall = new Rectangle(0, 850, 1600, 50);
            return roomWall;
        }

        public Rectangle SetLeftWall()
        {
            roomWall = new Rectangle(0, 0, 50, 900);
            return roomWall;
        }

        public Rectangle SetRightWall()
        {
            roomWall = new Rectangle(1550, 0, 50, 900);
            return roomWall;
        }

    }
}
