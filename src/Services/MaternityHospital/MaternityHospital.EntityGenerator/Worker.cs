using MaternityHospital.EntityGenerator.Services;

namespace MaternityHospital.EntityGenerator
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        private readonly TimeSpan _timeout = TimeSpan.FromHours(1);
        private readonly int _entitiesCount = 100;

        public Worker(
            ILogger<Worker> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(
            CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var generatorService = scope.ServiceProvider.GetRequiredService<IGeneratorService>();
                    var patientsService = scope.ServiceProvider.GetRequiredService<IPatientsService>();

                    var entities = generatorService.GetPatientList(_entitiesCount);
                    var tasks = new List<Task>(entities.Select(i => patientsService.CreateAsync(i, cancellationToken)));

                    await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        exception: ex,
                        message: "{0} throw exception with message: '{1}' at: {2}",
                            this.GetType().Name, ex.Message, DateTime.Now);
                }
                await Task.Delay(_timeout, cancellationToken);
            }
        }
    }
}
