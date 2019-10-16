using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public interface IJobReadRepository
    {
        Task<JobDetail> Get(int id);
        Task<JobDetail> Get(string jobIdentifier);
        Task<List<JobDetail>> Get();
    }
}
