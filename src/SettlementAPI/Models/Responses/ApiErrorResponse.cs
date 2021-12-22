using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Models.Responses
{
    public class ApiErrorResponse
    {
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public bool IsSuccess { get; set; }

        public ApiErrorResponse()
        {
        }

        public ApiErrorResponse(string message)
        {
            Message = message;
            IsSuccess = false;
        }

        public ApiErrorResponse(string message, string[] errors)
        {
            Message = message;
            IsSuccess = false;
            Errors = errors;
        }
    }
}
