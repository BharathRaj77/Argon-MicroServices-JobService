using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public interface IActionStateWriteRepository
    {
        Task Add(ActionState actionSate);
    }
}
