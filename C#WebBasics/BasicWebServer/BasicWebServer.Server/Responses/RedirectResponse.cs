using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.Enums;

namespace BasicWebServer.Server.Responses
{
    public class RedirectResponse : Response
    {
        public RedirectResponse(string location)
            : base(StatusCode.Found)
        {
            Headers.Add(Header.Location, location);
        }
    }
}
