using App.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Entities = DataAccess.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Repositories
{
    public sealed class JobRepository : IJobWriteRepository, IJobReadRepository
    {
        private readonly JobContext _jobContext;
        //private readonly IJobIdentifierSequenceRepository _jobIdentifierSequenceRepository;
        public JobRepository(JobContext jobContext, 
            IJobIdentifierSequenceRepository jobIdentifierSequenceRepository)
        {
            _jobContext = jobContext ?? throw new ArgumentNullException(nameof(jobContext));
            //_jobIdentifierSequenceRepository = jobIdentifierSequenceRepository;
        }
        public async Task Add(JobDetail jobDetail)
        {
            var newSequenceId = await _jobContext.JobIdentifierSequences.MaxAsync(_=>_.Id) + 1; //check this
            Entities.JobDetail jobDetailEntity = new Entities.JobDetail()
            {
                Identifier = jobDetail.Identifier + "00000000" + newSequenceId,
                Name = jobDetail.Name,
                Description = jobDetail.Description,
                EffectiveStartDate = jobDetail.EffectiveStartDate,
                Type = (int)jobDetail.Type
            };
            //jobDetailEntity.Identifier += "00000000" + latestSequenceId + 1;

            
            Entities.JobIdentifierSequence jobIdentifierSequence = new Entities.JobIdentifierSequence();
            await _jobContext.JobIdentifierSequences.AddAsync(jobIdentifierSequence); //_jobIdentifierSequenceRepository.Get();
            await _jobContext.JobDetails.AddAsync(jobDetailEntity); // either change the identity column or change the reading logic

            Entities.ActionState actionState = new Entities.ActionState() // check this : is it a good practice when we have a seperate ActionStateRepository
            {
                ActionId = (int)jobDetail.ActionState.Action,
                StatusId = (int)jobDetail.ActionState.Status,
                JobDetail = jobDetailEntity,
                EIN = 12323,// temp
                UserName = "Dev",
                ActionDateTime = jobDetail.ActionState.ActionDateTime
            };
            await _jobContext.ActionStates.AddAsync(actionState);

            await _jobContext.SaveChangesAsync();
        }

        public async Task<JobDetail> Get(int id)
        {
            Entities.JobDetail jobDetail = await _jobContext.JobDetails.FindAsync(id);
            return JobDetail.LoadFromDetails(jobDetail.Id, jobDetail.Identifier, jobDetail.Name,
                jobDetail.EffectiveStartDate, jobDetail.Description, jobDetail.Type); // check this JobType - should it be int or string or enumType 
        }

        public async Task<JobDetail> Get(string jobIdentifier)
        {
            Entities.JobDetail jobDetail = await _jobContext.JobDetails.FirstOrDefaultAsync(_=>_.Identifier == jobIdentifier);
            return JobDetail.LoadFromDetails(jobDetail.Id, jobDetail.Identifier, jobDetail.Name,
                jobDetail.EffectiveStartDate, jobDetail.Description, jobDetail.Type);
        }

        public async Task<List<JobDetail>> Get()
        {
            List<Entities.JobDetail> entityJobDetails = await _jobContext.JobDetails.ToListAsync();
            List<JobDetail> jobList = new List<JobDetail>();
            foreach (var jobDetail in entityJobDetails)
            {
                jobList.Add(JobDetail.LoadFromDetails(jobDetail.Id, jobDetail.Identifier, jobDetail.Name,
                jobDetail.EffectiveStartDate, jobDetail.Description, jobDetail.Type));
            }
            return jobList;
        }
    }
}
