using System;
using System.Collections.Generic;

namespace Model.ModelObjects.Attributes
{
    public class SkillManager : IDamageAffecting
    {
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }
        
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
            OnChanged(EventArgs.Empty);
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
