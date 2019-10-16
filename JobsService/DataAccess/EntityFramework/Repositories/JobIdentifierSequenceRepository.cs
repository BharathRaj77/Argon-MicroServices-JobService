using App.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities = DataAccess.EntityFramework.Models;

namespace DataAccess.EntityFramework.Repositories
{
    public class JobIdentifierSequenceRepository : IJobIdentifierSequenceRepository //Repository<Entities.JobIdentifierSequence>, 
    {
        private readonly JobContext _jobContext;
        public JobIdentifierSequenceRepository(JobContext jobContext)
        {
            _jobContext = jobContext;
        }
        public async Task<JobIdentifierSequence> Get()
        {
            Entities.JobIdentifierSequence jobIdentifierSequence = new Entities.JobIdentifierSequence();
            //Add(jobIdentifierSequence);
            //Save();
            await _jobContext.JobIdentifierSequences.AddAsync(jobIdentifierSequence);
            await _jobContext.SaveChangesAsync();

            return new JobIdentifierSequence(jobIdentifierSequence.Id);
        }
    }
}
