using Data.SqlServer.AppContext;
using Domain.Abstractions.Departments;
using Domain.Dto.Common;
using Domain.Dto.Departments;
using Microsoft.EntityFrameworkCore;

namespace Repository.DepartmentRepositories
{
    public class DepartmentRepository : IDepartmentRepository

    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PerformanceReviewsReadDto>> GetAllAsync()
        {
            var query = "EXEC GetDepartments";
            var departmentList = await _context.Database.SqlQueryRaw<PerformanceReviewsReadDto>(query).ToListAsync();
            return departmentList;
        }

        public async Task<IEnumerable<DropDown>> GetDropdownAsync()
        {
            var query = "EXEC GetDepartmentDropdowns";
            var departmentList = await _context.Database.SqlQueryRaw<DropDown>(query).ToListAsync();
            return departmentList;
        }
    }
}
