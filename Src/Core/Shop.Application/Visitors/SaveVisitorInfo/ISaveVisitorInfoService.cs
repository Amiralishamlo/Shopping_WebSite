using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Visitors.SaveVisitorInfo
{
    public interface ISaveVisitorInfoService
    {
        void Execute(RequestSaveVisitorInfoDto request);
    }
}
