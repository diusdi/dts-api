using API.Models;
using API.Utilities.Handlers;

namespace API.DTOs.Accounts
{
    public class CreateAccountDto
    {
        public Guid Guid { get; set; }
        public string Password { get; set; }
        public int Otp { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }

        public static implicit operator Account(CreateAccountDto createAccountDto)
        {
            string hashedPassword = HasingHandler.HashPassword(createAccountDto.Password);

            return new Account
            {
                Guid = createAccountDto.Guid,
                Password = hashedPassword,
                Otp = createAccountDto.Otp,
                IsUsed = createAccountDto.IsUsed,
                ExpiredTime = createAccountDto.ExpiredTime,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
