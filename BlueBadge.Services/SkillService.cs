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

        public bool CreateSkill(SkillCreate model)
        {
            var entity =
                new Skill()
                {
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
                        .Single(e => e.SkillId == noteId);
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


        public bool UpdateSkill(SkillEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Skills
                        .Single(e => e.SkillId == model.SkillId);

                entity.SkillId = model.SkillId;
                entity.SkillName = model.SkillName;
                entity.SkillDescription = model.SkillDescription;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSkill(int skillId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Skills
                        .Single(e => e.SkillId == skillId);

                ctx.Skills.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }




        //For The DB

        public bool SkillsExist()
        {
            using (var ctx = new ApplicationDbContext())
            {
                if(ctx.Skills.Count<Skill>() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        

    }


}
