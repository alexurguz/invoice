using System;
namespace Invoice.Core.DTOs
{
    public class UserDto
    {
        public UserDto()
        {
        }

        public int IdUser { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
