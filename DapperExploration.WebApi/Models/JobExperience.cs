using System;

namespace DapperExploration.WebApi.Models
{
    public class JobExperience
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string[] TechStack { get; set; }
        public DateTime JobPeriod_Start { get; set; }
        public DateTime? JobPeriod_End { get; set; }
    }
}