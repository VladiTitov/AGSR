namespace MaternityHospital.Api.Features.Patients.Commands.Create;

public class CreatePatientCommandHandler
    : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IPatientContext _context;
    public CreatePatientCommandHandler(
        IMapper mapper,
        IPatientContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Guid> Handle(
        CreatePatientCommand request, 
        CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Patient>(request);
        await _context.Patients.InsertOneAsync(
            document: item,
            options: null,
            cancellationToken: cancellationToken);

        return item.Id;
    }
}
