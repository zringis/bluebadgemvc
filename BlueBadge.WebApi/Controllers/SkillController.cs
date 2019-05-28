using BlueBadge.Models;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadge.WebApi.Controllers
{
    [Authorize]
    public class SkillController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            SkillService skillService = CreateSkillService();
            var skills = skillService.GetSkills();
            return Ok(skills);
        }

        public IHttpActionResult Get(int id)
        {
            SkillService skillService = CreateSkillService();
            var skill = skillService.GetSkillById(id);
            return Ok(skill);
        }

        public IHttpActionResult Post(SkillCreate skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSkillService();

            if (!service.CreateSkill(skill))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SkillEdit skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSkillService();

            if (!service.UpdateSkill(skill))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSkillService();

            if (!service.DeleteSkill(id))
                return InternalServerError();

            return Ok();
        }

        private SkillService CreateSkillService()
        {
            var skillService = new SkillService();
            return skillService;
        }
    }
}
