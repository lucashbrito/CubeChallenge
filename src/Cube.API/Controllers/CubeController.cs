using System.Collections.Generic;
using System.Threading.Tasks;
using Cube.Serivce;
using Cube.Serivce.Dto;
using Cube.Serivce.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cube.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CubeController : ControllerBase
    {

        private readonly ILogger<CubeController> _logger;
        private ICubeServices _cubeServicesServices;
        public CubeController(ILogger<CubeController> logger, ICubeServices cubeServices)
        {
            _logger = logger;
            _cubeServicesServices = cubeServices;
        }

        [HttpPost]
        public ReportDto Get([FromBody] CubesViewModel cubes)
        {
            return _cubeServicesServices.GetReport(cubes);
        }

        [HttpPost("/GetAsync")]
        public async Task<IEnumerable<ReportDto>> GetAsync([FromBody] List<CubesViewModel> cubes)
        {
            return await _cubeServicesServices.GetReportAsync(cubes);
        }
    }
}

