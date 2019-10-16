using App.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace AppTests.UseCases.CreateJobUseCase
{
    
    public class CreateJobUseCaseTests
    {
        Mock<IJobWriteRepository> jobWriteRepository;
        [SetUp]
        public void SetUp()
        {
            
        }
        public CreateJobUseCaseTests()
        {
            jobWriteRepository = new Mock<IJobWriteRepository>();
        }
        [Test]
        public void CreateJobUseCase_ShouldCreateJob()
        {
            jobWriteRepository.Setup(obj=>obj.)
        }
    }
}
