using Data.SqlServer.AppContext;
using Domain.Abstractions.PerformanceReviews;
using Domain.Entities.EmployeePerformances;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Repository.PerformanceReviewRepositories
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository

    {
        private readonly AppDbContext _context;

        public PerformanceReviewRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<PerformanceReview> AddEntity(PerformanceReview entity)
        {
            var rivewIdParam = new SqlParameter("@PerformanceReviewId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            var parameters = new[]
                {
                    new SqlParameter("@EmployeeId", entity.EmployeeId),
                    new SqlParameter("@ReviewScore", entity.ReviewScore),
                    new SqlParameter("@ReviewNote", entity.ReviewNote),
                    rivewIdParam
                };

            await _context.Database.ExecuteSqlRawAsync("EXEC InsertPerformanceReview @EmployeeId, @ReviewScore, @ReviewNote @PerformanceReviewId OUT", parameters);
            entity.Id = (long)rivewIdParam.Value;
            return entity;
        }

    }
}
