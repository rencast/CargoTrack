using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;
using Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace server.CargoTrack.Controllers;

[Route("/api/v1/[controller]")]
public class UserRequestController:ControllerBase
{
    
    private readonly IUserRequestService _userRequestService;
    private readonly IMapper _mapper;


    public UserRequestController(IUserRequestService userRequestService, IMapper mapper)
    {
        _userRequestService = userRequestService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<UserRequestResource>> GetAllAsync()
    {
        var userRequest = await _userRequestService.ListAsync();
        var resources = _mapper.Map<IEnumerable<UserRequest>, IEnumerable<UserRequestResource>>(userRequest);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("UserRequest Information to Add", Required = true)] SaveUserRequestResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var userRequest = _mapper.Map<SaveUserRequestResource, UserRequest>(resource);

        var result = await _userRequestService.SaveAsync(userRequest);

        if (!result.Success)
            return BadRequest(result.Message);

        var userRequestResource = _mapper.Map<UserRequest, UserRequestResource>(result.Resource);

        return Ok(userRequestResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserRequestResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var userRequest = _mapper.Map<SaveUserRequestResource, UserRequest>(resource);

        var result = await _userRequestService.UpdateAsync(id, userRequest);

        if (!result.Success)
            return BadRequest(result.Message);

        var userRequestResource = _mapper.Map<UserRequest, UserRequestResource>(result.Resource);

        return Ok(userRequestResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userRequestService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var userRequestResource = _mapper.Map<UserRequest, UserRequestResource>(result.Resource);

        return Ok(userRequestResource);
    }
}