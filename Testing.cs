using System.Diagnostics;
using System.Security.Cryptography;

namespace DungeonExplorer
{
    class Testing
    {
        public Testing()
        {

        }
        public void RunTests()
        {
            TestGetTurnDecisionsWithMonsterAlive();
        }

        private void TestGetTurnDecisionsWithMonsterAlive()
        {
            // Simulate valid user input within the range of 0 to 6
            Player player = new Player("j", 100);
            //Game game = new Game("gname", player);
            bool monsterAlive = true;

            // Use Debug.Assert to verify the expected outcome
            int result = player.GetTurnDecisions(monsterAlive);
            Debug.Assert(result >= 0 && result <= 6, $"Test failed: Expected a value between 0 and 6, but got {result}.");
        }
        public static void TestForPositiveInteger(int value)
        {
            Debug.Assert(value > 0, "Error: Value wasn't a positive integer");
        }
        public static void TestForZeroOrAbove(int value)
        {
            Debug.Assert(value >= 0, "Error: Value wasn't a positive integer");
        }

    }
}
