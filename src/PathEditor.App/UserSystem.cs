using System.Security.Principal;
using PathEditor.Core.User;

namespace PathEditor.App
{
    public sealed class UserSystem : IUser
    {
        public bool IsAdministrator => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
}