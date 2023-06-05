
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;
using Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace server.CargoTrack.Controllers;

[Route("/api/v1/[controller]")]
public class LicensesController:ControllerBase
{
    private readonly ILicenseService _licenseService;
    private readonly IMapper _mapper;
    
    public LicensesController(ILicenseService licenseService, IMapper mapper)
    {
        _licenseService = licenseService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<LicenseResource>> GetAllAsync()
    {
        var license = await _licenseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<License>, IEnumerable<LicenseResource>>(license);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("License Information to Add", Required = true)] SaveLicenseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var license = _mapper.Map<SaveLicenseResource, License>(resource);

        var result = await _licenseService.SaveAsync(license);

        if (!result.Success)
            return BadRequest(result.Message);

        var licenseResource = _mapper.Map<License, LicenseResource>(result.Resource);

        return Ok(licenseResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLicenseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var license = _mapper.Map<SaveLicenseResource, License>(resource);

        var result = await _licenseService.UpdateAsync(id, license);

        if (!result.Success)
            return BadRequest(result.Message);

        var licenseResource = _mapper.Map<License, LicenseResource>(result.Resource);

        return Ok(licenseResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _licenseService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var licenseResource = _mapper.Map<License, LicenseResource>(result.Resource);

        return Ok(licenseResource);
    }
}