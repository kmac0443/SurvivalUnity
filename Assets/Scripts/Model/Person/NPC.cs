using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NPC : Person
{
    private List<string> dialogue;
    private System.Random rand;
    private int health;

    public NPC()
    {
        this.dialogue = new List<string>();
        this.rand = new System.Random();
        this.health = 10;
    }

    public override int DealDamage()
    {
        int damage = 0;
        damage += base.inventory.OutgoingDamage();
        return damage;
    }

    public override void ReceiveDamage(int damage)
    {
        int damageAfterResistance = damage;
        damageAfterResistance -= base.inventory.DamageResistance();

        if (damageAfterResistance < 0)
        {
            damageAfterResistance = 0;
        }
        this.health -= damageAfterResistance;
        if (this.health < 0)
        {
            this.health = 0;
        }
    }

    public string Speak()
    {
        if (dialogue.Count == 0)
        {
            return "Hello World";
        }
        int randomIndex = rand.Next(this.dialogue.Count);
        return dialogue[randomIndex];
    }

    public List<string> getDialogue()
    {
        return this.dialogue;
    }

    public void setDialogue(List<string> phrases)
    {
        this.dialogue = phrases;
    }
}
