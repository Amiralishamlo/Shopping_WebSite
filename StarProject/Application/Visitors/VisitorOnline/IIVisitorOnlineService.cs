using System.Collections.Generic;
using System.Text;

namespace Application.Visitors.VisitorOnline
{
    public interface IIVisitorOnlineService
    {
        void ConnectUser(string ClientId);
        void DisConnectUser(string ClientId);
        int GetCount();
    }
}
