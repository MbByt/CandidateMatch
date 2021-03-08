using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidateMatch.Data.Context
{
    public interface IJobAPIContext
    {
        Task<T> GetAsync<T>(string queries = "");
    }
}
