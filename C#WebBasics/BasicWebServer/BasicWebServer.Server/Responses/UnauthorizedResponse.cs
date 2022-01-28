using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.Enums;

namespace BasicWebServer.Server.Responses
{
    public class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() 
            : base(StatusCode.Unauthorized)
        {
        }
    }
}
