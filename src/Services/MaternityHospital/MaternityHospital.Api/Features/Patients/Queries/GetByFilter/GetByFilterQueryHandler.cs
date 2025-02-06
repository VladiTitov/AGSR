using MaternityHospital.Api.Infrastructure.Extensions;
using MongoDB.Driver;

namespace MaternityHospital.Api.Features.Patients.Queries.GetByFilter;

public class GetByFilterQueryHandler 
    : IRequestHandler<GetByFilterQuery, List<Patient>>
{
    private readonly IPatientContext _context;

    public GetByFilterQueryHandler(IPatientContext context)
    {
        _context = context;
    }

    public Task<List<Patient>> Handle(
        GetByFilterQuery request, 
        CancellationToken cancellationToken)
        => _context.Patients
            .Find(GetFilterDefinition(request.Filter))
            .Skip(request.Filter.GetSkipCount())
            .Limit(request.Filter.PageSize)
            .ToListAsync(cancellationToken);

    private FilterDefinition<Patient> GetFilterDefinition(PatientFilter filter)
    {
        var queryFilterBuilder = Builders<Patient>.Filter;
        var queryFilters = new List<FilterDefinition<Patient>>();

        if (filter.BirthDate != null && filter.BirthDate.Any())
        {
            foreach (var f in filter.BirthDate)
            {
                queryFilters.Add(f.IsDateOnly()
                    ? queryFilterBuilder.GetFhirDateOnlyFilterDefinition(f => f.BirthDate, f)
                    : queryFilterBuilder.GetFhirFilterDefinition(f => f.BirthDate, f));
            }
        }
            
        return queryFilterBuilder.And(queryFilters);
    }
}
