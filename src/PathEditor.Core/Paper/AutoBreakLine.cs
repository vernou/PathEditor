using System;

namespace PathEditor.Core.Paper
{
    public sealed class AutoBreakLine : IPaper
    {
        private readonly IPaper _paper;

        public AutoBreakLine(IPaper paper)
        {
            _paper = paper;
        }

        public string Text => Prepare(_paper).Text;

        public int Cursor => Prepare(_paper).Cursor;

        private static IPaper Prepare(IPaper paper)
        {
            for (var separatorIndex = paper.Text.IndexOf(';'); separatorIndex != -1; separatorIndex = paper.Text.IndexOf(';', separatorIndex + 1))
            {
                if ((separatorIndex + 1) != paper.Text.Length && paper.Text.IndexOf(Environment.NewLine, separatorIndex) != separatorIndex + 1)
                {
                    paper = new Merged(paper, Environment.NewLine, separatorIndex + 1);
                }
            }
            return paper;
        }
    }
}