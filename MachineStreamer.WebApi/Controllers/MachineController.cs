using MachineStreamer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineStreamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService machineService;

        public MachineController(IMachineService machineService)
        {
            this.machineService = machineService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data =  machineService.GetAll(_ => true);
            return Ok(data);
        }
    }
}
