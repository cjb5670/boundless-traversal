using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    class Floor
    {
        public Room[,] floorLayout;
        public Room currentRoom; //the room the player is in
        public Room defaultRoom; //a default room that loads the textures from
        int depth;
        public Floor(int width, int height, int level)
        {
            floorLayout = new Room[height + 2, width + 2];
            currentRoom = new Room();
            defaultRoom = new Room();
            createFloor();
        }

        void createRoom(int i, int j)
        {
            floorLayout[i, j] = new Room();
            if (!checkLeftDoor(i, j)) { floorLayout[i, j].leftWall.wallDoor = null; }
           
            if(!checkUpperDoor(i, j)) { floorLayout[i, j].leftWall.wallDoor = null; }
            floorLayout[i, j].SetWalls();

        }

        void createFloor()
        {
            for (int i = 1; i < floorLayout.GetLength(0)-1; i++)
            {
                for (int j = 1; j < floorLayout.GetLength(1)-1; j++)
                {
                    createRoom(i, j);
                }
            }
        }

        bool checkLeftDoor(int i, int j)
        {
            if (floorLayout[i, j - 1] != null)
            {
                if (floorLayout[i, j - 1].rightWall.wallDoor != null)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        bool checkUpperDoor(int i, int j)
        {

            if (floorLayout[i - 1, j] != null)
            {
                if (floorLayout[i - 1, j].rightWall.wallDoor != null)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        public void enterRoom(int x, int y)
        {
            Room currentRoom = floorLayout[x, y];

            
            
            
            
        }
    }
}


