namespace Shop.Application.Visitors.SaveVisitorInfo
{
    public class RequestSaveVisitorInfoDto
    {
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhysicalPath { get; set; }
        public VisitorVersionDto Browser { get; set; }
        public VisitorVersionDto OperationSystem { get; set; }
        public DeviceDto Device { get; set; }
        public string VisitorId { get; set; }
    }
}
