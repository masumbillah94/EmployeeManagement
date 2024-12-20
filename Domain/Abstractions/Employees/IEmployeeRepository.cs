using Domain.Dto.Employees;
using Domain.Entities.Employees;

namespace Domain.Abstractions.Employees
{
    public interface IEmployeeRepository
    {
        #region Public Methods

        Task<Employee> AddEntity(Employee entity);
        Task<IEnumerable<EmployeeListDto>> GetAllAsync(string? employeeName, int? departmentId, string? position, int? minPerformanceScore, int? maxPerformanceScore, int pageNumber = 1, int pageSize = 10);
        Task<EmployeeReadDto> GetByIdAsync(long Id);
        Task<Employee> UpdateEntity(Employee entity);
        Task<int> DeleteByIdAsync(long id);

        #endregion Public Methods
    }
}
