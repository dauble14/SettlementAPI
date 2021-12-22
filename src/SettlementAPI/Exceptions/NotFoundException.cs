using System;

namespace SettlementAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message): base(message)
        {

        }
    }
}
