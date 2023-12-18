namespace Shop.Application.Visitors.GetTodayReport
{
    public class GeneralStatsDto
    {
        public long TotalPageViews { get; set; }
        public long TotalVisitor { get; set; }
        public float PageViewPerVisit { get; set; }
        public VisitCountDto VisitPerDay { get; set; }
    }
}
