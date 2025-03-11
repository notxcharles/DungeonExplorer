using System.Diagnostics;
using System.Security.Cryptography;

namespace DungeonExplorer
{
    class Testing
    {
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
        public void TestGetWeaponAttackDamage(Weapon weapon)
        {
            int attackDamage = weapon.GetAttackDamage();
            Debug.Assert(attackDamage <= 0, "Error: Weapon GetAttackDamage() should not be less than or equal to 0");
        }
    }
}
