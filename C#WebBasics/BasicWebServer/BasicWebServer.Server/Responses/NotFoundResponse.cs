using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.Enums;

namespace BasicWebServer.Server.Responses
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse()
            : base(StatusCode.NotFound)
        {
        }
    }
}
