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
        Boolean open = false;
        public Rectangle position;

        public Door(int w, int h,int x, int y)
        {
            position = new Rectangle(x, y, w, h);
            
        }
        public void SetSprite(Texture2D texture)
        {
            sprite = texture;
        }


    }
}
