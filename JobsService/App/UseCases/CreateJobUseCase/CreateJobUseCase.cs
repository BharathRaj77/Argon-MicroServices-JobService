using App.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.ValueObjects;
using Domain.Enums;

namespace App.UseCases.CreateJob
{
    public sealed class CreateJobUseCase : ICreateJobUseCase
    {
        private readonly IJobWriteRepository _jobWriteRepository;
        public CreateJobUseCase(IJobWriteRepository jobWriteRepository)
        {
            _jobWriteRepository = jobWriteRepository;
        }
        public async Task<bool> Execute(Name jobName, string jobDescription, DateTime jobEffectiveStartDate,
            string jobType, string action, string jobStatus, string notes)
        {
            ActionState actionState = new ActionState(action, jobStatus, DateTime.Now, notes);
            JobDetail jobDetail = new JobDetail(
                jobName, jobEffectiveStartDate, jobDescription,
                jobType, actionState);

            await _jobWriteRepository.Add(jobDetail);
            return true;
        }
    }
}
