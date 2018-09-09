namespace PathEditor.Core.EnvironmentVariablePath
{
    public sealed class EnvironmentVariablePathInMemory : IEnvironmentVariablePath
    {
        public EnvironmentVariablePathInMemory() :
            this(@"C:\TMP\Path1;C:\TMP\Path2;C:\TMP\Path3;")
        { }

        public EnvironmentVariablePathInMemory(string paths)
        {
            Value = paths;
        }

        public string Value { get; set; }
    }
}