using CandidateMatch.Data.Context;
using CandidateMatch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateMatch.Services
{
    public class CandidateMatcher : ICandidateMatcher
    {
        private readonly ICandidateAPIContext _candidateAPIContext;
        private readonly IJobAPIContext _jobAPIContext;
        public CandidateMatcher(ICandidateAPIContext candidateAPIContext, IJobAPIContext jobAPIContext)
        {
            _candidateAPIContext = candidateAPIContext;
           _jobAPIContext = jobAPIContext;
        }
        public async Task<CandidateModel> GetBestMatchedCandidateAsync( int JobId)
        {
            List<CandidateModel> CandidateList = await _candidateAPIContext.GetAsync<List<CandidateModel>>();
            List<JobModel> JobList = await _jobAPIContext.GetAsync<List<JobModel>>();

            List<(int CandidateID, int Points)> Points = new List<(int CandidateID, int Points)>();

            var Job = JobList?.Where(x => x.jobId == JobId).FirstOrDefault();
            if (Job is null) return null;

          
            int CandidatePoints = 0;
            foreach (var candidate in CandidateList)
             {
                int CandidateSkillsCount = candidate.skillTagsList.Count;
                int JobSkillsCount = Job.skillsList.Count;

                foreach (string CandidateSkill in candidate.skillTagsList)
                {
                    
                    foreach (string JobSkill in Job.skillsList)
                    {

                        if( CandidateSkill.Trim().ToUpper() == JobSkill.Trim().ToUpper())
                        {
                            CandidatePoints += JobSkillsCount * CandidateSkillsCount;

                        }
                        JobSkillsCount -= 1;
                    }
                    CandidateSkillsCount -= 1;
                }

                Points.Add((candidate.candidateId, CandidatePoints));
                CandidatePoints = 0;
            }


            int MaxPointOfCandidates = Points.Max(c => c.Points);

            var BestCandidateMatch = Points.Where(c => c.Points == MaxPointOfCandidates).FirstOrDefault();

            var BestCandidateDetails =  CandidateList.Where(c =>c.candidateId == BestCandidateMatch.CandidateID).FirstOrDefault();

            return BestCandidateDetails;
        }
    }

}
