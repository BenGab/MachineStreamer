using MachinerStreamer.Worker;
using MachineStreamer.Services;
using MachinStreamer.DAL;
using MachinStreamer.DAL.Repositories;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddSingleton<IMongoDbSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddSingleton<IMachineDataRepository, MachineDataRepository>();
builder.Services.AddSingleton<IMachineService, MachineService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
