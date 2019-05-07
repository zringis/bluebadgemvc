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
        [Display(Name="Location of Job")]
        public string JobLocation { get; set; }
        [Display(Name="Created on")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Last Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
