using App.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases.UpdateActionStateUseCase
{
    public class UpdateActionStateUseCase : IUpdateActionStateUseCase
    {
        private readonly IActionStateWriteRepository _actionStateWriteRepository;
        public UpdateActionStateUseCase(IActionStateWriteRepository actionStateWriteRepository)
        {
            _actionStateWriteRepository = actionStateWriteRepository;
        }
        public async Task<bool> Execute(int jobId, string action, string status, string notes)
        {
            ActionState actionState = new ActionState(action, status, DateTime.Now, notes, jobId);
            await _actionStateWriteRepository.Add(actionState);
            return true;
        }
    }
}
