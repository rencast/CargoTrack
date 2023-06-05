using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.CargoTrack.App.Domain.Repository;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;
using Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace server.CargoTrack.Controllers;

[Route("/api/v1/[controller]")]
public class CouriersController: ControllerBase
{
    private readonly ICourierService _courierService;
    private readonly IMapper _mapper;

    private readonly IPersonRepository _personRepository;
    public CouriersController(ICourierService courierService, IMapper mapper)
    {
        _courierService = courierService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CourierResource>> GetAllAsync()
    {
        var couriers = await _courierService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Courier>, IEnumerable<CourierResource>>(couriers);

        return resources;
    }

    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Post a Courier for given Category",
        Description = "Process to create courier:Select an existing Id in Persons. Late, in Courier put the Id in personId. ",
        OperationId = "PostCourier",
        Tags = new[] { "Couriers"}
    )]
    public async Task<IActionResult> PostAsync([FromBody] SaveCourierResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var courier = _mapper.Map<SaveCourierResource, Courier>(resource);
        
        var result = await _courierService.SaveAsync(courier);

        if (!result.Success)
            return BadRequest(result.Message);

        var courierResource = _mapper.Map<Courier, CourierResource>(result.Resource);

        return Ok(courierResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCourierResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var courier = _mapper.Map<SaveCourierResource, Courier>(resource);

        var result = await _courierService.UpdateAsync(id, courier);

        if (!result.Success)
            return BadRequest(result.Message);

        var courierResource = _mapper.Map<Courier, CourierResource>(result.Resource);

        return Ok(courierResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _courierService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var courierResource = _mapper.Map<Courier, CourierResource>(result.Resource);

        return Ok(courierResource);
    }
}