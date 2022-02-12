﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicWebServer.Server.HTTP.Enums;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        private static Dictionary<string, Session> Sessions = new();

        public Request()
        {

        }

        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public string Body { get; private set; }

        public Session Session { get; private set; }
        public Dictionary<string, string> Form { get; private set; } = new Dictionary<string, string>();

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");//"\r\n"
            var startLine = lines.First().Split(" ");
            var method = ParseMethod(startLine[0]);
            var url = startLine[1];
            var headers = ParseHeaders(lines.Skip(1));
            var cookies = ParseCookies(headers);
            var session = GetSession(cookies);
            var bodyLines = lines.Skip(headers.Count + 2);
            var body = string.Join("\r\n", bodyLines);
            var form = ParseForm(headers, body);

            return new Request
            {
                Method = method,
                Url = url,
                Headers = headers,
                Cookies = cookies,
                Body = body,
                Session = session,
                Form = form
            };
        }

        private static Session GetSession(CookieCollection cookies)
        {
            var sessionId = cookies.Contains(Session.SessionCookieName)
                ? cookies[Session.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new Session(sessionId);
            }

            return Sessions[sessionId];
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookieCollection = new CookieCollection();

            if (headers.Contains(Header.Cookie))
            {
                var cookieHeader = headers[Header.Cookie];
                var allCookies = cookieHeader.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookieText in allCookies)
                {
                    var cookieParts = cookieText.Split('=', StringSplitOptions.RemoveEmptyEntries);

                    var cookieName = cookieParts[0]?.Trim();
                    var cookieValue = cookieParts[1]?.Trim();

                    cookieCollection.Add(cookieName, cookieValue);
                }
            }

            return cookieCollection;
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType)
                && headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                var parsedResult = ParseFormData(body);

                foreach (var (name, value) in parsedResult)
                {
                    formCollection.Add(name, value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
            => HttpUtility.UrlDecode(bodyLines)
            .Split('&')
            .Select(part => part.Split('='))
            .Where(part => part.Length == 2)
            .ToDictionary(
                part => part[0],
                part => part[1]
                , StringComparer.InvariantCultureIgnoreCase);
        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
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