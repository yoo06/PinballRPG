using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scull : Item
{
    private void Awake()
    {
        isGood = false;
        itemName = "함정";
        description = "해골은 피해야죠?\n체력을 20만큼 잃는다";
    }

    public override void effect()
    {
        if (GameManager.instance.player.Hp < 20)
            GameManager.instance.player.Hp = 1;
        else
            GameManager.instance.player.Hp -= 20;
    }
}
