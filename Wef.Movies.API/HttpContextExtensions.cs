using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Wef.Movies.API
{
    public static class HttpContextExtensions
    {
        public static string GetIPAddress(this HttpContext context)
        {
            var remoteIpAddress = context.Connection?.RemoteIpAddress?.ToString();

            if (string.IsNullOrWhiteSpace(remoteIpAddress))
            {
                remoteIpAddress = GetHeaderValueAs<string>("REMOTE_ADDR", context);
            }

            return remoteIpAddress ?? string.Empty;
        }


        private static T? GetHeaderValueAs<T>(string headerName, HttpContext context)
        {
            StringValues values;

            if (context.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();  

                if (!rawValues.IsNullOrWhitespace())
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }

            return default;
        }

        private static List<string>? SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }

        private static bool IsNullOrWhitespace(this string s)
        {
            return String.IsNullOrWhiteSpace(s);
        }
    }
}
