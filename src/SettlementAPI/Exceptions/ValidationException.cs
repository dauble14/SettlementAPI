using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Exceptions
{
    public class ValidationException : Exception
    {
        public string[] Errors { get; set; }
        public ValidationException(string message, string[] errors): base(message)
        {
            Errors=errors;
        }
    }
}
