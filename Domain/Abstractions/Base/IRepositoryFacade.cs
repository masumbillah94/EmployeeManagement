using Domain.Abstractions.Departments;
using Domain.Abstractions.Employees;
using Domain.Abstractions.PerformanceReviews;

namespace Domain.Abstractions.Base
{
    public interface IRepositoryFacade
    {
        #region Public Properties

        IEmployeeRepository EmployeeRepo { get; }
        IDepartmentRepository DepartmentRepo { get; }
        IPerformanceReviewRepository PerformanceReviewRepo { get; }

        #endregion Public Properties
    }
}
