using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] private int level, exp;
    [SerializeField] private Spell[] spells;

    private void Start()
    {
        spells[0] = new Spell("Arcane Blast", 0, 3, Spell.Element.arcane);
        spells[1] = new Spell("Fireball", 1, 5, Spell.Element.fire);
        spells[2] = new Spell("Ice Shard", 2, 15, Spell.Element.ice);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSpell();
        }
    }

    private void UseSpell()
    {
        foreach (var spell in spells)
        {
            if (spell.levelReq == level)
            {
                spell.CastSpell();
                exp += spell.expGain;
                LevelUpCheck();
            }
        }
    }

    private void LevelUpCheck()
    {
        if (exp >= 25 + (50 * level))
        {
            level++;
            exp = 0;
        }
    }
}