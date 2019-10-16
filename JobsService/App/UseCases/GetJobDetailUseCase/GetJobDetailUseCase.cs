using App.Exceptions;
using App.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases.GetJobDetailUseCase
{
    public class GetJobDetailUseCase : IGetJobDetailUseCase
    {
        private readonly IJobReadRepository _jobReadRepository;
        public GetJobDetailUseCase(IJobReadRepository jobReadRepository)
        {
            _jobReadRepository = jobReadRepository;
        }
        public async Task<JobOutput> Execute(int jobId)
        {
            JobDetail jobDetail = await _jobReadRepository.Get(jobId);

            if (jobDetail == null)
                throw new JobDetailnotFoundException($"The Job Id '{jobId}' does not exists or is not processed yet.");
            JobOutput jobOutput = new JobOutput(jobDetail);
            return jobOutput;
        }

        public async Task<JobOutput> Execute(string jobIdentifier)
        {
            JobDetail jobDetail = await _jobReadRepository.Get(jobIdentifier);
            if (jobDetail == null)
                throw new JobDetailnotFoundException($"The Job Identifier '{jobIdentifier}' does not exists or is not processed yet.");
            JobOutput jobOutput = new JobOutput(jobDetail);
            return jobOutput;
        }

        public async Task<List<JobOutput>> Execute()
        {
            List<JobDetail> jobList = new List<JobDetail>();
            jobList = await _jobReadRepository.Get();
            if (jobList.Count == 0)
                throw new JobDetailnotFoundException($"No jobs found!");
            List<JobOutput> jobOutputs = new List<JobOutput>();
            foreach (var jobDetail in jobList)
            {
                jobOutputs.Add(new JobOutput(jobDetail));
            }
            return jobOutputs;
        }
    }
}
