using MaternityHospital.Api.Features.Patients.Commands.Create;
using MaternityHospital.Api.Features.Patients.Commands.Delete;
using MaternityHospital.Api.Features.Patients.Commands.Update;
using MaternityHospital.Api.Features.Patients.Queries.GetAll;
using MaternityHospital.Api.Features.Patients.Queries.GetByFilter;
using MaternityHospital.Api.Features.Patients.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MaternityHospital.Api.Controllers;

/// <summary>
/// PatientController
/// </summary>
[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// PatientController constructor
    /// </summary>
    /// <param name="mediator"></param>
    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get patients
    /// </summary>
    /// /// <remarks>
    /// Sample request:
    ///
    ///     GET api/patients/
    ///
    /// </remarks>
    /// <response code="200">Return patients</response>
    /// <response code="204">No Content</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<List<Patient>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPatientsAsync(
        [FromQuery] PatientRequest request,
        CancellationToken cancellationToken = default)
    {
        var data = request.BirthDate is null || !request.BirthDate.Any()
            ? await _mediator.Send(
                new GetAllQuery(new PaginationFilter(request)),
                cancellationToken)
            : await _mediator.Send(
                new GetByFilterQuery(new PatientFilter(request)),
                cancellationToken);

        return data is null || !data.Any()
            ? NoContent()
            : Ok(
                value: new PagedResponse<List<Patient>>(
                    data, (int)request.Page, (int)request.Size));
    }

    /// <summary>
    /// Get patient by Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/patients/0aa00a00-0000-0000-a0aa-0a000a00aaa0
    ///
    /// </remarks>
    /// <response code="200">Return patient</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

    /// <summary>
    /// Add new patient
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/patients
    ///     {
    ///         "name": {
    ///             "use": "official",
    ///             "family": "Иванов",
    ///             "given": [
    ///                 "Иван",
    ///                 "Иванович"
    ///             ]
    ///         },
    ///         "gender": "male",
    ///         "birthDate": "2024-01-13T18:25:43",
    ///         "active": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Return patient Id</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IResult> CreatePatientAsync(
        [FromBody, Required] CreatePatientCommand command,
        CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return Results.Created($"{Request.Path}/{id}", id);
    }

    /// <summary>
    /// Update patient
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT api/patients
    ///     {
    ///         "id": 0aa00a00-0000-0000-a0aa-0a000a00aaa0,
    ///         "name": {
    ///             "use": "official",
    ///             "family": "Иванов",
    ///             "given": [
    ///                 "Иван",
    ///                 "Иванович"
    ///             ]
    ///         },
    ///         "gender": "male",
    ///         "birthDate": "2024-01-13T18:25:43",
    ///         "active": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPut]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IResult> UpdatePatient(
        [FromBody, Required] UpdatePatientCommand command,
        CancellationToken cancellationToken = default)
    {
        bool status = await _mediator.Send(command, cancellationToken);
        return status 
            ? Results.Created($"{Request.Path}/{command.Id}", command.Id) 
            : Results.BadRequest();
    }

    /// <summary>
    /// Delete patient
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/patients/0aa00a00-0000-0000-a0aa-0a000a00aaa0
    ///
    /// </remarks>
    /// <response code="204">Success</response>
    /// <response code="404">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
