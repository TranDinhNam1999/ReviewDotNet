using System.Net;

namespace ServiceAPI.Common.Types
{
    public class CommonException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public CommonException()
        {
        }

        public CommonException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public CommonException(string message, params object[] args)
            : this(null, message, args)
        {
        }

        public CommonException(HttpStatusCode code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public CommonException(Exception innerException, string message, params object[] args)
            : this(innerException, HttpStatusCode.InternalServerError, message, args)
        {
        }

        public CommonException(Exception innerException, HttpStatusCode statusCode, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            StatusCode = statusCode;
        }
    }
}
