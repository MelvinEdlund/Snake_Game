using Snake_Game;
using System;
using System.Collections.Generic;
using System.Threading;

int width = 30;
int height = 15;
Random rnd = new Random();
Console.CursorVisible = false;

bool quitGame = false;

while (!quitGame)
{
    // initiera spelet
    Console.Clear();
    char[,] box = BoxLogic.DrawBox(height, width);
    List<(int x, int y)> snake = new List<(int, int)>();
    int snakeLength = 1;

    BoxLogic.PrintBox(box);

    // starta ormen i mitten
    int x = width / 2;
    int y = height / 2;
    snake.Add((x, y));
    box[y, x] = '@';
    Console.SetCursorPosition(x, y);
    Console.Write('@');

    // första äpplet
    GameLogic.PlaceApple(box, width, height, rnd);

    // starta riktning (höger)
    int dx = 1;
    int dy = 0;

    bool running = true;

    while (running)
    {
        // kolla om en tangent är tryckt
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.RightArrow && dx != -1) { dx = 1; dy = 0; }
            if (key == ConsoleKey.LeftArrow && dx != 1) { dx = -1; dy = 0; }
            if (key == ConsoleKey.UpArrow && dy != 1) { dx = 0; dy = -1; }
            if (key == ConsoleKey.DownArrow && dy != -1) { dx = 0; dy = 1; }
        }

        int newX = snake[0].x + dx;
        int newY = snake[0].y + dy;

        // kolla väggar eller självkrock
        if (box[newY, newX] == '#' || box[newY, newX] == '@')
        {
            running = false;
            break;
        }

        if (box[newY, newX] == 'ä')
        {
            snakeLength++;
            GameLogic.PlaceApple(box, width, height, rnd);
        }

        GameLogic.Move(newX, newY, snake, box, snakeLength);

        Thread.Sleep(175); 
    }

    Console.Clear();
    Console.WriteLine("GAME OVER!");
    Console.WriteLine("Tryck 'R' för att starta om eller 'ESC' för att avsluta.");

    while (true)
    {
        var checkKey = Console.ReadKey(true).Key;
        if (checkKey == ConsoleKey.Escape) { quitGame = true; break; }
        if (checkKey == ConsoleKey.R) { break; }
    }
}
