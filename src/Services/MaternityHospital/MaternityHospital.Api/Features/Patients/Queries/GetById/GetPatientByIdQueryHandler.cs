using MongoDB.Driver;

namespace MaternityHospital.Api.Features.Patients.Queries.GetById;

public class GetPatientByIdQueryHandler 
    : IRequestHandler<GetPatientByIdQuery, Patient>
{
    private readonly IMapper _mapper;
    private readonly IPatientContext _context;

    public GetPatientByIdQueryHandler(
        IMapper mapper,
        IPatientContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Patient> Handle(
        GetPatientByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var item = await _context.Patients
            .Find(
                filter: Builders<Patient>.Filter.Eq(i => i.Id, request.Id))
            .FirstOrDefaultAsync(cancellationToken);

        return _mapper.Map<Patient>(item);
    }
}
