using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases.UpdateActionStateUseCase
{
    public interface IUpdateActionStateUseCase
    {
        Task<bool> Execute(int jobId, string action, string status, string notes);
    }
}
