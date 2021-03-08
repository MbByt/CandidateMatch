using Microsoft.Extensions.Configuration;

namespace CandidateMatch.Common.Options
{
    public interface IJobAdderApiOptions
    {
        string JobApiEndPoint { get; set; }

        string CandidateApiEndPoint { get; set; }

        string CandidatesAPIPath { get; set; }

        string JobsAPIPath { get; set; }
    }
    
}
