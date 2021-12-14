using System.Net;

namespace DiscountAPI.Core.Exceptions
{
    public class AppDbIntegrationException : ApiException
    {
        public AppDbIntegrationException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}