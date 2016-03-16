using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{

     public class Character
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

        public static void charHit(Character attacker, Character defender)
        {
            float rotate = getAngleBetween(defender, attacker);
            if (attacker.loc.Center.X > defender.loc.Center.X)
                defender.loc.Center.X -= 100 * (float)Math.Pow(Math.Sin(rotate), 2);
            else if (attacker.loc.Center.X < defender.loc.Center.X)
                defender.loc.Center.X += 100 * (float)Math.Pow(Math.Sin(rotate), 2);
            if (attacker.loc.Center.Y > defender.loc.Center.Y)
                defender.loc.Center.Y -= 100 * (float)Math.Pow(Math.Cos(rotate), 2);
            else if (attacker.loc.Center.Y < defender.loc.Center.Y)
                defender.loc.Center.Y += 100 * (float)Math.Pow(Math.Cos(rotate), 2);
        }

        public static float getAngleBetween(Character c1, Character c2)
        {
            float xdist = c1.loc.Center.X - c2.loc.Center.X;
            float ydist = c1.loc.Center.Y - c2.loc.Center.Y;
            float rotate = (float)(System.Math.Atan2(ydist, xdist) + 1.570);
            return rotate;
        }
    }

}

