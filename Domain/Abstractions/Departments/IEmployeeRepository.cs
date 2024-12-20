using Domain.Dto.Common;
using Domain.Dto.Departments;
using Domain.Dto.Employees;
using Domain.Entities.Employees;

namespace Domain.Abstractions.Departments
{
    public interface IDepartmentRepository
    {
        #region Public Methods

        Task<IEnumerable<PerformanceReviewsReadDto>> GetAllAsync();
        Task<IEnumerable<DropDown>> GetDropdownAsync();

        #endregion Public Methods
    }
}
