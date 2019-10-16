using App.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities = DataAccess.EntityFramework.Models;

namespace DataAccess.EntityFramework.Repositories
{
    public class ActionStateRepository : IActionStateWriteRepository
    {
        private readonly JobContext _jobContext;
        public ActionStateRepository(JobContext jobContext)
        {
            _jobContext = jobContext;
        }
        public async Task Add(ActionState actionState)
        {
            Entities.ActionState actionStateEntity = new Entities.ActionState()
            {
                ActionId = (int)actionState.Action,
                StatusId = (int)actionState.Status,
                ActionDateTime = actionState.ActionDateTime,
                JobId = actionState.JobId,
                Notes = actionState.Notes,
                EIN = 12323,
                UserName = "Dev"
            };
            await _jobContext.AddAsync(actionStateEntity);
            await _jobContext.SaveChangesAsync();
        }
    }
}
