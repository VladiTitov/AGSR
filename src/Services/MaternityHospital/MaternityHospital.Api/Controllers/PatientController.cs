using MaternityHospital.Api.Features.Patients.Commands.Create;
using MaternityHospital.Api.Features.Patients.Commands.Delete;
using MaternityHospital.Api.Features.Patients.Commands.Update;
using MaternityHospital.Api.Features.Patients.Queries.GetAll;
using MaternityHospital.Api.Features.Patients.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MaternityHospital.Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IResult> GetPatientsAsync(
        [FromQuery] PaginationRequest request,
        CancellationToken cancellationToken = default)
    {
        var validFilter = new PaginationFilter(
            pageNumber: request.Page,
            pageSize: request.Size);

        var data = await _mediator.Send(
            request: new GetAllQuery(validFilter),
            cancellationToken: cancellationToken);

        return data is null || !data.Any()
            ? Results.NoContent()
            : Results.Ok(
                value: new PagedResponse<List<Patient>>(data, validFilter.PageNumber, validFilter.PageSize));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IResult> GetPatientAsync(
        [FromRoute, Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        var responce = await _mediator.Send(
            request: new GetPatientByIdQuery(id), 
            cancellationToken: cancellationToken);

        return responce != null 
            ? Results.Ok(responce) 
            : Results.NoContent();
    }

    [HttpPost]
    public async Task<IResult> CreatePatientAsync(
        [FromBody, Required] CreatePatientCommand command,
        CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Results.Created($"{Request.Path}/{id}", id);
    }

    [HttpPut]
    public async Task<IResult> UpdatePatient(
        [FromBody, Required] UpdatePatientCommand command,
        CancellationToken cancellationToken = default)
    {
        bool status = await _mediator.Send(command, cancellationToken);
        return status ? Results.CreatedAtRoute() : Results.BadRequest();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IResult> DeletePatient(
        [FromRoute, Required] Guid id,
        CancellationToken cancellationToken = default)
    {
        bool status = await _mediator.Send(
            request: new DeletePatientCommand(id),
            cancellationToken: cancellationToken);
        
        return status ? Results.NoContent() : Results.NotFound();
    }
}
