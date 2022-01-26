using System;
using System.Collections.Generic;
using System.Linq;
using BasicWebServer.Server.HTTP.Enums;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split(Environment.NewLine);//"\r\n"
            var startLine = lines.First().Split(" ");
            var method = ParseMethod(startLine[0]);
            var url = startLine[1];
            var headers = ParseHeaders(lines.Skip(1));
            var bodyLines = lines.Skip(headers.Count + 2);
            var body = string.Join(Environment.NewLine,)
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> enumerable)
        {
            throw new NotImplementedException();
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<Method>(method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method {method} is not supported");
            }
        }
    }
}
