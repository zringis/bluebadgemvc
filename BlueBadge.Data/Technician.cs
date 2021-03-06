﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Technician
    {
        [Key]
        public int TechId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }


        public string TechSkill { get; set; }


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
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        //allows us to access stuff in skills
        [Display(Name = "Skill ID")]
        public int SkillId { get; set; }
        [Display(Name = "Skill")]
        public virtual Skill Skill { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }


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
