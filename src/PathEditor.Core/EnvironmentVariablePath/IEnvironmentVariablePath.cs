namespace PathEditor.Core.EnvironmentVariablePath
{
    public interface IEnvironmentVariablePath
    {
        string System { get; set; }
        string User { get; set; }
    }
}