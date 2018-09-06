using System;

namespace PathEditor.Core.Paper
{
    public sealed class Reduced : IPaper
    {
        private readonly IPaper _paper;
        private readonly int _at;
        private readonly int _length;

        public Reduced(IPaper paper, int at, int length)
        {
            _paper = paper;
            _at = at;
            _length = length;
        }

        public string Text => _paper.Text.Remove(_at, _length);
        public int Cursor => _paper.Cursor > _at ? Math.Max(_paper.Cursor - _length, _at) : _paper.Cursor;
    }
}