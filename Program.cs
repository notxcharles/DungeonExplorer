using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("charles", 250);
            Game game = new Game("Room Game", 5, player);
            game.Start();
            Console.ReadKey();
        }
    }
}
