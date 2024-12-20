
using Domain.Entities.EmployeePerformances;
namespace Domain.Abstractions.PerformanceReviews
{
    public interface IPerformanceReviewRepository
    {
        #region Public Methods

        Task<PerformanceReview> AddEntity(PerformanceReview entity);

        #endregion Public Methods
    }
}
