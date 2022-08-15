using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotion : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "���� ����";
        description = "ü���� 10��ŭ ȸ���Ѵ�";
    }

    public override void effect()
    {
        if(GameManager.instance.player.Hp > 90)
            GameManager.instance.player.Hp = 100;
        else
            GameManager.instance.player.Hp += 10;
    }
}
