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
                    JobLocation = model.JobLocation,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobListItem> GetNotes()
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
                                    JobLocation = e.JobLocation,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }


    }
}
