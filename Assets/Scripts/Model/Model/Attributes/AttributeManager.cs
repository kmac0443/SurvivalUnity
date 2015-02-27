﻿using System;
using System.Collections.Generic;

namespace Model.ModelObjects.Attributes
{
    public class AttributeManager : IDamageAffecting
    {
        public event ChangedEventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }
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
                    OnChanged(EventArgs.Empty);
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
                    OnChanged(EventArgs.Empty);
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
                    OnChanged(EventArgs.Empty);
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
                    OnChanged(EventArgs.Empty);
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

        public string Info()
        {
            System.Text.StringBuilder toString = new System.Text.StringBuilder();
            toString.Append("Attributes:\n");
            toString.Append("Const: " + constitution + "\n");
            toString.Append("Stren: " + strength + "\n");
            toString.Append("Intel: " + intelligence + "\n");
            toString.Append("Dexte: " + dexterity + "\n");
            return toString.ToString();
        }


    }
}
