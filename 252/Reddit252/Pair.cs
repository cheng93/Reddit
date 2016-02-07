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

        public override bool Equals(object obj)
        {
            var pair = obj as Pair;
            return Equals(pair);
        }

        protected bool Equals(Pair pair)
        {
            if (pair == null)
                return false;
            return Character == pair.Character
                   && StartIndex == pair.StartIndex
                   && EndIndex == pair.EndIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Character.GetHashCode();
                hashCode = (hashCode * 397) ^ StartIndex;
                hashCode = (hashCode * 397) ^ EndIndex;
                return hashCode;
            }
        }
    }
}
