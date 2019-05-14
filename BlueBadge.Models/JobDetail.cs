using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class JobDetail
    {
        [Display(Name="Job ID")]
        public int JobId { get; set; }
        [Display(Name="Company Name")]
        public string CompanyName { get; set; }
        [Display(Name="Description of Job")]
        public string JobDescription { get; set; }

        [Display(Name = "Location ID")]
        public int LocationId { get; set; }
        [Display(Name = "Location")]
        public Location Location { get; set; }

        [Display(Name="Created on")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Display(Name = "Skill ID")]
        public int SkillId { get; set; }
        [Display(Name = "Skill Needed")]
        public Skill Skill { get; set; }


    }
}
