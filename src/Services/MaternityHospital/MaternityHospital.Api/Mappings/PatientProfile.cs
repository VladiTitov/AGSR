using MaternityHospital.Api.Features.Patients.Commands.Create;

namespace MaternityHospital.Api.Mappings;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<CreatePatientCommand, Patient>().ReverseMap();
    }
}
