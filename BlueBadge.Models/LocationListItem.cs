using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class LocationListItem
    {
        [Display(Name = "Location ID")]
        public int LocationId { get; set; }
        [Display(Name = "State")]
        public string LocationState { get; set; }
        [Display(Name = "City")]
        public string LocationCity { get; set; }
    }
}
