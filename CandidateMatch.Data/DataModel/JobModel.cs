using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidateMatch.Data.Models
{
    public class JobModel
    {
        public int jobId { set; get; }

        public string name { set; get; }

        public string compny { set; get; }

        public string skills { set; get; }

        public List<string> skillsList
        {
            get
            {
                return skills.Split(",").ToList();
            }
        }
    }
}
