namespace PathEditor.Core.EnvironmentVariablePath
{
    public interface IFormattedEnvironmentVariablePath
    {
        string System { get; }
        string User { get; }
    }
}