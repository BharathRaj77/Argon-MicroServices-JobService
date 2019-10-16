using App.Repositories;
using App.UseCases.CreateJob;
using App.UseCases.GetJobDetailUseCase;
using App.UseCases.GetJobIdentifier;
using App.UseCases.UpdateActionStateUseCase;
using DataAccess.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Registries
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ICreateJobUseCase, CreateJobUseCase>();// have to move this to respective projects
            services.AddScoped<IGetJobDetailUseCase, GetJobDetailUseCase>();
            services.AddScoped<IGetJobIdentifierUseCase, GetJobIdentifierUseCase>();
            services.AddScoped<IJobWriteRepository, JobRepository>();
            services.AddScoped<IJobReadRepository, JobRepository>();
            services.AddScoped<IJobIdentifierSequenceRepository, JobIdentifierSequenceRepository>();
            services.AddScoped<IUpdateActionStateUseCase, UpdateActionStateUseCase>();
            services.AddScoped<IActionStateWriteRepository, ActionStateRepository>();
        }
    }
}
