using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Game1
{
    class GameObject
    {
        Texture2D sprite;
        public Rectangle hitBox;  
        public GameObject()
        {

        }
        public GameObject(int x, int y, int width, int height)
        {
            hitBox.X = x;
            hitBox.Y = y;
            hitBox.Width = width;
            hitBox.Height = height;
        }
        public void SetSprite(Texture2D text)
        {
            sprite = text;
        }

        public Texture2D getSprite()
        {
            return sprite;
        }
    }
}
