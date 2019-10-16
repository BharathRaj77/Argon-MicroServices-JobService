using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public interface IJobWriteRepository
    {
        Task Add(JobDetail jobDetail);
    }
}
