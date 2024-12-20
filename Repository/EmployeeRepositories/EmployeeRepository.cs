using Data.SqlServer.AppContext;
using Domain.Abstractions.Employees;
using Domain.Dto.Employees;
using Domain.Entities.Employees;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Repository.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository

    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Employee> AddEntity(Employee entity)
        {
            var employeeIdParam = new SqlParameter("@EmployeeId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            var parameters = new[]
                {
                    new SqlParameter("@Name", entity.Name),
                    new SqlParameter("@Email", entity.Email),
                    new SqlParameter("@Phone", entity.Phone),
                    new SqlParameter("@Gender", entity.Gender),
                    new SqlParameter("@DepartmentId", entity.DepartmentId),
                    new SqlParameter("@Status", entity.Status),
                    new SqlParameter("@Position", entity.Position),
                    new SqlParameter("@JoiningDate", entity.JoiningDate),
                    employeeIdParam
                };

            await _context.Database.ExecuteSqlRawAsync("EXEC InsertEmployee @Name, @Email, @Phone, @Gender, @Position, @DepartmentId, @Status, @JoiningDate, @EmployeeId OUT", parameters);
            entity.Id = (long)employeeIdParam.Value;
            return entity;
        }


        public async Task<IEnumerable<EmployeeListDto>> GetAllAsync(string? employeeName, int? departmentId, string? position, int? minPerformanceScore, int? maxPerformanceScore, int pageNumber, int pageSize)
        {
            var query = "EXEC SearchEmployees @EmployeeName, @DepartmentId, @Position, @MinPerformanceScore, @MaxPerformanceScore, @PageNumber, @PageSize";
            var parameters = new[]
                {
                    new SqlParameter("@EmployeeName", SqlDbType.NVarChar) { Value =((object)employeeName==null) ? DBNull.Value: employeeName },
                    new SqlParameter("@DepartmentId", SqlDbType.Int) { Value = (departmentId==null) ? DBNull.Value: departmentId },
                    new SqlParameter("@Position", SqlDbType.NVarChar) { Value = ((object)position==null) ? DBNull.Value: position },
                    new SqlParameter("@MinPerformanceScore", SqlDbType.Int) { Value = (minPerformanceScore==null) ? DBNull.Value: minPerformanceScore},
                    new SqlParameter("@MaxPerformanceScore", SqlDbType.Int) { Value = (maxPerformanceScore==null) ? DBNull.Value: maxPerformanceScore},
                    new SqlParameter("@PageNumber", SqlDbType.Int) { Value = pageNumber },
                    new SqlParameter("@PageSize", SqlDbType.Int) { Value = pageSize }
                };
            var employees = await _context.Database.SqlQueryRaw<EmployeeListDto>(query, parameters).ToListAsync();
            return employees;
        }

        public async Task<EmployeeReadDto> GetByIdAsync(long Id)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeId", Id)
            };

            var employee = await _context.Database.SqlQueryRaw<EmployeeReadDto>("EXEC GetEmployeeById @EmployeeId", parameters)
                            .ToListAsync();
            return employee.FirstOrDefault()!;
        }

        public async Task<Employee> UpdateEntity(Employee entity)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeId", entity.Id),
                new SqlParameter("@Name", entity.Name),
                new SqlParameter("@Email", entity.Email),
                new SqlParameter("@Phone", entity.Phone),
                new SqlParameter("@Gender", entity.Gender),
                new SqlParameter("@DepartmentId", entity.DepartmentId),
                new SqlParameter("@Status", entity.Status),
                new SqlParameter("@Position", entity.Position),
                new SqlParameter("@JoiningDate", entity.JoiningDate)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateEmployee @EmployeeId, @Name, @Email, @Phone, @Gender, @DepartmentId, @Status, @Position, @JoiningDate", parameters);
            return entity;

        }
        public async Task<int> DeleteByIdAsync(long id)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeId", id)
            };

            var result = await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmployee @EmployeeId", parameters);
            return result;
        }
    }
}
