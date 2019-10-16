using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases.CreateJob
{
    public interface ICreateJobUseCase
    {
        Task<bool> Execute (Name jobName, string jobDescription,
            DateTime jobEffectiveStartDate, string jobType, string action, string jobStatus,
            string notes);
    }
}
