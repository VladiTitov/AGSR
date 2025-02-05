using MongoDB.Driver;

namespace MaternityHospital.Api.Features.Patients.Commands.Update;

public class UpdatePatientCommandHandler
    : IRequestHandler<UpdatePatientCommand, bool>
{
    private readonly IPatientContext _context;

    public UpdatePatientCommandHandler(IPatientContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        UpdatePatientCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _context.Patients
            .UpdateManyAsync(
                filter: Builders<Patient>.Filter.Eq(i => i.Id, request.Id),
                update: Builders<Patient>.Update
                    .Set(i => i.Name, request.Name)
                    .Set(i => i.Gender, request.Gender)
                    .Set(i => i.BirthDate, request.BirthDate)
                    .Set(i => i.Active, request.Active),
                cancellationToken: cancellationToken);

        return result.IsAcknowledged
            && result.ModifiedCount > 0;
    }
}
