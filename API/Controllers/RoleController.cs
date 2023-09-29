﻿using API.Contracts;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _roleRepository;

    public RoleController(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _roleRepository.GetAll();
        if (!result.Any())
        {
            return NotFound("Data Not Found");
        }

        return Ok(result);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _roleRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("Id Not Found");
        }
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(Role role)
    {
        var result = _roleRepository.Create(role);
        if (result is null)
        {
            return BadRequest("Failed to create data");
        }

        return Ok(result);
    }

    [HttpPut]
    public IActionResult Update(Role role)
    {
        var result = _roleRepository.Update(role);
        if (!result)
        {
            return BadRequest("Failed to update data");
        }

        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(Role role)
    {
        var result = _roleRepository.Delete(role);
        if (!result)
        {
            return BadRequest("Failed to delete data");
        }

        return Ok(result);
    }
}
