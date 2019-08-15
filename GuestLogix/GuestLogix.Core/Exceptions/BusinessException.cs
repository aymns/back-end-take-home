using System;

namespace GuestLogix.Core.Exceptions
{
    public class BusinessException:Exception
    {
        public int ErrorCode { get; private set; }
        public BusinessException(string message, int errorCode):base(message)
        {
            this.ErrorCode = errorCode;
        }

        public static BusinessException NO_ROUTE = new BusinessException("No Route", 1000);
        public static BusinessException INVALID_ORIGIN = new BusinessException("Invalid Origin", 1001);
        public static BusinessException INVALID_DESTINATION = new BusinessException("Invalid Destination", 1002);

    }
}