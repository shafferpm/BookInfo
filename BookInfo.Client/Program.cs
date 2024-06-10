using BookInfo.Client.Helpers;
using BookInfo.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((_, services) =>
	{
		services.AddLogging(configure => configure.AddDebug().AddConsole());
		services.AddSingleton<JsonSerializerOptionsWrapper>();
		services.AddHttpClient("AuthorsAPIClient",
			configureClient =>
			{
				configureClient.BaseAddress = new Uri("https://localhost:7240");
				configureClient.Timeout = new TimeSpan(0, 0, 30);
			});
		services.AddScoped<IIntegrationService, AuthorServices>();
	}).Build();

try
{
	var logger = host.Services.GetRequiredService<ILogger<Program>>();
	logger.LogInformation("Host created.");

	await host.Services.GetRequiredService<IIntegrationService>().RunAsync();
}
catch (Exception ex)
{
	var logger = host.Services.GetRequiredService<ILogger<Program>>();
	logger.LogError(ex, 
		"An error occurred while running the integration service.");	
}

Console.ReadKey();

await host.RunAsync();