using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7x7AI
{
    public enum Color { kék, piros }
    class MovingCube
    {
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

        public string[,] MoveUp(string[,] map, byte[] playerLocation, out string succes, out byte[] playerLocation1)
        {
            if (playerLocation[0] == 7 && playerLocation[1] == 3)
            {
                succes = "Finish";
                playerLocation1 = playerLocation;
                return map;
            }
            if (map[playerLocation[0] - 1, playerLocation[1]] != " H " && sides[0] != Color.piros)
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
                map[playerLocation[0], playerLocation[1]] = "   ";
                map[playerLocation[0] - 1, playerLocation[1]] = " # ";
                playerLocation1 = new byte[] { (byte)((int)playerLocation[0] - 1), playerLocation[1] };
                succes = "succes";
                return map;
            }
            succes = "failed";
            playerLocation1 = playerLocation;
            return map;
        }
        public string[,] MoveDown(string[,] map, byte[] playerLocation, out string succes, out byte[] playerLocation1)
        {
            if (playerLocation[0] == 7 && playerLocation[1] == 3)
            {
                succes = "Finish";
                playerLocation1 = playerLocation;
                return map;
            }
            if (map[playerLocation[0] + 1, playerLocation[1]] != " H " && sides[4] != Color.piros)
            {
                switch (red)
                {
                    case 0:
                        {
                            red = 2;
                            sides[2] = Color.piros;
                            sides[0] = Color.kék;
                            break;
                        }
                    case 2:
                        {
                            red = 4;
                            sides[4] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                }
                map[playerLocation[0], playerLocation[1]] = "   ";
                map[playerLocation[0] + 1, playerLocation[1]] = " # ";
                playerLocation1 = new byte[] { (byte)((int)playerLocation[0] + 1), playerLocation[1] };
                succes = "succes";
                return map;
            }
            succes = "failed";
            playerLocation1 = playerLocation;
            return map;
        }
        public string[,] MoveLeft(string[,] map, byte[] playerLocation, out string succes, out byte[] playerLocation1)
        {
            if (playerLocation[0] == 7 && playerLocation[1] == 3)
            {
                succes = "Finish";
                playerLocation1 = playerLocation;
                return map;
            }
            if (map[playerLocation[0], playerLocation[1] - 1] != " H " && sides[1] != Color.piros)
            {
                switch (red)
                {
                    case 2:
                        {
                            red = 1;
                            sides[1] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                    case 3:
                        {

                            red = 2;
                            sides[2] = Color.piros;
                            sides[3] = Color.kék;
                            break;
                        }
                }
                map[playerLocation[0], playerLocation[1]] = "   ";
                map[playerLocation[0], playerLocation[1] - 1] = " # ";
                playerLocation1 = new byte[] { playerLocation[0], (byte)((int)playerLocation[1] - 1) };
                succes = "succes";
                return map;
            }
            playerLocation1 = playerLocation;
            succes = "failed";
            return map;
        }
        public string[,] MoveRight(string[,] map, byte[] playerLocation, out string succes, out byte[] playerLocation1)
        {
            if (playerLocation[0] == 7 && playerLocation[1] == 3)
            {
                succes = "Finish";
                playerLocation1 = playerLocation;
                return map;
            }
            if (map[playerLocation[0], playerLocation[1] + 1] != " H " && sides[3] != Color.piros)
            {
                switch (red)
                {
                    case 1:
                        {

                            red = 2;
                            sides[2] = Color.piros;
                            sides[1] = Color.kék;
                            break;
                        }
                    case 2:
                        {

                            red = 3;
                            sides[3] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                }
                map[playerLocation[0], playerLocation[1]] = "   ";
                map[playerLocation[0], playerLocation[1] + 1] = " # ";
                playerLocation1 = new byte[] { playerLocation[0], (byte)(playerLocation[1] + 1) };
                succes = "succes";
                return map;
            }
            playerLocation1 = playerLocation;
            succes = "failed";
            return map;
        }

        public bool TryMoveUp(string[,] map, byte[] playerLocation)
        {
            if (map[playerLocation[0] - 1, playerLocation[1]] != " H " && sides[0] != Color.piros)
            {
                return true;
            }
            return false;
        }
        public bool TryMoveDown(string[,] map, byte[] playerLocation)
        {
            if (map[playerLocation[0] + 1, playerLocation[1]] != " H " && sides[4] != Color.piros)
            {

                return true;
            }
            return false;
        }
        public bool TryMoveLeft(string[,] map, byte[] playerLocation)
        {
            if (map[playerLocation[0], playerLocation[1] - 1] != " H " && sides[1] != Color.piros)
            {
                return true;
            }
            return false;
        }
        public bool TryMoveRight(string[,] map, byte[] playerLocation)
        {
            if (map[playerLocation[0], playerLocation[1] + 1] != " H " && sides[3] != Color.piros)
            {
                return true;
            }
            return false;
        }
    }
}

