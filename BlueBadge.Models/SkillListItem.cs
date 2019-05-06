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
        [Display(Name="Skill Id")]
        public int SkillId { get; set; }
        [Display(Name = "Skill Name")]
        public int SkillName { get; set; }
        [Display(Name = "Skill Description")]
        public int SkillDescription { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
