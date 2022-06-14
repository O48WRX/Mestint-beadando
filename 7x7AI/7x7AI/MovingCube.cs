using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7x7AI
{
    class MovingCube
    {
        public enum Color { kék, piros };

        Color[] sides = new Color[5];
        byte red = 2;

        public Color GetColor(int side)
        {
            return sides[side];
        }

        public MovingCube(Color[] sides)
        {
            this.sides = sides;
        }

        public string[,] MoveUp(string[,] map, byte[] playerLocation, out string success, out byte[] playerLocation1)
        {
            if (playerLocation[0] == 7 && playerLocation[1] == 3)
            {
                success = "Finish";
                playerLocation1 = playerLocation;
                return map;
            }
            if(map[playerLocation[0]-1, playerLocation[1]] != " H " && sides[0] != Color.piros)
            {
                switch (red)
                {
                    case 2:
                        {
                            red = 0;
                            sides[0] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                    case 4:
                        {
                            red = 2;
                            sides[2] = Color.piros;
                            sides[4] = Color.kék;
                            break;
                        }
                }
                map[playerLocation[0], playerLocation[1]] = "  ";
                map[playerLocation[0] - 1, playerLocation[1]] = " # ";
                playerLocation1 = new byte[] { (byte)((int)playerLocation[0] - 1), playerLocation[1] };
                success = "success";
                return map;
            }
            success = "failed";
            playerLocation1 = playerLocation;
            return map;
        }
    }
}
