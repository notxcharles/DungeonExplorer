using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("charles", 250);
            Game game = new Game("Room Game", 5, player);
            Testing tests = new Testing();
            tests.RunTests();
            game.Start();
            Console.ReadKey();
        }
    }
}
