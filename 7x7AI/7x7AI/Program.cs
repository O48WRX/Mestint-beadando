using System;
using System.Collections.Generic;
using System.Threading;

namespace _7x7AI
{
    class Program
    {
        static Random rnd = new Random();


        static string[,] startMap = { { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " },
                                      { " H ","   ", " H ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " # ", "   "," H " },
                                      { " H "," H ", "   ", "   ", " H ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", "   ", "   ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", " H ", "   ", "   "," H " },
                                      { " H ","   ", " H ", " C ", "   ", "   ", "   ", "   "," H " },
                                      { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " }};

        static byte[] PlayerStartingLocation = { 2, 6 };


        static string[,] map = startMap;

        static byte[] playerLocation = PlayerStartingLocation;

        static MovingCube player = new MovingCube(new Color[] { Color.kék, Color.kék, Color.piros, Color.kék, Color.kék });

        static int WaitTime = 500;
        static void Main(string[] args)
        {
            string[,] map = startMap;

            byte[] playerLocation = PlayerStartingLocation;

            RefreshVisualization();

            //TestAutoWin();

            //TrialAndError(WaitTime);
            //UpgradedTrialAndError(WaitTime);

            //RestartingTrialAndError(1,500);
            //UpgradedRestartingTrialAndError(50,500);

            DepthSearch(10);

            Console.ReadKey();
        }

        static void RefreshVisualization()
        {
            Console.Clear();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
            Console.WriteLine(String.Format($"        {player.GetColor(0)}"));
            Console.WriteLine(String.Format($"    {player.GetColor(1)} {player.GetColor(2)} {player.GetColor(3)}"));
            Console.WriteLine(String.Format($"        {player.GetColor(4)}"));
        }

        static public string UserMoveUp()
        {
            string succes = "";
            byte[] palayerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveUp(map, playerLocation, out succes, out palayerLocation2);
            playerLocation = palayerLocation2;
            RefreshVisualization();
            return succes;
        }
        static public string UserMoveDown()
        {
            string succes = "";
            byte[] playerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveDown(map, playerLocation, out succes, out playerLocation2);
            playerLocation = playerLocation2;
            RefreshVisualization();
            return succes;
        }
        static public string UserMoveLeft()
        {
            string succes = "";
            byte[] playerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveLeft(map, playerLocation, out succes, out playerLocation2);
            playerLocation = playerLocation2;
            RefreshVisualization();
            return succes;
        }
        static public string UserMoveRight()
        {
            string succes = "";
            byte[] playerLocation2 = playerLocation;
            Console.Clear();
            map = player.MoveRight(map, playerLocation, out succes, out playerLocation2);
            playerLocation = playerLocation2;
            RefreshVisualization();
            return succes;
        }

        // Ez csak egy finish tesztelő.
        static public void TestAutoWin()
        {
            Thread.Sleep(WaitTime);
            UserMoveRight();

            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(WaitTime);
                UserMoveDown();
            }

            Thread.Sleep(WaitTime);
            UserMoveLeft();

            Thread.Sleep(WaitTime);
            UserMoveDown();

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(WaitTime);
                UserMoveLeft();
            }

            Console.WriteLine("Finish");
        }

        // Próba-hiba
        static public void TrialAndError(int wait)
        {
            string success = "";

            while (success != "failed")
            {
                int nextStep = rnd.Next(0, 3);

                switch (nextStep)
                {
                    case 0:
                        success = UserMoveUp();
                        break;
                    case 1:
                        success = UserMoveDown();
                        break;
                    case 2:
                        success = UserMoveRight();
                        break;
                    case 3:

                        success = UserMoveLeft();
                        break;
                }
                Thread.Sleep(wait);
            }
        }

        // Fejlesztett Próba-hiba
        static public void UpgradedTrialAndError(int wait)
        {
            string success = "";
            int lastStep = 9;

            while (success != "failed")
            {
                int nextStep = rnd.Next(0, 3);

                while (nextStep == lastStep)
                {
                    nextStep = rnd.Next(0, 3);
                }

                switch (nextStep)
                {
                    case 0:
                        success = UserMoveUp();
                        lastStep = 1;
                        break;
                    case 1:
                        success = UserMoveDown();
                        lastStep = 0;
                        break;
                    case 2:
                        success = UserMoveRight();
                        lastStep = 3;
                        break;
                    case 3:
                        success = UserMoveLeft();
                        lastStep = 2;
                        break;
                }
                Thread.Sleep(wait);
            }
        }

        // Restartolós Próba-hiba
        static public void RestartingTrialAndError(int waitBetweenSteps, int waitBetweenStarts)
        {
            while (playerLocation[0] != 7 && playerLocation[1] != 3)
            {
                playerLocation = new byte[] { 2, 6 };
                map = new string[,] { { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " },
                                      { " H ","   ", " H ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " # ", "   "," H " },
                                      { " H "," H ", "   ", "   ", " H ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", "   ", "   ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", " H ", "   ", "   "," H " },
                                      { " H ","   ", " H ", " C ", "   ", "   ", "   ", "   "," H " },
                                      { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " }
                };
                player = new MovingCube(new Color[] { Color.kék, Color.kék, Color.piros, Color.kék, Color.kék });

                TrialAndError(waitBetweenSteps);

                Thread.Sleep(waitBetweenStarts);
            }
        }

        // Fejlesztett próba-hiba
        static public void UpgradedRestartingTrialAndError(int waitBetweenSteps, int waitBetweenStarts)
        {
            while (playerLocation[0] != 7 && playerLocation[1] != 3)
            {
                playerLocation = new byte[] { 2, 6 };
                map = new string[,] { { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " },
                                      { " H ","   ", " H ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " # ", "   "," H " },
                                      { " H "," H ", "   ", "   ", " H ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", "   ", "   ", "   "," H " },
                                      { " H ","   ", "   ", "   ", "   ", "   ", " H ", "   "," H " },
                                      { " H ","   ", "   ", " H ", "   ", " H ", "   ", "   "," H " },
                                      { " H ","   ", " H ", " C ", "   ", "   ", "   ", "   "," H " },
                                      { " H "," H ", " H ", " H ", " H ", " H ", " H ", " H "," H " }
                };
                player = new MovingCube(new Color[] { Color.kék, Color.kék, Color.piros, Color.kék, Color.kék });

                UpgradedTrialAndError(waitBetweenSteps);

                Thread.Sleep(waitBetweenStarts);
            }
        }

        //Egylépcsős mélységi
        static public void DepthSearch(int wait)
        {
            string success = "";

            int steps = 0;

            while (success != "failed")
            {
                bool up = player.TryMoveUp(map, playerLocation);
                bool down = player.TryMoveDown(map, playerLocation);
                bool left = player.TryMoveLeft(map, playerLocation);
                bool right = player.TryMoveRight(map, playerLocation);

                List<int> possiblestep = new List<int>();

                if (up)
                {
                    possiblestep.Add(0);
                }
                if (down)
                {
                    possiblestep.Add(1);
                }
                if (right)
                {
                    possiblestep.Add(2);
                }
                if (left)
                {
                    possiblestep.Add(3);
                }

                int nextStep = rnd.Next(0, possiblestep.Count);

                switch (possiblestep[nextStep])
                {
                    case 0:
                        success = UserMoveUp();
                        break;
                    case 1:
                        success = UserMoveDown();
                        break;
                    case 2:
                        success = UserMoveRight();
                        break;
                    case 3:
                        success = UserMoveLeft();
                        break;
                }

                if (success == "Finish")
                {
                    Console.WriteLine("Lépések száma: " + steps);
                    break;
                }

                steps++;

                Thread.Sleep(wait);
            }
        }
    }
}
