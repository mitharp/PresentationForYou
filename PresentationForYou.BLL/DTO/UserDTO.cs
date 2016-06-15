using System;

namespace PresentationForYou.BLL.DTO
{
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }        
    }
}
