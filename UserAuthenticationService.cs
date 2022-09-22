using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnShellApp
{
    public interface IUserAuthenticationService
    {
        bool IsSignedIn { get; }

        Task SignIn();

        Task SignOut();
    }

    public class UserAuthenticationService : IUserAuthenticationService
    {
        public bool IsSignedIn { get; private set; }

        public Task SignIn()
        {
            IsSignedIn = true;

            return Task.CompletedTask;
        }

        public Task SignOut()
        {
            IsSignedIn = false;

            return Task.CompletedTask;
        }
    }
}
