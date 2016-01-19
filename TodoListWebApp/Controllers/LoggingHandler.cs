using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TodoListWebApp.Controllers
{
    // Note: Credit for this class belongs to http://stackoverflow.com/questions/18924996/logging-request-response-messages-when-using-httpclient

    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.TraceInformation("Request:");
            Trace.TraceInformation(request.ToString());
            if (request.Content != null)
            {
                Trace.TraceInformation(await request.Content.ReadAsStringAsync());
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Trace.TraceInformation("Response:");
            Trace.TraceInformation(response.ToString());
            if (response.Content != null)
            {
                Trace.TraceInformation(await response.Content.ReadAsStringAsync());
            }

            return response;
        }
    }
}