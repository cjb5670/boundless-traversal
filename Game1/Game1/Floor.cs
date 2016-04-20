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
        int x = 1;
        int y = 1;
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
            floorLayout[i, j].isCleared = false;

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

        public void drawFloor(Texture2D hWall, Texture2D vWall, Texture2D hDoor, Texture2D vDoor)
        {
            for (int i = 1; i < floorLayout.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < floorLayout.GetLength(1) - 1; j++)
                {
                    floorLayout[i, j].SetWallTexture(hWall, vWall);
                    floorLayout[i, j].SetWalls();
                    if(floorLayout[i, j].leftWall.wallDoor != null)
                        floorLayout[i, j].leftWall.wallDoor.SetSprite(vDoor);

                    if (floorLayout[i, j].topWall.wallDoor != null)
                    floorLayout[i, j].topWall.wallDoor.SetSprite(hDoor);

                    if (floorLayout[i, j].rightWall.wallDoor != null)
                        floorLayout[i, j].rightWall.wallDoor.SetSprite(vDoor);

                    if (floorLayout[i, j].bottomWall.wallDoor != null)
                        floorLayout[i, j].bottomWall.wallDoor.SetSprite(hDoor);
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

        public Room enterRoom()
        {
            Room currentRoom = floorLayout[x, y];
            return currentRoom;
            
        }
        public Room enterDoor()
        {
            if (currentRoom.RoomClear())
            {
               
                return enterRoom();
            }
            return currentRoom;
        }
    }
}


