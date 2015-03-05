using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour, IDamageAffecting
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

    //////////////////////
    /// Unity Specific ///
    ////////////////////// 
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

}
