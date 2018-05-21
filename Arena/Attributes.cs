using System;
using System.Collections.Generic;

public class Attributes
{
    public Dictionary<string, int> attributes = new Dictionary<string, int>();
    public Attributes() {
        attributes.Add("Strength", 5);
        attributes.Add("Dexterity", 5);
        attributes.Add("Toughness", 5);
        attributes.Add("Charisma", 5);
        attributes.Add("Intellect", 5);
    }
}