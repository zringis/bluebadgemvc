using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class JobListItem
    {
        [Display(Name = "JobID")]
        public int JobId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Description")]
        public string JobDescription { get; set; }
        [Display(Name = "Location")]
        public string JobLocation { get; set; }
        [Display(Name = "Job Added On")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
