using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Enemy : Character
    {
        public Enemy(int x, int y, float radius)
            :base (x, y, radius)
        {

        }
        public bool playerIntersect(Character player)
        {
            Vector2 relativePosition = player.loc.Center - loc.Center;
            float distanceBetweenCenters = relativePosition.Length();
            if (distanceBetweenCenters <= loc.Radius + player.loc.Radius) { return true; }
            else { return false; }
        }
        public void followChar(Character player)
        {

            
            float xdist = player.loc.Center.X - loc.Center.X;
            float ydist = player.loc.Center.Y - loc.Center.Y;
            float rotate = (float)(System.Math.Atan2(ydist, xdist) + 1.570);
            if (loc.Center.X > player.loc.Center.X)
                loc.Center.X -= 5 * (float)Math.Pow(Math.Sin(rotate), 2);
            else if (loc.Center.X < player.loc.Center.X)
                loc.Center.X += 5 * (float)Math.Pow(Math.Sin(rotate), 2);
            
            if (loc.Center.Y > player.loc.Center.Y)
                loc.Center.Y -= 5 * (float)Math.Pow(Math.Cos(rotate), 2);
            else if (loc.Center.Y < player.loc.Center.Y)
                loc.Center.Y += 5 * (float)Math.Pow(Math.Cos(rotate), 2);
            if (playerIntersect(player))
            {
                if (loc.Center.X > player.loc.Center.X)
                    player.loc.Center.X -= 100 *(float)Math.Pow(Math.Sin(rotate), 2);
                else if (loc.Center.X < player.loc.Center.X)
                    player.loc.Center.X += 100 * (float)Math.Pow(Math.Sin(rotate), 2);
                if (loc.Center.Y > player.loc.Center.Y)
                    player.loc.Center.Y -= 100 * (float)Math.Pow(Math.Cos(rotate), 2);
                else if (loc.Center.Y < player.loc.Center.Y)
                    player.loc.Center.Y += 100 * (float)Math.Pow(Math.Cos(rotate), 2);
            }
        }


        
    }
}
