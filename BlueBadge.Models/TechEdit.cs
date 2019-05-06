using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class TechEdit
    {
        public int TechId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public double HourlyRate { get; set; }
        public double WeekendRate { get; set; }
        public double AfterHoursRate { get; set; }
        public double HolidayRate { get; set; }
        public double EmergencySameDayRate { get; set; }
        public double EmergencyNextDayRate { get; set; }
    }
}
