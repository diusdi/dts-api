using API.Contracts;
using API.DTOs.AccountRoles;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountRoleController : ControllerBase
{
    private readonly IAccountRoleRepository _accountRoleRepository;

    public AccountRoleController(IAccountRoleRepository accountRoleRepository)
    {
        _accountRoleRepository = accountRoleRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _accountRoleRepository.GetAll();
        if (!result.Any())
        {
            return NotFound("Data Not Found");
        }

        var data = result.Select(x => (AccountRoleDto)x);
        return Ok(data);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _accountRoleRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("Id Not Found");
        }
        return Ok((AccountRoleDto)result);
    }

    [HttpPost]
    public IActionResult Create(CreateAccountRoleDto accountRoleDto)
    {
        var result = _accountRoleRepository.Create(accountRoleDto);
        if (result is null)
        {
            return BadRequest("Failed to create data");
        }

        return Ok((AccountRoleDto)result);
    }

    [HttpPut]
    public IActionResult Update(AccountRoleDto accountRoleDto)
    {
        var entitiy = _accountRoleRepository.GetByGuid(accountRoleDto.Guid);

        if (entitiy is null)
        {
            return NotFound("Id Not Found");
        }

        AccountRole toUpdate = accountRoleDto;
        toUpdate.CreatedDate = entitiy.CreatedDate;

        var result = _accountRoleRepository.Update(toUpdate);

        if (!result)
        {
            return BadRequest("Failed to update data");
        }

        return Ok("Data Updated");
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var entity = _accountRoleRepository.GetByGuid(guid);
        if (entity is null)
        {
            return NotFound("Id Not Found");
        }

        var result = _accountRoleRepository.Delete(entity);
        if (!result)
        {
            return BadRequest("Failed to delete data");
        }

        return Ok("Data Deleted");
    }
}
