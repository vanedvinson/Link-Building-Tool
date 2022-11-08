using Microsoft.AspNetCore.Mvc;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public JobController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var res = await _serviceManager.JobService.GetAllJobsAsync();

            return Ok(res);
        }
    }
}
