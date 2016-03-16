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
        int pauseMove = 31;

        public Enemy(int x, int y, float radius)
            : base(x, y, radius)
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

            
            //stops the character from moving for half a second
            if (pauseMove <= 30)
            {
                pauseMove++;
            }

            else
            {
                float rotate = getAngleBetween(player, this);
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
                    charHit(this, player);
                    pauseMove = 0;
                }
            }
            


        }





    }
}
