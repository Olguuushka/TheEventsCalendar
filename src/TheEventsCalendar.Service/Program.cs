using TheEventsCalendar.Service.IoC;
using TheEventsCalendar.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
    .Build();

var settings = TheEventsCalendarSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

DbContextConfigurator.ConfigureServices(services, settings);
SerilogConfigurator.ConfigureServices(builder);
SwaggerConfigurator.ConfigureService(services);


var app = builder.Build();

DbContextConfigurator.ConfigureApplication(app);
SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();

app.MapGet("/", () => "Прощай жёстокий мир!");

app.Run();