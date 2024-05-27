using SeniorTeste.Service.Interface;

namespace SeniorTeste.BackgroudService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger,  IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IClimaService>();
                    scopedService.Create("Curitiba");
                    scopedService.Create("Florianópolis");
                    scopedService.Create("Porto Alegre");

                    await Task.Delay(120000, stoppingToken);
                }
            }
        }
    }
}
