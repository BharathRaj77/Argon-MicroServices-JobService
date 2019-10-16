using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases.GetJobDetailUseCase
{
    public interface IGetJobDetailUseCase
    {
        Task<JobOutput> Execute(int jobId);
        Task<JobOutput> Execute(string jobIdentifier);
        Task<List<JobOutput>> Execute();
    }
}
