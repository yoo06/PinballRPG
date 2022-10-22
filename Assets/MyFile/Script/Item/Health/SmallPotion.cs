using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotion : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "소형 포션";
        description = "체력을 10만큼 회복한다";
    }

    public override void effect()
    {
        if(GameManager.instance.player.Hp > 90)
            GameManager.instance.player.Hp = 100;
        else
            GameManager.instance.player.Hp += 10;
    }
}
