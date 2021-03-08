using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateMatch.Data.Context
{
    public interface ICandidateAPIContext
    {
        Task<T> GetAsync<T>(string queries = "");
    }
}
