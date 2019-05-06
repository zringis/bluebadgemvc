using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string JobLocation { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
