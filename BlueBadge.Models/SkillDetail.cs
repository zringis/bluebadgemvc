using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class SkillDetail
    {
        [Display(Name = "Skill ID")]
        public int SkillId { get; set; }
        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }
        [Display(Name = "Skill Description")]
        public string SkillDescription { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
