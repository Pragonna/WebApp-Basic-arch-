using Core.Domain.Entities.Commons;
using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }

        public User()
        {
        }
        public User(
            int id,
            string firstName,
            string lastName,
            string email,
            byte[] passwordHash,
            byte[] passwordSalt,
            DateTime dateOfBirth,
            string address,
            Gender gender,
            string country)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            DateOfBirth = dateOfBirth;
            Address = address;
            Gender = gender;
            Country = country;
        }
    }
}
