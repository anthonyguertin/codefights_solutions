namespace CodeFights.CodeFightTests
{
    internal class AddTests : Tests
    {
        private int param1;
        private int param2;
        public int Param1 { 
            get {
                return 1;
            } 
            set {
                param1 = value;
            }
        }
        public int Param2
        {
            get
            {
                return 2;
            }
            set
            {
                param2 = value;
            }
        }
    }
}
