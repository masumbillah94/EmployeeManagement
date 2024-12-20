using Application.Common.BaseHandler;
using Application.Common.Models;
using Application.PerformanceReviews.Commands;
using AutoMapper;
using Domain.Abstractions.Base;
using Domain.Dto.PerformanceReviews;
using Domain.Entities.EmployeePerformances;
using MediatR;

namespace Application.PerformanceReviews.Handlers
{
    public class PerformanceReviewAddCommandHandler : BaseHandler, IRequestHandler<PerformanceReviewAddCommand, ResponseDetail<PerformanceReviewReadDto>>
    {
        #region Public Constructors

        public PerformanceReviewAddCommandHandler(IRepositoryFacade unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<PerformanceReviewReadDto>> Handle(PerformanceReviewAddCommand request, CancellationToken cancellationToken)
        {
            var response = ApplicationFactory.CreateResponseDetails<PerformanceReviewReadDto>();
            try
            {
                var employee = _mapper.Map<PerformanceReview>(request);
                var result = await _repositoryFacade.PerformanceReviewRepo.AddEntity(employee);
                if (result != null)
                {
                    var employeeDto = _mapper.Map<PerformanceReviewReadDto>(employee);
                    response.SuccessResponse(employeeDto, "PerformanceReview added successfully");
                }
                else
                {
                    response.InvalidResponse("PerformanceReview Not Created");
                }
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
