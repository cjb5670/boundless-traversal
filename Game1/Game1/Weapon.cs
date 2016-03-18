using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Weapon
    {
        public Vector2 origin;
        Texture2D sprite;
        Vector2 corner1;
        Vector2 corner2;
        Vector2 corner3;
        Vector2 corner4;
        public Vector2 position;
        public Weapon(Character user)
        {
            origin.Y = -user.loc.Radius;

        }
        
        public void setSprite(Texture2D text)
        {
            sprite = text;
            origin.X = sprite.Width / 2;
           

        }
        public Texture2D getSprite()
        {
            return sprite;
        }
        public void moveWeapon(Character user, float angle)
        {
            position = user.loc.Center;
            corner1.X = position.X - (float)(sprite.Width / 2 * Math.Cos(angle)) + (float)(user.loc.Radius * Math.Sin(angle));
            corner1.Y = position.Y + (float)(Math.Sin(angle)) + (float)(user.loc.Radius * Math.Cos(angle));

        }

       /* public bool intersectsEnemy(Enemy e, float rotation)
        {
            corner1 = 
        }*/
    }
}
