using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "무기";
        description = "공격력이 2배가 된다";
    }

    public override void effect()
    {
        GameManager.instance.player.atk *= 2;
    }
}
