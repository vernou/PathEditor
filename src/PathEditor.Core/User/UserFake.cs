namespace PathEditor.Core.User
{
    public sealed class UserFake : IUser
    {
        public UserFake(bool isAdministrator)
        {
            IsAdministrator = isAdministrator;
        }

        public bool IsAdministrator { get; }
    }
}