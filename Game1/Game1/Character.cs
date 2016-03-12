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
        public Vector2 origin;
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
            loc.Radius = sprite.Width / 2;
            origin.X = sprite.Width / 2;
            origin.Y = sprite.Height / 2;
        }

        public Texture2D getSprite()
        {
            return sprite;

        }

    }

}

