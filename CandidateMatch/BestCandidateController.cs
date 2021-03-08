using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateMatch.Services;
using CandidateMatch.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateMatch.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  BestCandidateController : ControllerBase
    {

        private readonly ICandidateMatcher _candidateMatcher;

        public BestCandidateController(ICandidateMatcher candidateMatcher)
        {
            _candidateMatcher = candidateMatcher;
        }

        //GET api/JobId
        [HttpGet("{JobId}")]
        public async Task<ActionResult<CandidateModel>> GetAsync(int JobId)
        {
            var BestMatchedCandidate = await _candidateMatcher.GetBestMatchedCandidateAsync(JobId);
            if (BestMatchedCandidate != null && BestMatchedCandidate.candidateId > 0)
            {
                return BestMatchedCandidate;
            }
            else {
                return NotFound();
            }
        }

    }
}