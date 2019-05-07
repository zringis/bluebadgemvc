using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class SkillListItem
    {
        [Display(Name="Skill ID")]
        public int SkillId { get; set; }
        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }
        [Display(Name = "Skill Description")]
        public string SkillDescription { get; set; }
        [Display(Name = "Created On")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
