namespace PathEditor.Core.Paper
{
    public sealed class Merged : IPaper
    {
        private readonly IPaper _text;
        private readonly string _inserted;
        private readonly int _at;

        public Merged(IPaper text, string inserted, int at)
        {
            _text = text;
            _inserted = inserted;
            _at = at;
        }

        public string Text => _text.Text.Insert(_at, _inserted);
        public int Cursor => _text.Cursor >= _at ? _text.Cursor + _inserted.Length : _text.Cursor;
    }
}