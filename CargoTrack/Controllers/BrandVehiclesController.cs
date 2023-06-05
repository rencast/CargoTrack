using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;
using Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace server.CargoTrack.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BrandVehiclesController:ControllerBase
{
    private readonly IBrandVehicleService _brandVehicleService;
    private readonly IMapper _mapper;
    
    public BrandVehiclesController(IBrandVehicleService brandVehicleService, IMapper mapper)
    {
        _brandVehicleService = brandVehicleService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<BrandVehicleResource>> GetAllAsync()
    {
        var brandVehicles = await _brandVehicleService.ListAsync();
        var resources = _mapper.Map<IEnumerable<BrandVehicle>, IEnumerable<BrandVehicleResource>>(brandVehicles);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("BrandVehicle Information to Add", Required = true)] SaveBrandVehicleResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveBrandVehicleResource, BrandVehicle>(resource);

        var result = await _brandVehicleService.SaveAsync(brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<BrandVehicle, BrandVehicleResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBrandVehicleResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var brandVehicle = _mapper.Map<SaveBrandVehicleResource, BrandVehicle>(resource);

        var result = await _brandVehicleService.UpdateAsync(id, brandVehicle);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<BrandVehicle, BrandVehicleResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _brandVehicleService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var brandVehicleResource = _mapper.Map<BrandVehicle, BrandVehicleResource>(result.Resource);

        return Ok(brandVehicleResource);
    }
    
    
}