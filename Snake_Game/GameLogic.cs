using System;
using System.Collections.Generic;

namespace Snake_Game
{
    public static class GameLogic
    {
        public static void PlaceApple(char[,] box, int width, int height, Random rnd)
        {
            int rx, ry;
            do
            {
                rx = rnd.Next(1, width - 1);
                ry = rnd.Next(1, height - 1);
            } while (box[ry, rx] != ' ');

            box[ry, rx] = 'ä';
            Console.SetCursorPosition(rx, ry);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('ä');
            Console.ResetColor();
        }

        public static void Move(int newX, int newY, List<(int x, int y)> snake, char[,] box, int snakeLength)
        {
            // lägg in nytt huvud
            snake.Insert(0, (newX, newY));
            box[newY, newX] = '@';
            Console.SetCursorPosition(newX, newY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('@');
            Console.ResetColor();

            // om ormen är för lång -> ta bort svansen
            if (snake.Count > snakeLength)
            {
                var tail = snake[^1];
                box[tail.y, tail.x] = ' ';
                Console.SetCursorPosition(tail.x, tail.y);
                Console.Write(' ');
                snake.RemoveAt(snake.Count - 1);
            }
        }
    }
}
