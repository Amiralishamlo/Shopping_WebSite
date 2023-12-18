using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Application.Visitors.SaveVisitorInfo;
using UAParser;

namespace Shop_WebSite_EndPoint.Utilities.Filters
{
    public class SaveVisitorFilter :IActionFilter
    {
        private readonly ISaveVisitorInfoService _saveVisitorInfoService;
        public SaveVisitorFilter(ISaveVisitorInfoService saveVisitorInfoService)
        {
            _saveVisitorInfoService = saveVisitorInfoService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgent);
            var referer = context.HttpContext.Request.Headers["Referer"].ToString();
            var currentUrl = context.HttpContext.Request.Path;
            var Request = context.HttpContext.Request;
            //string visitorId = context.HttpContext.Request.Cookies["VisitorId"];

            _saveVisitorInfoService.Execute(new RequestSaveVisitorDto
            {
                Browser = new VisitorVersionDto
                {
                    Family = clientInfo.UA.Family,
                    Version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"
                },
                CurrentLink = currentUrl,
                Device = new DeviceDto
                {
                    Brand = clientInfo.Device.Brand,
                    Family = clientInfo.Device.Family,
                    IsSpider = clientInfo.Device.IsSpider,
                    Model = clientInfo.Device.Model,
                },
                Ip = ip,
                Method = Request.Method,
                OperationSystem = new VisitorVersionDto()
                {
                    Family = clientInfo.OS.Family,
                    Version = $"{clientInfo.OS.Major}.{clientInfo.OS.Minor}.{clientInfo.OS.Patch}.{clientInfo.OS.PatchMinor}"
                },
                PhysicalPath = $"{controllerName}/{actionName}",
                Protocol = Request.Protocol,
                RefeeereLink = referer,
            });
        }
    }
}
