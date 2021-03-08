using CandidateMatch.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateMatch.Services
{
    public interface ICandidateMatcher
    {

        Task< CandidateModel> GetBestMatchedCandidateAsync(int JobId);

   }
}
