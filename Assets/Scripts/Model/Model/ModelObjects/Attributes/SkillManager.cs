using System;
using System.Collections.Generic;

namespace ModelRepresentation.ModelObjects.Attributes
{
    class SkillManager : IDamageAffecting
    {
        private List<Skill> skills;

        public SkillManager()
        {
            this.skills = new List<Skill>();
        }

        public void AddSkill(Skill skill)
        {
            //No Duplicates
            foreach (Skill s in this.skills)
            {
                if (s.ID == skill.ID)
                {
                    return;
                }
            }
            skills.Add(skill);
        }

        public int OutgoingDamage()
        {
            //TODO
            return 0;
        }

        public int DamageResistance()
        {
            //TODO
            return 0;
        }
    }
}
