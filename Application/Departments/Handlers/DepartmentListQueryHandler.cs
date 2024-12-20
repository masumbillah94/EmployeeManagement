using Application.Common.BaseHandler;
using Application.Common.Models;
using Application.Departments.Queries;
using AutoMapper;
using Domain.Abstractions.Base;
using Domain.Dto.Departments;
using MediatR;

namespace Application.Departments.Handlers
{
    public class DepartmentListQueryHandler : BaseHandler, IRequestHandler<DepartmentListQuery, ResponseDetail<List<PerformanceReviewsReadDto>>>
    {
        #region Public Constructors

        public DepartmentListQueryHandler(IRepositoryFacade repositoryFacade, IMapper mapper) : base(repositoryFacade, mapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<List<PerformanceReviewsReadDto>>> Handle(DepartmentListQuery request, CancellationToken cancellationToken)
        {
            var response = ApplicationFactory.CreateResponseDetails<List<PerformanceReviewsReadDto>>();
            try
            {
                return response;
            }
            catch (Exception ex)
            {
                return response.ErrorResponse(ex);
            }
        }

        #endregion Public Methods
    }
}
