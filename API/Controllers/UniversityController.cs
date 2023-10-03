﻿using API.Contracts;
using API.DTOs.Universities;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UniversityController : ControllerBase
{
    private readonly IUniversityRepository _universityRepository;

    public UniversityController(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _universityRepository.GetAll();
        if (!result.Any())
        {
            return NotFound("Data Not Found");
        }

        var data = result.Select(x => (UniversityDto)x);
        return Ok(data);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _universityRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("Id Not Found");
        }
        return Ok((UniversityDto)result);
    }

    [HttpPost]
    public IActionResult Create(CreateUniversityDto universityDto)
    {
        var result = _universityRepository.Create(universityDto);
        if (result is null)
        {
            return BadRequest("Failed to create data");
        }

        return Ok((UniversityDto)result);
    }

    [HttpPut]
    public IActionResult Update(UniversityDto universityDto)
    {
        var entitiy = _universityRepository.GetByGuid(universityDto.Guid);

        if (entitiy is null)
        {
            return NotFound("Id Not Found");
        }

        University toUpdate = universityDto;
        toUpdate.CreatedDate = entitiy.CreatedDate;

        var result = _universityRepository.Update(toUpdate);

        if (!result)
        {
            return BadRequest("Failed to update data");
        }

        return Ok("Data Updated");
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var entity = _universityRepository.GetByGuid(guid);
        if (entity is null)
        {
            return NotFound("Id Not Found");
        }

        var result = _universityRepository.Delete(entity);
        if (!result)
        {
            return BadRequest("Failed to delete data");
        }

        return Ok("Data Deleted");
    }
}
