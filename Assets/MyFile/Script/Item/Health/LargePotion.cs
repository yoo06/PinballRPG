using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePotion : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "���� ����";
        description = "ü���� ���� ȸ���Ѵ�";
    }

    public override void effect()
    {
            GameManager.instance.player.Hp = 100;
    }
}
