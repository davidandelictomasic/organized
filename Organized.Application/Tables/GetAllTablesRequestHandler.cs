using Organized.Application.Common.Model;
using Organized.Domain.Persistence.Common;

namespace Organized.Application.Tables
{
    public class CompanyTableResponse
    {
        public int Id { get; init; }
        public string CompanyName { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
    }

    public class GetAllTablesRequest
    {
    }

    public class GetAllTablesRequestHandler : RequestHandler<GetAllTablesRequest, List<CompanyTableResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTablesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task<Result<List<CompanyTableResponse>>> HandleRequest(GetAllTablesRequest request, Result<List<CompanyTableResponse>> result)
        {
            var tables = await _unitOfWork.CompanyTableRepository.GetAll();
            
            var response = tables.Select(t => new CompanyTableResponse
            {
                Id = t.Id,
                CompanyName = t.CompanyName,
                City = t.City
            }).ToList();

            result.SetResult(response);
            return result;
        }

        protected override Task<bool> IsActive()
        {
            return Task.FromResult(true);
        }
    }
}
