using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }
        public string CompanyName { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}
