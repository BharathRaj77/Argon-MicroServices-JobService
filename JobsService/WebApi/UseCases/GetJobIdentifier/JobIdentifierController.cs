using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.UseCases.GetJobIdentifier;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.GetJobIdentifier
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class JobIdentifierController : ControllerBase
    {
        private IGetJobIdentifierUseCase _getJobIdentifierUseCase;
        public JobIdentifierController(IGetJobIdentifierUseCase getJobIdentifierUseCase)
        {
            _getJobIdentifierUseCase = getJobIdentifierUseCase;
        }
        [HttpGet("{jobType}", Name ="GetJobIdentifier")]
        public async Task<IActionResult> Get(string jobType)
        {
            return new JsonResult ( await _getJobIdentifierUseCase.Execute(jobType));
        } 
    }
}