var hostBuilder = Host.CreateDefaultBuilder();

hostBuilder.ConfigureHostBuilder();

var host = hostBuilder.Build();

host.Run();
