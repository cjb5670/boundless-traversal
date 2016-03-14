using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Wall:GameObject
    {
        Door wallDoor; //I really dont know what to name this

        //walls
        public Rectangle leftWall;
        public Rectangle rightWall;
        public Rectangle bottomWall;
        public Rectangle topWall;

        enum wallType { Full, Door, Open};


        public Rectangle SetTopWall()
        {
            topWall = new Rectangle(0, 0, 1600, 50);
            return topWall;
        }

        public Rectangle SetBottomWall()
        {
            bottomWall = new Rectangle(0, 850, 1600, 50);
            return bottomWall;
        }

        public Rectangle SetLeftWall()
        {
            leftWall = new Rectangle(0, 0, 50, 900);
            return leftWall;
        }

        public Rectangle SetRightWall()
        {
            rightWall = new Rectangle(1550, 0, 50, 900);
            return rightWall;
        }

    }
}
