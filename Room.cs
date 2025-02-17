namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private int[] dimensions = new int[2];
        public Room(string description, int[] dimensions)
        {
            this.description = description;
            this.dimensions = dimensions;
        }

        public string GetDescription()
        {
            return description;
        }

        public int[] GetDimensions()
        {
            return dimensions;
        }
    }
}