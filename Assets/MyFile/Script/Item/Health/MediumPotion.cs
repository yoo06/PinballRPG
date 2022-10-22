using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPotion : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "중형 포션";
        description = "체력을 30만큼 회복한다";
    }

    public override void effect()
    {
        if (GameManager.instance.player.Hp > 70)
            GameManager.instance.player.Hp = 100;
        else
            GameManager.instance.player.Hp += 30;
    }
}
