namespace PathEditor.Core.Paper
{
    public sealed class TextOf : IPaper
    {
        public TextOf(string text, int cursor)
        {
            Text = text;
            Cursor = cursor;
        }

        public string Text { get; }
        public int Cursor { get; }
    }
}