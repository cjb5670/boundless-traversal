using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Character : GameObject
    {
        //Character variables
        private double maxHP;//Max character hp
        private double moveSpeed;//Charcter movement speed modifier

        //Default Constructor
        public Character()
        {
        }

        //Main Constructor
        public Character(int hp, int ms)
        {
            maxHP = hp;
            moveSpeed = ms;
        }

        //Properties
        public double MaxHP
        {
            get
            {
                return maxHP;
            }
        }

        public double MoveSpeed
        {
            get
            {
                return moveSpeed;
            }

            set
            {
                moveSpeed = value;
            }
        }
    }
}
