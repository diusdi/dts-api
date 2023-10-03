﻿using API.Contracts;
using API.DTOs.Rooms;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomRepository _roomRepository;

    public RoomController(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _roomRepository.GetAll();
        if (!result.Any())
        {
            return NotFound("Data Not Found");
        }

        var data = result.Select(x => (RoomDto)x);
        return Ok(data);
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _roomRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("Id Not Found");
        }
        return Ok((RoomDto)result);
    }

    [HttpPost]
    public IActionResult Create(CreateRoomDto RoomDto)
    {
        var result = _roomRepository.Create(RoomDto);
        if (result is null)
        {
            return BadRequest("Failed to create data");
        }

        return Ok((RoomDto)result);
    }

    [HttpPut]
    public IActionResult Update(RoomDto roomDto)
    {
        var entitiy = _roomRepository.GetByGuid(roomDto.Guid);

        if (entitiy is null)
        {
            return NotFound("Id Not Found");
        }

        Room toUpdate = roomDto;
        toUpdate.CreatedDate = entitiy.CreatedDate;

        var result = _roomRepository.Update(toUpdate);

        if (!result)
        {
            return BadRequest("Failed to update data");
        }

        return Ok("Data Updated");
    }

    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var entity = _roomRepository.GetByGuid(guid);
        if (entity is null)
        {
            return NotFound("Id Not Found");
        }

        var result = _roomRepository.Delete(entity);
        if (!result)
        {
            return BadRequest("Failed to delete data");
        }

        return Ok("Data Deleted");
    }
}
