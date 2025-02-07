using MongoDB.Driver;

namespace MaternityHospital.Api.Features.Patients.Commands.Delete;

public class DeletePatientCommandHandler 
    : IRequestHandler<DeletePatientCommand, bool>
{
    private readonly IPatientContext _context;

    public DeletePatientCommandHandler(
        IPatientContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        DeletePatientCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _context.Patients
            .DeleteOneAsync(
                filter: Builders<Patient>.Filter.Eq(i => i.Id, request.Id),
                cancellationToken: cancellationToken);

        return result.IsAcknowledged
            && result.DeletedCount > 0;
    }
}
