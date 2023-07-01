using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell
{
    public string name;
    public int levelReq, expGain;
    public enum Element { arcane, fire, water, earth, ice }
    public Element magicElement;

    public Spell(string name, int levelReq, int expGain, Element element)
    {
        this.name = name;
        this.levelReq = levelReq;
        this.expGain = expGain;
        this.magicElement = element;
    }

    public void CastSpell()
    {
        Debug.Log("Casting spell: " + this.name);
    }
}
