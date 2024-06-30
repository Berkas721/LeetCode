using LeetCode.Startup;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureServices();

var app = builder.Build();

await app.Configure();

await app.RunAsync();