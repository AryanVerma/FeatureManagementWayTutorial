using DotNetCoreApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace DotNetCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IFeatureManager _featureManager;

        public EmployeeController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            if (await _featureManager.IsEnabledAsync("FeatureA"))
            {
                return Ok(DataGenerator.Employees);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("GetAdvancedEmployees")]
        [FeatureGate("FeatureB")]
        public async Task<IActionResult> GetAdvancedEmployees()
        {

            return Ok(DataGenerator.Employees);


        }

    }
}