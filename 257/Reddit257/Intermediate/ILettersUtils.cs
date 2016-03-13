namespace Reddit257.Intermediate
{
    public interface ILettersUtils
    {
        bool CanBeFormed(string word, string lettersRemaining);
        string Remove(string word, string letters);
    }
}