using API.Models;

namespace API.DTOs.Rooms;

public class RoomDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }

    public static explicit operator RoomDto(Room Room)
    {
        return new RoomDto
        {
            Guid = Room.Guid,
            Name = Room.Name,
            Floor = Room.Floor,
            Capacity = Room.Capacity
        };
    }

    public static implicit operator Room(RoomDto RoomDto)
    {
        return new Room
        {
            Guid = RoomDto.Guid,
            Name = RoomDto.Name,
            Floor = RoomDto.Floor,
            Capacity = RoomDto.Capacity,
            ModifiedDate = DateTime.Now
        };
    }
}
