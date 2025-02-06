using MaternityHospital.EntityGenerator.Services;

namespace MaternityHospital.EntityGenerator
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IGeneratorService _generatorService;

        private readonly TimeSpan _timeout = TimeSpan.FromHours(1);
        private readonly int _entitiesCount = 100;

        public Worker(
            ILogger<Worker> logger,
            IGeneratorService generatorService)
        {
            _logger = logger;
            _generatorService = generatorService;
        }

        protected override async Task ExecuteAsync(
            CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var entities = _generatorService.GetPatientList(_entitiesCount);
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
