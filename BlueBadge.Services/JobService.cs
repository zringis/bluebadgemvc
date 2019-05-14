using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class JobService
    {

        private readonly Guid _userId;

        public JobService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJob(JobCreate model)
        {
            var entity =
                new Job()
                {
                    OwnerId = _userId,
                    CompanyName = model.CompanyName,
                    JobDescription = model.JobDescription,

                    LocationId = model.LocationId,

                    SkillId = model.SkillId,

                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Jobs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new JobListItem
                                {
                                    JobId = e.JobId,
                                    CompanyName = e.CompanyName,
                                    JobDescription = e.JobDescription,

                                    Skill = e.Skill,
                                    Location = e.Location,

                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public JobDetail GetJobById(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == jobId && e.OwnerId == _userId);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        CompanyName = entity.CompanyName,
                        JobDescription = entity.JobDescription,

                        Location = entity.Location,
                        Skill = entity.Skill,

                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == model.JobId && e.OwnerId == _userId);

                entity.CompanyName = model.CompanyName;
                entity.JobDescription = model.JobDescription;


                entity.LocationId = model.LocationId;
                entity.SkillId = model.SkillId;


                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJob(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Jobs
                        .Single(e => e.JobId == jobId && e.OwnerId == _userId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


        public List<Skill> SkillList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Skills.ToList();
            }
        }
        public List<Location> LocationList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Locations.ToList();

            }
        }

    }
}
