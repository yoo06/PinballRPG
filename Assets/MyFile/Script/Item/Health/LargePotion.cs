using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePotion : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "대형 포션";
        description = "체력을 전부 회복한다";
    }

    public override void effect()
    {
            GameManager.instance.player.Hp = 100;
    }
}
