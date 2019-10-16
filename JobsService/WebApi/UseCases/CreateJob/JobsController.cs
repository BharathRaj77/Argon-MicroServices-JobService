using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.UseCases.CreateJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.CreateJob
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ICreateJobUseCase _createJobUSeCase;
        public JobsController(ICreateJobUseCase createJobUseCase)
        {
            _createJobUSeCase = createJobUseCase;
        } 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequest request)
        {
            await _createJobUSeCase.Execute(//request.JobIdentifier,
                request.JobName,
                request.JobDescription,
                request.EffectiveStartDate,
                request.JobType,
                request.Action,
                request.JobStatus,
                request.Notes);

            return new ObjectResult(null);
        }
    }
}