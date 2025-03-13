using System.Diagnostics;

namespace DungeonExplorer
{
    class Testing
    {
        public Testing()
        {

        } 
        public static void TestForPositiveInteger(int value)
        {
            Debug.Assert(value > 0, "Error: Value wasn't a positive integer");
        }
        public static void TestForZeroOrAbove(int value)
        {
            Debug.Assert(value >= 0, "Error: Value wasn't a positive integer or 0");
        }

    }
}
 