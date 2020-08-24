namespace Assignment1
{
    class PositionSystem
    {
        private int x, y;
        private static PositionSystem instance;
        public int X
        {
            get
            {
                return x;
            }
            set { x = value; }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        private PositionSystem()
        {

        }
        public static PositionSystem Instance()
        {
            if (instance == null)
            {
                instance = new PositionSystem();
            }
            return instance;
        }
    }
}
