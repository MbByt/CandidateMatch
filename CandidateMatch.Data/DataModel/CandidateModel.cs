using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidateMatch.Data.Models
{
    public class CandidateModel
    {
        public int candidateId { set; get; }

        public string name { set; get; }

        public string skillTags { set; get; }

        public List<string> skillTagsList
        {
            get
            {
                return skillTags.Split(",").ToList();
            }
        }
    }
}
