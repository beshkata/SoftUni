using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.Enums;

namespace BasicWebServer.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
            : base(StatusCode.BadRequest)
        {
        }
    }
}
