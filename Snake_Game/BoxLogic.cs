using System;

namespace Snake_Game
{
    public class BoxLogic
    {
        public static char[,] DrawBox(int height, int width)
        {
            char[,] display = new char[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == 0 || y == height - 1 || x == 0 || x == width - 1)
                        display[y, x] = '#';
                    else
                        display[y, x] = ' ';
                }
            }
            return display;
        }

        public static void PrintBox(char[,] display)
        {
            for (int y = 0; y < display.GetLength(0); y++)
            {
                for (int x = 0; x < display.GetLength(1); x++)
                {
                    Console.Write(display[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
