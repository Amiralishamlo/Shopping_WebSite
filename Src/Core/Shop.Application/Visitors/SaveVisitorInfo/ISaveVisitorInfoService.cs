using Shop.Domain.Visitors;

namespace Shop.Application.Visitors.SaveVisitorInfo
{
    public interface ISaveVisitorInfoService
    {
        void Execute(RequestSaveVisitorDto request);
    }
}
