using System;

namespace PathEditor.Core.Paper
{
    public class WihoutFakeBreakLine : IPaper
    {
        private readonly IPaper _paper;

        public WihoutFakeBreakLine(IPaper paper)
        {
            _paper = paper;
        }

        public string Text => Prepare(_paper).Text;
        public int Cursor => Prepare(_paper).Cursor;

        private static IPaper Prepare(IPaper paper)
        {
            for (var separatorIndex = paper.Text.IndexOf(Environment.NewLine); separatorIndex != -1; separatorIndex = paper.Text.IndexOf(Environment.NewLine, separatorIndex + Environment.NewLine.Length))
            {
                if (separatorIndex == 0 || paper.Text[separatorIndex - 1] != ';')
                    paper = new Reduced(paper, separatorIndex, Environment.NewLine.Length);
            }
            return paper;
        }
    }
}