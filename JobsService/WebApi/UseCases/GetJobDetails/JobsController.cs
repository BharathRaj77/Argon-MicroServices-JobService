using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.UseCases;
using App.UseCases.GetJobDetailUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.GetJobDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IGetJobDetailUseCase _getjobDetailUseCase;
        public JobsController(IGetJobDetailUseCase getJobDetailUseCase)
        {
            _getjobDetailUseCase = getJobDetailUseCase;
        }
        [HttpGet("{jobId}", Name ="GetJobById")]
        public async Task<IActionResult> GetJob(int jobId)
        {
            JobOutput jobOutput = await _getjobDetailUseCase.Execute(jobId);
            return new ObjectResult(jobOutput);
        }
        [HttpGet("GetJob/{jobIdentifier}", Name ="GetJobByIdentifier")]
        public async Task<IActionResult> GetJob(string jobIdentifier)
        {
            JobOutput jobOutput = await _getjobDetailUseCase.Execute(jobIdentifier);
            return new ObjectResult(jobOutput);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<JobOutput> jobOutputs = await _getjobDetailUseCase.Execute();
            return new JsonResult(jobOutputs);
        }
    }
}