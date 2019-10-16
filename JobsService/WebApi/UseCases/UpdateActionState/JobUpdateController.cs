using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.UseCases.UpdateActionStateUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.UpdateActionState
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobUpdateController : ControllerBase
    {
        private readonly IUpdateActionStateUseCase _updateActionStateUseCase;
        public JobUpdateController(IUpdateActionStateUseCase updateActionStateUseCase)
        {
            _updateActionStateUseCase = updateActionStateUseCase;
        }
        [HttpPost]
        public async Task<ActionResult> Post(UpdateRequest request)
        {
            await _updateActionStateUseCase.Execute(request.JobId,
                request.ActionType, request.JobStatus, request.Notes);
            return new ObjectResult(true);
        }
    }
}