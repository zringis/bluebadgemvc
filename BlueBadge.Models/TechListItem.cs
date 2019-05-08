using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class TechListItem
    {
        public int TechId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Hourly Rate")]
        public double HourlyRate { get; set; }
        [Display(Name = "Weekend Rate")]
        public double WeekendRate { get; set; }
        [Display(Name = "After Hours Rate")]
        public double AfterHoursRate { get; set; }
        [Display(Name = "Holiday Rate")]
        public double HolidayRate { get; set; }
        [Display(Name = "Same Day Rate")]
        public double EmergencySameDayRate { get; set; }
        [Display(Name = "Next Day Rate")]
        public double EmergencyNextDayRate { get; set; }
        [Display(Name = "Joined On")]
        public DateTimeOffset CreatedUtc { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
