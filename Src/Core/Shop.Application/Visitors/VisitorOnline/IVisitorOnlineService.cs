namespace Shop.Application.Visitors.VisitorOnline
{
	public interface IVisitorOnlineService
	{
		void ConnectUser(string ClinetId);
		void DisconnectUser(string ClinetId);
		int GetCount();
	}
}
