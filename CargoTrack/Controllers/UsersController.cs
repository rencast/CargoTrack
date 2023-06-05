﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.CargoTrack.Domain.Core;
using server.CargoTrack.Domain.Models;
using server.CargoTrack.Resources;
using Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;


namespace server.CargoTrack.Controllers;

[Route("/api/v1/[controller]")]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var user = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(user);

        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody, SwaggerRequestBody("User Information to Add", Required = true)] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveUserResource, User>(resource);

        var result = await _userService.SaveAsync(user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }
    
    
}