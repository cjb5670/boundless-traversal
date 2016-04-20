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
       // public Room defaultRoom; //a default room that loads the textures from
        int depth;
        int x = 1;
        int y = 1;

        public Floor(int width, int height, int level)
        {
            floorLayout = new Room[height + 2, width + 2];
            createFloor();
            currentRoom = floorLayout[1, 1];
            //defaultRoom = new Room();
            
        }

        void createRoom(int i, int j)
        {          
            floorLayout[i, j] = new Room(i,j);                                   
            floorLayout[i, j].isCleared = false;            
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

        public void drawFloor(Texture2D hWall, Texture2D vWall, Texture2D hDoor, Texture2D vDoor)
        {
            for (int i = 1; i < floorLayout.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < floorLayout.GetLength(1) - 1; j++)
                {
                    floorLayout[i, j].SetWallTexture(hWall, vWall);                    
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


        public bool checkLeftDoor(int i, int j)
        {
            if (floorLayout[i, j - 1] != null)
            {
                if (floorLayout[i, j-1].rightWall.wallDoor!= null)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        public bool checkUpperDoor(int i, int j)
        {

            if (floorLayout[i - 1, j] != null)
            {
                if (floorLayout[i - 1, j].bottomWall.wallDoor != null)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        public bool checkLowerDoor(int i, int j)
        {

            if (floorLayout[i + 1, j] != null)
            {
                if (floorLayout[i + 1, j].topWall.wallDoor != null)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        public bool checkRightDoor(int i, int j)
        {

            if (floorLayout[i , j+1] != null)
            {
                if (floorLayout[i , j+1].rightWall.wallDoor != null)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        public Room enterDoor(Character mainChar)
        {
            if (currentRoom.RoomClear())
            {
               if(currentRoom.CRIntersect(mainChar.loc, currentRoom.bottomWall.exitBox))
                {
                    mainChar.loc.Center.X = 800;
                    mainChar.loc.Center.Y = 50+ mainChar.loc.Radius;
                    y++;
                }
                if (currentRoom.CRIntersect(mainChar.loc, currentRoom.topWall.exitBox))
                {
                    mainChar.loc.Center.X = 800 ;
                    mainChar.loc.Center.Y = 850- mainChar.loc.Radius;
                    y--;
                }
                if (currentRoom.CRIntersect(mainChar.loc, currentRoom.rightWall.exitBox))
                {
                    mainChar.loc.Center.X = 50 + mainChar.loc.Radius;
                    mainChar.loc.Center.Y = 450;
                    x++;
                }
                if (currentRoom.CRIntersect(mainChar.loc, currentRoom.leftWall.exitBox))
                {
                    mainChar.loc.Center.X = 1550 - mainChar.loc.Radius;
                    mainChar.loc.Center.Y = 450;
                    x--;
                }
                return enterRoom();
            }
            return currentRoom;
        }

        public Room enterRoom()
        {
            Room currentRoom = floorLayout[x, y];
            return currentRoom;

        }
    }
}


