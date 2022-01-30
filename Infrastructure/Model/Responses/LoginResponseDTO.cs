using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.DataContracts.Responses
{
    public class LoginResponseDTO : Response
    {
        public bool Success { get; set; }
        public User User { get; set; }
    }
}
