namespace Reddit253
{
    public interface ITerminal
    {
        char? GetValue(int row, int column);
        void SetValue(int row, int column, char value);
        void ClearValue(int row, int column);
        void SetCursor(int row, int column);
    }
}