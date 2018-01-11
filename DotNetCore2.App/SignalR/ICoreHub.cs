using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.App.SignalR
{
    public interface ICoreHub
    {
        void UserUpdated();
    }
}
