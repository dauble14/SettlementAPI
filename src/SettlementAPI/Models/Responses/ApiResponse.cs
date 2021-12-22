using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementAPI.Models.Responses
{
    public class ApiResponse : ApiBaseResponse
    {
        public ApiResponse(string message)
        {
            IsSuccess = true;
            Message = message;
        }

        public ApiResponse()
        {
            IsSuccess = true;
        }
    }

    public class ApiResponse<T>: ApiBaseResponse
    {
        public T Value { get; set; }

        public ApiResponse()
        {
            IsSuccess= true;
        }

        public ApiResponse(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        public ApiResponse(T value, string message)
        {
            IsSuccess = true;
            Value= value;   
            Message = message;
        }
    }

    public class ApiBaseResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
