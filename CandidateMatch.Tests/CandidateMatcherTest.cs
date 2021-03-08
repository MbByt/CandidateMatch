
using CandidateMatch.Common.Options;
using CandidateMatch.Data.Context;
using CandidateMatch.Services;
using CandidateMatch.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CandidateMatch.Data.Models;

namespace CandidateMatch.Tests
{
    public class CandidateMatcherTest
    {
        BestCandidateController controller;
        IConfiguration configuration;
        IJobAdderApiOptions jobAdderApiOptions;
        ICandidateAPIContext CandidateAPIContext;
        IJobAPIContext  jobAPIContext;
        ICandidateMatcher candidateMatcher;
        

        public CandidateMatcherTest()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            jobAdderApiOptions = new JobAdderApiOptions(configuration);
            CandidateAPIContext = new CandidateAPIContext(jobAdderApiOptions);
            jobAPIContext = new JobAPIContext(jobAdderApiOptions);
            candidateMatcher = new CandidateMatcher(CandidateAPIContext, jobAPIContext);
            controller = new BestCandidateController(candidateMatcher);
             
        }

        [Test]
        public async Task CandidateMatch_ShouldReturnValidResultAsync()
        {
            var actionResult = await controller.GetAsync(1);
            //Null means no HTTP Error Code
            Assert.IsNull(actionResult.Result);
            Assert.IsNotNull(actionResult);
        }

        [Test]
        public async Task CandidateMatch_ShouldReturnValidCandidateModelAsync()
        {
            var actionResult = await controller.GetAsync(1);
            Assert.IsNull(actionResult.Result);
            Assert.IsNotNull(actionResult);
            Assert.That(actionResult.Value, Is.TypeOf<CandidateModel>());
        }

        [Test]
        public async Task CandidateMatch_ShouldReturnCorrectValuesAsync()
        {
            var result = await controller.GetAsync(1);
            Assert.IsNotNull(result);
            Assert.Greater(result.Value.candidateId, 0);
        }

        [Test]
        public async Task CandidateMatch_NotFoundForInvalidJobIDsAsync()
        {
            var actionResult = await controller.GetAsync(-1);
            Assert.That(actionResult.Result, Is.TypeOf<NotFoundResult>());
            actionResult = await controller.GetAsync(16);
            Assert.That(actionResult.Result, Is.TypeOf<NotFoundResult>());
        }



    }
}
