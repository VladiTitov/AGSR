using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MaternityHospital.Api.Features.Patients.Queries.GetAll;

public class GetAllQueryHandler 
    : IRequestHandler<GetAllQuery, List<Patient>>
{
    private readonly IPatientContext _context;

    public GetAllQueryHandler(IPatientContext context)
    {
        _context = context;
    }

    public Task<List<Patient>> Handle(
        GetAllQuery request, 
        CancellationToken cancellationToken)
        => _context.Patients
            .AsQueryable()
            .Skip(request.Filter.GetSkipCount())
            .Take(request.Filter.PageSize)
            .ToListAsync(cancellationToken);
}
