using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class LocationCreate
    {
        [Required]
        [Display(Name = "State")]
        public string LocationState { get; set; }
        [Required]
        [Display(Name = "City")]
        public string LocationCity { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string LocationAddress { get; set; }
    }
}
