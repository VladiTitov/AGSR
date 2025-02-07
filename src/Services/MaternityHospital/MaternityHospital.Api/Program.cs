var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApplicationBuilder();

var app = builder.Build();

app.ConfigureWebApplication();

app.Run();
