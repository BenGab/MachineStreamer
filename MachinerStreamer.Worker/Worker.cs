using MachineStreamer.Services;
using MachinStreamer.DAL.Models;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace MachinerStreamer.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMachineService machineService;
        private readonly string webSocketUrl;

        public Worker(ILogger<Worker> logger, IMachineService machineService, IConfiguration configuration)
        {
            _logger = logger;
            this.machineService = machineService;
            this.webSocketUrl = configuration.GetValue<string>("WebSocketUrl");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using(var socket = new ClientWebSocket())
            {
                await socket.ConnectAsync(new Uri(this.webSocketUrl), stoppingToken);

                while (!stoppingToken.IsCancellationRequested)
                {
                    var buffer = new byte[1024 * 4];
                    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), stoppingToken);
                    var jsonString = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    _logger.LogInformation(jsonString);
                    var machineData = JsonConvert.DeserializeObject<MachineData>(jsonString);
                    if (machineData != null)
                    {
                        await machineService.InsertAsync(machineData);
                    }
                }
            }
        }
    }
}
