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

        public Rectangle roomWall;
   
        public Texture2D texture;
        public bool active = true;
        //walls
        public Wall()
        {

        }
        
        enum wallType { Full, Door, Open};


        public void SetTopWall()
        {
            roomWall = new Rectangle(0, 0, 1600, 50);


        }

        public void SetBottomWall()
        {
            roomWall = new Rectangle(0, 850, 1600, 50);         

        }

        public void SetLeftWall()
        {
            roomWall = new Rectangle(0, 0, 50, 900);

        }

        public void SetRightWall()
        {
            roomWall = new Rectangle(1550, 0, 50, 900);

        }





    }
}
