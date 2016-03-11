using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Character 
    {
        double healthPoints;
        double moveSpeed;
        Texture2D sprite;
        public Circle loc;
        
        
        public Character()
        {

        }
        public Character(int x, int y, float radius) 
        {
            loc = new Circle(new Vector2(x, y), radius);
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

