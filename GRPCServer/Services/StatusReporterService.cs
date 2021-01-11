using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GRPCServer
{
    public class StatusReporterService : StatusReporter.StatusReporterBase
    {
        private readonly ILogger<StatusReporterService> _logger;

        private Random rng;

        public StatusReporterService(ILogger<StatusReporterService> logger)
        {
            _logger = logger;
            rng = new Random();
        }

        public override async Task RunScan(StatusRequest request, IServerStreamWriter<StatusReply> responseStream, ServerCallContext context)
        {
            float progress = 0f;

            while (progress < 1f)
            {
                progress += (float)rng.NextDouble() / 10f;
                await responseStream.WriteAsync(new StatusReply
                {
                    Progress = (progress >= 1f) ? 1f : progress,
                    Finished = (progress >= 1f) ? true : false,
                    Message = (progress >= 1f) ? "Scan finished!" : "Scanning devices..."
                });

                await Task.Delay(500);
            }
        }
    }
}