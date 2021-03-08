using Microsoft.Extensions.Configuration;

namespace CandidateMatch.Common.Options
{
    public  class JobAdderApiOptions :IJobAdderApiOptions
    {
        private readonly IConfiguration _configuration;

        public JobAdderApiOptions(IConfiguration Configuration)
        {
            _configuration = Configuration;
            JobApiEndPoint = _configuration["JobApiEndPoint"];
            CandidateApiEndPoint = _configuration["CandidateApiEndPoint"];
            CandidatesAPIPath = _configuration["CandidatesAPIPath"];
            JobsAPIPath = _configuration["JobsAPIPath"];
        }

        public  string JobApiEndPoint { get; set; }
        public  string CandidateApiEndPoint { get; set; } 
        public  string CandidatesAPIPath { get; set; } 
        public  string JobsAPIPath { get; set; } 
 
    }
}
