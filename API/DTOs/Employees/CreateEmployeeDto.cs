using API.Models;

namespace API.DTOs.Employees;

public class CreateEmployeeDto
{
    public Guid Guid { get; set; }
    public string Nik { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender GenderE { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }


    public static implicit operator Employee(CreateEmployeeDto employeeDto)
    {
        return new Employee
        {
            Guid = employeeDto.Guid,
            Nik = employeeDto.Nik,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            BirthDate = employeeDto.BirthDate,
            Gender = (Models.Gender)employeeDto.GenderE,
            HiringDate = employeeDto.HiringDate,
            Email = employeeDto.Email,
            PhoneNumber = employeeDto.PhoneNumber,
            ModifiedDate = DateTime.Now
        };
    }

    public enum Gender
    {
        Female,
        Male
    }
}
