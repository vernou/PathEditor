namespace PathEditor.Core
{
    public sealed class Sum
    {
        private readonly int _a;
        private readonly int _b;

        public Sum(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int AsInteger() => _a + _b;
    }
}