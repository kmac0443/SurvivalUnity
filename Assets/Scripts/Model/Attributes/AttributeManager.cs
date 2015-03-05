using UnityEngine;
using System.Collections;

public class AttributeManager : MonoBehaviour, IDamageAffecting
{
    private int constitution;
    private int strength;
    private int intelligence;
    private int dexterity;

    // Default Constructor
    public AttributeManager()
    {
        this.Constitution = 1;
        this.Strength = 1;
        this.Intelligence = 1;
        this.Dexterity = 1;
    }

    // Specific Constructor
    public AttributeManager(int con, int str, int intel, int dex)
    {
        this.Constitution = con;
        this.Strength = str;
        this.Intelligence = intel;
        this.Dexterity = dex;
    }

    public int Constitution
    {
        get { return this.constitution; }
        set
        {
            if (value >= 0)
            {
                this.constitution = value;
            }
        }
    }

    public int Strength
    {
        get { return this.strength; }
        set
        {
            if (value >= 0)
            {
                this.strength = value;
            }
        }
    }

    public int Intelligence
    {
        get { return this.intelligence; }
        set
        {
            if (value >= 0)
            {
                this.intelligence = value;
            }
        }
    }

    public int Dexterity
    {
        get { return this.dexterity; }
        set
        {
            if (value >= 0)
            {
                this.dexterity = value;
            }
        }
    }

    public int OutgoingDamage()
    {
        //TODO: under review
        return this.Strength + this.Dexterity;
    }

    public int DamageResistance()
    {
        //TODO: under review
        return this.Strength + this.Dexterity;
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
