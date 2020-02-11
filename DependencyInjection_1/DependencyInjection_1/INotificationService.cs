using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection_1
{
    interface INotificationService
    {
        void NotifyUsernameChanged(User user);
        void NotifyIPChanged(User user);
    }
}
