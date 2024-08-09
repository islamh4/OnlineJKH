using Grpc.Core;
using GrpsService;
namespace GrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<Reply> SendingReceipt(Request request, ServerCallContext context)
        {
            return Task.FromResult(new Reply
            {
                Message = "Квитанция успешно принято!"
            });
        }
    }
}