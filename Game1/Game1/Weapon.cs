using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Weapon: Character
    {

        public string debugline;
        public int swingtime;
        public Circle hitBox;
        
        public Weapon(Character user)
        {
            origin.Y = -user.loc.Radius;
            loc.Radius = user.loc.Radius;
            debugline = "";
        }
        
        
        public void setWeaponSprite(Texture2D text)
        {
            sprite = text;
            origin.X = sprite.Width / 2;
            swingtime = 0;

        }
        
        public void moveWeapon(Character user, float angle)
        {
            loc.Center = user.loc.Center;
            debugline = "" + angle;
           
            hitBox.Center.X = user.loc.Center.X + user.loc.Radius * (float)Math.Cos(angle- 1.570);
            hitBox.Center.Y = user.loc.Center.Y + user.loc.Radius * (float)Math.Sin(angle-1.570);
            
            hitBox.Radius = user.loc.Radius;
        }

        
    }
}
