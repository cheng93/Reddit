namespace Reddit253.UnitTest.Mock.MockTerminals
{
    internal class MockTerminal_NonEmpty : MockTerminal
    {
        public MockTerminal_NonEmpty()
            : base(GetCharacters())
        {
            
        }

        public static char?[,] GetCharacters()
        {
            var characters = new char?[10, 10];
            characters[0, 0] = 'A';
            characters[0, 1] = ' ';
            characters[0, 3] = 'C';

            return characters;
        }
    }
}
