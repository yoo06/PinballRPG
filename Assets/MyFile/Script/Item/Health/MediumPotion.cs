using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPotion : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "���� ����";
        description = "ü���� 30��ŭ ȸ���Ѵ�";
    }

    public override void effect()
    {
        if (GameManager.instance.player.Hp > 70)
            GameManager.instance.player.Hp = 100;
        else
            GameManager.instance.player.Hp += 30;
    }
}
