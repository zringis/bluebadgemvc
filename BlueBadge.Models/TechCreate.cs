using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class TechCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string LastName { get; set; }
        [Required]
        public string Location { get; set; }


        public int SkillId { get; set; }
        public Skill Skill { get; set; }



        [Required]
        public double HourlyRate { get; set; }
        [Required]
        public double WeekendRate { get; set; }
        [Required]
        public double AfterHoursRate { get; set; }
        [Required]
        public double HolidayRate { get; set; }
        [Required]
        public double EmergencySameDayRate { get; set; }
        [Required]
        public double EmergencyNextDayRate { get; set; }

        //public override string ToString() => FirstName;
    }
}
