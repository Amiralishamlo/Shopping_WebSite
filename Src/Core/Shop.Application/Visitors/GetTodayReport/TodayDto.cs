﻿namespace Shop.Application.Visitors.GetTodayReport
{
    public class TodayDto
    {
        public long PageView { get; set; }
        public long Visitor { get; set; }
        public float ViewsPerVisitor { get; set; }
        public VisitCountDto VisitPerhour { get; set; }
    }
}
