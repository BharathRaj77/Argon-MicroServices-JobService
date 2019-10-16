using App.Repositories;
using Domain.Enums;
using Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases.GetJobIdentifier
{
    public class GetJobIdentifierUseCase : IGetJobIdentifierUseCase
    {
        private IJobIdentifierSequenceRepository _jobIdentifierSequenceRepository;
        public GetJobIdentifierUseCase(IJobIdentifierSequenceRepository jobIdentifierSequenceRepository)
        {
            _jobIdentifierSequenceRepository = jobIdentifierSequenceRepository;
        }
        public async Task<string> Execute(string jobType)
        {
            var jobSequence = await _jobIdentifierSequenceRepository.Get();
            var jobIdPrefix = Extension.GetJobIdPrefix((JobTypeEnum)Enum.Parse(typeof(JobTypeEnum), jobType));
            // read the environment variable as well 
            return jobIdPrefix +"00000000"+ jobSequence.Id;
        }
    }
}
