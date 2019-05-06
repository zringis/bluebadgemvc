﻿using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class TechService
    {
        private readonly Guid _userId;

        public TechService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTech(TechCreate model)
        {
            var entity =
                new Technician()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Location = model.Location,
                    HourlyRate = model.HourlyRate,
                    WeekendRate = model.WeekendRate,
                    AfterHoursRate = model.AfterHoursRate,
                    HolidayRate = model.HolidayRate,
                    EmergencySameDayRate = model.EmergencySameDayRate,
                    EmergencyNextDayRate = model.EmergencyNextDayRate,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Technicians.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //This allows us to see what a specific user has added
        public IEnumerable<TechListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Technicians
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TechListItem
                                {
                                    TechId = e.TechId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Location = e.Location,
                                    HourlyRate = e.HourlyRate,
                                    WeekendRate = e.WeekendRate,
                                    AfterHoursRate = e.AfterHoursRate,
                                    HolidayRate = e.HolidayRate,
                                    EmergencySameDayRate = e.EmergencySameDayRate,
                                    EmergencyNextDayRate = e.EmergencyNextDayRate,

                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public TechDetail GetTechById(int techId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Technicians
                        .Single(e => e.TechId == techId && e.OwnerId == _userId);
                return
                    new TechDetail
                    {
                        TechId = entity.TechId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Location = entity.Location,
                        HourlyRate = entity.HourlyRate,
                        WeekendRate = entity.WeekendRate,
                        AfterHoursRate = entity.AfterHoursRate,
                        HolidayRate = entity.HolidayRate,
                        EmergencySameDayRate = entity.EmergencySameDayRate,
                        EmergencyNextDayRate = entity.EmergencyNextDayRate,

                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }
    }
}
