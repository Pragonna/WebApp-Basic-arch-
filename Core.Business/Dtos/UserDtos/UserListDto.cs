
using Core.Domain.Enums;

namespace Core.Business.Dtos.UserDtos
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public IList<string> Roles { get; set; }
        public UserListDto()
        {
            Roles = new List<string>();
        }
    }
}
