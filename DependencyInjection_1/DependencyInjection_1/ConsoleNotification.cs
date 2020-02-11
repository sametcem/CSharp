using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_1
{
    internal class ConsoleNotification : INotificationService
    {
        public void NotifyIPChanged(User user)
        {
            throw new NotImplementedException();
        }

        public void NotifyUsernameChanged(User user)
        {
            Console.WriteLine($"Username has been changed to: {user.Username}");
        }
    }
}
