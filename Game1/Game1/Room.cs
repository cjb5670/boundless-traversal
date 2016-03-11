using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Room
    {
        Wall northWall, eastWall, southWall, westWall; //rooms 4 wall objects
        bool isCleared; //bool to test if all enemys have been cleared from the room
        List<Enemy> enemies; //the list of all the enemies in the room
        Texture2D texture;
        Rectangle rect;
        public Room()
        {
            rect.Height = 900;
            rect.Width = 1600;

        }
    }
}
