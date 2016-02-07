namespace Reddit252
{
    public class Pair
    {
        public char Character { get; private set; }

        public int StartIndex { get; private set; }

        public int EndIndex { get; private set; }

        public Pair(char character, int startIndex, int endIndex)
        {
            Character = character;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
