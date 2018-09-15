using System;
using System.Collections.Generic;
using System.Text;

namespace PathEditor.Core.Paper
{
    public sealed class WithoutCurrentLine : IPaper
    {
        private readonly IPaper _paper;

        public WithoutCurrentLine(IPaper paper)
        {
            _paper = paper;
        }

        public string Text => RemoveCurrentLine();
        public int Cursor => Compute();

        private string RemoveCurrentLine()
        {
            var text = _paper.Text;
            if (text == string.Empty)
                return string.Empty;
            var cursor = _paper.Cursor;
            var precedent = text.LastIndexOf(Environment.NewLine, cursor);
            var next = text.IndexOf(Environment.NewLine, cursor);
            if (precedent == -1)
                precedent = 0;
            else
                precedent += Environment.NewLine.Length;
            if (next == -1)
                next = text.Length;
            else
                next += Environment.NewLine.Length;
            return text.Remove(precedent, next - precedent);
        }

        private int Compute()
        {
            var text = _paper.Text;
            if (text == string.Empty)
                return 0;
            var cursor = _paper.Cursor;
            var precedent = text.LastIndexOf(Environment.NewLine, cursor);
            return precedent == -1 ? 0 : (precedent + Environment.NewLine.Length);
        }
    }
}