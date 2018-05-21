using Arena;
using System.Collections.Generic;

public class Player
{
    public string name;
    public string Job;
    public string Race;

    public int experience;
    public int level;

    public int health;
    public int weapondamage;
    public int spelldamage;
    public int critchance;
    public int dodgechance;
    public int persuadechance;

    public int Health
    {
        get
        {
            return attributes.attributes["Toughness"] * 2;
        }
    }
    public int Crit
    {
        get
        {
            return attributes.attributes["Dexterity"] * 2;
        }
        set
        {
            critchance = value;
        }
    }
    public int Dodge
    {
        get
        {
            return attributes.attributes["Dexterity"] * 2;
        }
        set
        {
            dodgechance = value;
        }
    }

    public int Persuade
    {
        get
        {
            return attributes.attributes["Charisma"] + skills.skills["Bargain"];
        }
        set
        {
            persuadechance = value;
        }
    }

    public Weapon activeWeapon;
    public Armor activeArmor;

    public string Armor
    {
        get
        {
            if(activeArmor != null) { return activeArmor.Name; }
            else { return "None"; }
        }
    }
    public string Weapon
    {
        get
        {
            if (activeWeapon != null) { return activeWeapon.Name; }
            else { return "Unarmed"; }
        }
    }
    public List<Item> items;
    public Attributes attributes;
    public Skills skills;

    public Dictionary<string, int> currencies = new Dictionary<string, int>();

    public Player()
    {
        this.items = new List<Item>();
        this.attributes = new Attributes();
        this.skills = new Skills();
        this.currencies = new Dictionary<string, int>();
        currencies.Add("Copper", 10);
        currencies.Add("Silver", 0);
        currencies.Add("Gold", 0);
    }

    public void Instantiate()
    {

        this.experience = 0;
        this.level = 1;
        this.health = Health;
        this.weapondamage = GetWeaponDamage();
        this.spelldamage = GetSpellDamage();
        this.critchance = Crit;
        this.dodgechance = Dodge;
        this.persuadechance = Persuade;


    }
    public int GetWeaponDamage()
    {
        if(activeWeapon != null)
        {
            return activeWeapon.Damage() + attributes.attributes["Strength"];
        }
        else
        {
            return attributes.attributes["Strength"];
        }
    }
    public int GetArmorAbsorb()
    {
        if (activeArmor != null)
        {
            return activeArmor.Absorb();
        }
        else
        {
            return 0;
        }
    }
    public int GetSpellDamage()
    {
        return attributes.attributes["Intellect"];
    }
}
