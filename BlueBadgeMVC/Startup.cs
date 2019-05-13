using System;
using BlueBadge.Data;
using BlueBadge.Services;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueBadgeMVC.Startup))]
namespace BlueBadgeMVC
{
    public partial class Startup
    {


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CheckSkillsTable();
        }

        private void CheckLocationTable()
        {
            LocationServices locationService = new LocationServices();
            ApplicationDbContext context = new ApplicationDbContext();

            if (!locationService.LocationsExist())
            {
                Location location = new Location();
                location.LocationState = "Indiana";
                location.LocationCity = "Indianapolis";
                context.Locations.Add(location);
                context.SaveChanges();
            }

        }

        private void CheckSkillsTable()
        {
            SkillService skillService = new SkillService();

            ApplicationDbContext context = new ApplicationDbContext();

            if (!skillService.SkillsExist())
            {
                Skill skill = new Skill();
                skill.SkillName = "Network Installation";
                skill.SkillDescription = "Specializations can include POS, ATM, KIOSKS, Digital Media, and Audio Systems. Primary responsibilities are installling computer networks such as local area networks (LANs), wide area networks (WANs), the Internet, intranets, and other data communications systems. Install server hardware and software infrastructure. Set up user accounts and passwords. Monitor network usage and security.";
                context.Skills.Add(skill);

                Skill skill2 = new Skill();
                skill2.SkillName = "Enterprise Wireless Specialist";
                skill2.SkillDescription = "IOT Solutions, Internet Failover Solutions, Managed Wi-Fi and Business Analytics Specialization.";
                context.Skills.Add(skill2);

                Skill skill3 = new Skill();
                skill3.SkillName = "Electronic Security Specialist";
                skill3.SkillDescription = "Internet security specialists, also known as information security analysts, ensure the safety of a company's information by monitoring an organization's computer and networks systems and guarding them against cyber attacks.";
                context.Skills.Add(skill3);

                Skill skill5 = new Skill();
                skill5.SkillName = "Network Infrastructure Specialist";
                skill5.SkillDescription = "Responsible for the operations of secure and highly available computing platforms, servers, and networks. ... They also provide infrastructure solutions based on application needs and anticipated growth, install new servers and maintain the infrastructure.";
                context.Skills.Add(skill5);

                Skill skill6 = new Skill();
                skill6.SkillName = "Help Desk";
                skill6.SkillDescription = "Availability to help with any IT related issues.";
                context.Skills.Add(skill6);

                Skill skill7 = new Skill();
                skill7.SkillName = "Cloud Management";
                skill7.SkillDescription = "Help create, deliver and maintain cloud operations team strategy and roadmap. Will maintain a change management process that follows ITIL best practices and associated requirements. The Cloud Operations Specialist will manage groups of functions within Cloud Operations.";
                context.Skills.Add(skill7);

                Skill skill8 = new Skill();
                skill8.SkillName = "Network Operator";
                skill8.SkillDescription = "Ability to assist in a production operations environment that includes multiple servers and networking equipment. The operator is responsible for testing and implementation of new network and wireless service.";
                context.Skills.Add(skill8);

                Skill skill10 = new Skill();
                skill10.SkillName = "Consulting";
                skill10.SkillDescription = "IT consultants, also known as technology consultants, are contracted to work with industrial and commercial clients who are seeking help and advice about business and IT problems. A typical project involves: consulting staff from different parts of a client's organisation. analysing an organisation's data.";
                context.Skills.Add(skill10);

                Skill skill11 = new Skill();
                skill11.SkillName = "IT Support";
                skill11.SkillDescription = "IT technical support officers monitor and maintain the computer systems and networks of an organisation. You could be installing and configuring computer systems, diagnosing hardware and software faults and solve technical and applications problems, either over the phone or in person. ... applications support specialist.";
                context.Skills.Add(skill11);

                Skill skill1 = new Skill();
                skill1.SkillName = "Cable Pulling";
                skill1.SkillDescription = "The job of a cable puller involves an individual pulling lead-sheathed cables through walls and ducts for electrical power systems. They will push and pull these cables through given spaces, as well as joining them together.";
                context.Skills.Add(skill1);
                context.SaveChanges();
            }

        }
    }
}
