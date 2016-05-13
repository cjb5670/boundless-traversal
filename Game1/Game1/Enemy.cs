using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Game1
{
    public class Enemy : Character
    {
        int pauseMove = 31;
        float movespeed;
        static Random msmod = new Random();

        // fields for reading data
        int count = 0;
        string h;
        string d;
        double enemyHealth;
        double enemyDexterity;
        static int i = 0;

        public Enemy()
        {
            
        }

        //main constructor
        public Enemy(int x, int y, float radius)
            : base(x, y, radius)
        {
            ReadData();
            enemyHealth = Convert.ToDouble(h);
            enemyDexterity = Convert.ToDouble(d);
            i++;
            movespeed =msmod.Next(0, 5)*.5f + 5.5f+ i/10;
            movespeed += (float)enemyDexterity - 1;

            healthPoints += enemyHealth;

        }

        //Checks if the current Enemy is alive or not
        public bool checkAlive()
        {
            if (this.healthPoints > 0)
            {

                return true;
            }

            else
            {
                
                return false;
            }
        }

        //Checks for enemy-player intersection
        public bool playerIntersect(Character player)
        {
            Vector2 relativePosition = player.loc.Center - loc.Center;
            float distanceBetweenCenters = relativePosition.Length();
            if (distanceBetweenCenters <= loc.Radius + player.loc.Radius) { return true; }
            else { return false; }
        }

        public bool playerIntersect(Weapon player)
        {
            Vector2 relativePosition = player.hitBox.Center - loc.Center;
            float distanceBetweenCenters = relativePosition.Length();
            if (distanceBetweenCenters <= loc.Radius + player.hitBox.Radius) { return true; }
            else { return false; }
        }



        //Rudimentary enemy AI
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
                    loc.Center.X -= movespeed * (float)Math.Pow(Math.Sin(rotate), 2);
                else if (loc.Center.X < player.loc.Center.X)
                    loc.Center.X += movespeed * (float)Math.Pow(Math.Sin(rotate), 2);

                if (loc.Center.Y > player.loc.Center.Y)
                    loc.Center.Y -= movespeed * (float)Math.Pow(Math.Cos(rotate), 2);
                else if (loc.Center.Y < player.loc.Center.Y)
                    loc.Center.Y += movespeed * (float)Math.Pow(Math.Cos(rotate), 2);
                if (playerIntersect(player))
                {
                    charHit(this, player);
                    pauseMove = 0;
                }
            }          
        }

        // read data from file
        public void ReadData()
        {

            StreamReader input = null;

            try
            {
                input = new StreamReader("../../../../attributes.txt");

                String line = null;
                while ((line = input.ReadLine()) != null)
                {
                    // count determines where the current line is stored
                    if (count == 0)
                    {
                        d = line;
                    }
                    if (count == 1)
                    {
                        h = line;
                    }
                    count++;
                }
                // reset count for next use
                count = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }
            finally
            {
                if (input != null)
                    input.Close();
            }
        }
    
    }
}
