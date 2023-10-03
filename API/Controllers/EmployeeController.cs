using API.Contracts;
using API.DTOs.Employees;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _employeeRepository.GetAll();
        if (!result.Any())
        {
            return NotFound("Data Not Found");
        }

        var data = result.Select(x => (EmployeeDto)x);
        return Ok(data);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _employeeRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("Id Not Found");
        }
        return Ok((EmployeeDto)result);
    }

    [HttpPost]
    public IActionResult Create(CreateEmployeeDto employeeDto)
    {
        var result = _employeeRepository.Create(employeeDto);
        if (result is null)
        {
            return BadRequest("Failed to create data");
        }

        return Ok((EmployeeDto)result);
    }

    [HttpPut]
    public IActionResult Update(EmployeeDto employeeDto)
    {
        var entitiy = _employeeRepository.GetByGuid(employeeDto.Guid);

        if (entitiy is null)
        {
            return NotFound("Id Not Found");
        }

        Employee toUpdate = employeeDto;
        toUpdate.CreatedDate = entitiy.CreatedDate;

        var result = _employeeRepository.Update(toUpdate);

        if (!result)
        {
            return BadRequest("Failed to update data");
        }

        return Ok("Data Updated");
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var entity = _employeeRepository.GetByGuid(guid);
        if (entity is null)
        {
            return NotFound("Id Not Found");
        }

        var result = _employeeRepository.Delete(entity);
        if (!result)
        {
            return BadRequest("Failed to delete data");
        }

        return Ok("Data Deleted");
    }
}
