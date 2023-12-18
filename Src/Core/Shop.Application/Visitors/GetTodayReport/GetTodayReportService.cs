using MongoDB.Driver;
using Shop.Application.Interfaces.Contexts;
using Shop.Domain.Visitors;

namespace Shop.Application.Visitors.GetTodayReport
{
    public class GetTodayReportService : IGetTodayReportService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> _mongoCollection;

        public GetTodayReportService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _mongoCollection = _mongoDbContext.GetCollection();
        }

        public ResultTodayRepotDto Execute()
        {
            DateTime Start=DateTime.Now.Date;
            DateTime End = DateTime.Now.AddDays(1);

            var TodayPageViewCount= _mongoCollection.AsQueryable()
                .Where(x=>x.Time>Start && x.Time<End).LongCount();
            var TodayVisitorCount = _mongoCollection.AsQueryable()
            .Where(x => x.Time > Start && x.Time < End).GroupBy(x=>x.VisitorId).LongCount();

            var AllPageViewCount=_mongoCollection.AsQueryable().LongCount();
            var AllVisitorCount = _mongoCollection.AsQueryable().GroupBy(x=>x.VisitorId).LongCount();

            return new ResultTodayRepotDto
            {
                Today = new TodayDto
                {
                    PageView = TodayPageViewCount,
                    Visitor = TodayVisitorCount,
                    ViewsPerVisitor = GetAvg(AllPageViewCount,AllVisitorCount),
                    VisitPerhour= GTetVisitPerHour(Start,End),
                },
                GeneralStats = new GeneralStatsDto
                {
                    TotalPageViews=AllPageViewCount,
                    TotalVisitor=AllVisitorCount,
                    PageViewPerVisit= GetAvg(AllPageViewCount,AllVisitorCount),
                    VisitPerDay = GetVisitPerDay()
                }
            };
        }
        private VisitCountDto GTetVisitPerHour(DateTime start, DateTime end)
        {
            var TodayPageViewList = _mongoCollection.AsQueryable().Where(
              p => p.Time >= start && p.Time < end)
                .Select(p => new { p.Time }).ToList();

            VisitCountDto visitPerHour = new VisitCountDto()
            {
                Display = new string[24],
                Value = new int[24],
            };

            for (int i = 0; i <= 23; i++)
            {
                visitPerHour.Display[i] = $"h-{i}";
                visitPerHour.Value[i] = TodayPageViewList.Where(p => p.Time.Hour == i).Count();
            }

            return visitPerHour;
        }

        private VisitCountDto GetVisitPerDay()
        {
            DateTime MonthStart = DateTime.Now.Date.AddDays(-30);
            DateTime MonthEnds = DateTime.Now.Date.AddDays(1);
            var Month_PageViewList = _mongoCollection.AsQueryable()
                .Where(p => p.Time >= MonthStart && p.Time < MonthEnds)
                .Select(p => new { p.Time })
                .ToList();
            VisitCountDto visitPerDay = new VisitCountDto() { Display = new string[31], Value = new int[31] };
            for (int i = 0; i <= 30; i++)
            {
                var currentday = DateTime.Now.AddDays(i * (-1));
                visitPerDay.Display[i] = i.ToString();
                visitPerDay.Value[i] = Month_PageViewList.Where(p => p.Time.Date == currentday.Date).Count();
            }

            return visitPerDay;
        }
        private float GetAvg(long visitPage,long visitor)
        {
            if(visitor == 0)
            {
                return 0;
            }
            else
            {
                return visitPage / visitor;
            }
        }
    }
}
