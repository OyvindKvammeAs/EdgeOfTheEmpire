using EdgeOfTheEmpire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Services
{
    public interface IStaticDataRepository
    {
        IList<Career> GetCarreers();
        IList<Specialization> GetSpecializations();
        IList<Talent> GetTalents();
        IList<Skill> GetSkills();
        IList<TalentTree> GetTalentTrees();

        Career GetCareer(string name);

        
        Specialization GetSpecialization(string specializationName);
        IList<Skill> GetCareerSkills(Career career);

        IList<Skill> GetSpecializationSkills(Specialization specialization);
        TalentTree GetSpecializationTalentTree(Specialization specialization);
        IList<Specialization> GetSpecializationsWithTalent(Talent talent);
        IEnumerable<Specialization> GetCareerSpecializations(Career theCareer);

        Talent GetTalent(string talentName);
        Skill GetSkill(string skillName);

        IList<Specialization> GetSpecializationsWithSkill(Skill skill);
        IList<Career> GetCareersWithSkill(Skill skill);
    }
}
