using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakalarska_prace.Models.Auth
{
    public class RegisterResponseDto
    {
        public bool Success { get; set; }
        public RegisterError Error { get; set; } = RegisterError.None;
    }
}
