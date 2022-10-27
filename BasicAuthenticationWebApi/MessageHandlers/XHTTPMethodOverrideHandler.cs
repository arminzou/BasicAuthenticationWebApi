using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Drawing;

namespace BasicAuthenticationWebApi.MessageHandlers
{
    public class XHTTPMethodOverrideHandler : DelegatingHandler
    {
        // The X-HTTP-Method-Override is a non-standard HTTP header.It is basically designed for clients who cannot send certain HTTP request types,
        // such as PUT or DELETE.Instead, the client sends a POST request and sets the X-HTTP-Method-Override header to the desired method type
        readonly string[] _methods = { "DELETE", "HEAD", "PUT" };
        const string _header = "X-HTTP-Method-Override";
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Check for HTTP POST with the X-HTTP-Method-Override header.
            if (request.Method == HttpMethod.Post && request.Headers.Contains(_header))
            {
                // Check if the header value is in our methods list.
                var method = request.Headers.GetValues(_header).FirstOrDefault();
                if (_methods.Contains(method, StringComparer.InvariantCultureIgnoreCase))
                {
                    // Change the request method.
                    request.Method = new HttpMethod(method);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}