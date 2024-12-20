using Data.SqlServer.AppContext;
using Domain.Abstractions.Base;
using Domain.Abstractions.Departments;
using Domain.Abstractions.Employees;
using Domain.Abstractions.PerformanceReviews;

namespace Repository.Base
{
    public class RepositoryFacade : IRepositoryFacade
    {
        #region Private Fields

        private readonly AppDbContext Context;

        #endregion Private Fields

        #region Public Constructors

        public RepositoryFacade(
            AppDbContext context,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IPerformanceReviewRepository performanceReviewRepository
        )
        {
            Context = context;
            EmployeeRepo = employeeRepository;
            DepartmentRepo = departmentRepository;
            PerformanceReviewRepo= performanceReviewRepository;

        }

        #endregion Public Constructors

        #region Public Properties

        public IEmployeeRepository EmployeeRepo { get; }
        public IDepartmentRepository DepartmentRepo { get; }
        public IPerformanceReviewRepository PerformanceReviewRepo { get; }

        #endregion Public Properties

    }
}
