using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "����";
        description = "���ݷ��� 2�谡 �ȴ�";
    }

    public override void effect()
    {
        GameManager.instance.player.atk *= 2;
    }
}
