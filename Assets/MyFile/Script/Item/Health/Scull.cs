using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scull : Item
{
    private void Awake()
    {
        isGood = false;
        itemName = "����";
        description = "�ذ��� ���ؾ���?\nü���� 20��ŭ �Ҵ´�";
    }

    public override void effect()
    {
        if (GameManager.instance.player.Hp < 20)
            GameManager.instance.player.Hp = 1;
        else
            GameManager.instance.player.Hp -= 20;
    }
}
