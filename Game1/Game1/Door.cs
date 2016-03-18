using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Door 
    {
        Texture2D sprite;
        Boolean open = false;
        Rectangle position;

        public Door()
        {
            position.Width = 50;
            position.Height = 150;
            
        }
        public void SetSprite()
        {

        }
    }
}
