using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string SkillName { get; set; }
        [Required]
        public string SkillDescription { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
