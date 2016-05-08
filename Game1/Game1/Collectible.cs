using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Collectible
    {
        Texture2D sprite;
        Circle hitbox;
        public bool picked = false;
        public Vector2 origin;
       

        public Collectible(Texture2D text,float x,float y)
        {
            sprite = text;
            hitbox = new Circle(new Vector2(x, y), sprite.Width / 2);
            origin.X = sprite.Width / 2;
            origin.Y = sprite.Height / 2;
        }

        public void playerIntersect(Character player)
        {
            Vector2 relativePosition = player.loc.Center - hitbox.Center;
            float distanceBetweenCenters = relativePosition.Length();

            if (distanceBetweenCenters <= hitbox.Radius + player.loc.Radius && player.healthPoints != player.maxHP)
            {
                picked = true;
                player.healthPoints += 10;
                if (player.healthPoints > player.maxHP)
                    player.healthPoints = player.maxHP;
            }
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, hitbox.Center, null, Color.White);
        }

    }
}
