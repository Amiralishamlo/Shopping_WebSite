using Microsoft.AspNetCore.SignalR;
using Shop.Application.Visitors.VisitorOnline;

namespace Shop_WebSite_EndPoint.Hubs
{
    public class OnlineVisitorHub:Hub
    {
        private readonly IVisitorOnlineService _visitorOnline;

		public OnlineVisitorHub(IVisitorOnlineService visitorOnline)
		{
			_visitorOnline = visitorOnline;
		}

		public override Task OnConnectedAsync()
        {
            string visitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            _visitorOnline.ConnectUser(visitorId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
			string visitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
			_visitorOnline.DisconnectUser(visitorId);
			return base.OnDisconnectedAsync(exception);
        }
    }
}