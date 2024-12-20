

namespace Domain.Dto.PerformanceReviews
{
    public class PerformanceReviewReadDto
    {
        public int Id { get; set; }
        public DateOnly ReviewDate { get; set; }
        public int ReviewScore { get; set; }
        public string ReviewNote { get; set; } = string.Empty;
        public long EmployeeId { get; set; }
    }
}
