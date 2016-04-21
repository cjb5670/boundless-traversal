using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Door 
    {
        public Texture2D sprite;
        public Rectangle position;
        public Rectangle exitBox;
        public bool active=true;
        public Door()
        {

        }
        public Door(int w, int h,int x, int y)
        {
            position = new Rectangle(x, y, w, h);
            exitBox = new Rectangle(0, 0, 0, 0);
                        
        }
        public void SetSprite(Texture2D texture)
        {
            sprite = texture;
        }

        public void LeftEB()
        {
            exitBox = new Rectangle(0, 400, 80, 150);
        }

        public void RightEB()
        {
            exitBox = new Rectangle(1600, 400, 80, 150);
        }
        public void TopEB()
        {
            exitBox = new Rectangle(750, 0, 150, 80);
        }
        public void BottomEB()
        {
            exitBox = new Rectangle(750, 900, 150, 80);
        }

    }
}
