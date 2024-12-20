using Application.Common.BaseHandler;
using Application.Common.Models;
using Application.Departments.Queries;
using AutoMapper;
using Domain.Abstractions.Base;
using Domain.Dto.Common;
using MediatR;

namespace Application.Departments.Handlers
{
    public class DepartmentDropdownQueryHandler : BaseHandler, IRequestHandler<DepartmentDropdownQuery, ResponseDetail<List<DropDown>>>
    {
        #region Public Constructors

        public DepartmentDropdownQueryHandler(IRepositoryFacade unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<List<DropDown>>> Handle(DepartmentDropdownQuery request, CancellationToken cancellationToken)
        {
            var response = ApplicationFactory.CreateResponseDetails<List<DropDown>>();
            try
            {
                var dropdowns = await _repositoryFacade.DepartmentRepo.GetDropdownAsync();
                var dropdownList = dropdowns.ToList();
                return response.SuccessResponse(dropdownList);
            }
            catch (Exception ex)
            {
                return response.ErrorResponse(ex);
            }
        }

        #endregion Public Methods
    }
}
