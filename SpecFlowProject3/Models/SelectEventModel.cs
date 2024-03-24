using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject3.Models
{
    internal class SelectEventModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Organisation { get; set; }
        public string Message { get; set; }
        
    }
}
