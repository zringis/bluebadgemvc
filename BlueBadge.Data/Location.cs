using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Location
    {
        [Key]
        [Display(Name = "Location ID")]
        public int LocationId { get; set; }
        [Required]
        [Display(Name = "State")]
        public string LocationState { get; set; }
        [Required]
        [Display(Name = "City")]
        public string LocationCity { get; set; }
    }
}
