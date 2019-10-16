using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.UseCases.GetJobIdentifier
{
    public interface IGetJobIdentifierUseCase
    {
        Task<string> Execute(string jobType);
    }
}
