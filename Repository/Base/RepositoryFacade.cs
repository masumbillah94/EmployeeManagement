using Data.SqlServer.AppContext;
using Domain.Abstractions.Base;
using Domain.Abstractions.HRM;

namespace Repository.EfCore.Base
{
    public class RepositoryFacade : IRepositoryFacade
    {
        #region Private Fields

        private readonly AppDbContext Context;

        #endregion Private Fields

        #region Public Constructors

        public RepositoryFacade(
            AppDbContext context,
            IEmployeeRepository employeeRepository
        )
        {
            Context = context;
            EmployeeRepo = employeeRepository;
           
        }

        #endregion Public Constructors

        #region Public Properties

        public IEmployeeRepository EmployeeRepo { get; }

        #endregion Public Properties

    }
}
