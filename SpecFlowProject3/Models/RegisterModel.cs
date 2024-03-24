using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject3.Models
{
    internal class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  RegistrationRequest_CompanyName { get; set; }
        public string   RegistrationRequest_EmailAddress { get; set; }
        public string? RegistrationRequest_TelephoneNumber { get; set; }
        public string? RegistrationRequest_Comments { get; set; }
    }
}
