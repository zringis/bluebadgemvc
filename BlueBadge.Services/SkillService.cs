using BlueBadge.Data;
using BlueBadge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class SkillService
    {
        private readonly Guid _userId;

        public SkillService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSkill(SkillCreate model)
        {
            var entity =
                new Skill()
                {
                    OwnerId = _userId,
                    SkillName = model.SkillName,
                    SkillDescription = model.SkillDescription,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Skills.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SkillListItem> GetSkills()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Skills
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SkillListItem
                                {
                                    SkillId = e.SkillId,
                                    SkillName = e.SkillName,
                                    SkillDescription = e.SkillDescription,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }


        public SkillDetail GetSkillById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Skills
                        .Single(e => e.SkillId == noteId && e.OwnerId == _userId);
                return
                    new SkillDetail
                    {
                        SkillId = entity.SkillId,
                        SkillName = entity.SkillName,
                        SkillDescription = entity.SkillDescription,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }


    }


}
