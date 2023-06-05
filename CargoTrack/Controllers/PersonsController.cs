using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;
using Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;


namespace server.CargoTrack.Controllers;

[Route("/api/v1/[controller]")]
public class PersonsController:ControllerBase
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;


    public PersonsController(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<PersonResource>> GetAllAsync()
    {
        var person = await _personService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonResource>>(person);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("Person Information to Add", Required = true)] SavePersonResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var person = _mapper.Map<SavePersonResource, Person>(resource);

        var result = await _personService.SaveAsync(person);

        if (!result.Success)
            return BadRequest(result.Message);

        var personResource = _mapper.Map<Person, PersonResource>(result.Resource);

        return Ok(personResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePersonResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var person = _mapper.Map<SavePersonResource, Person>(resource);

        var result = await _personService.UpdateAsync(id, person);

        if (!result.Success)
            return BadRequest(result.Message);

        var personResource = _mapper.Map<Person, PersonResource>(result.Resource);

        return Ok(personResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _personService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var personResource = _mapper.Map<Person, PersonResource>(result.Resource);

        return Ok(personResource);
    }
}