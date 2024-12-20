using Domain.Abstractions.HRM;

namespace Domain.Abstractions.Base
{
    public interface IRepositoryFacade
    {
        #region Public Properties

        IEmployeeRepository EmployeeRepo { get; }

        #endregion Public Properties
    }
}
