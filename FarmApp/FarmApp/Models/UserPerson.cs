using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Models
{
	public class UserPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public int IdDocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public int IdTown { get; set; }
    }
}
