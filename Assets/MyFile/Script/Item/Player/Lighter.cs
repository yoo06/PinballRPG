using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "�Ź�";
        description = "���� ��������\n���Ϳ��� �� �з�����";
    }

    public override void effect()
    {
        Monster.pushForce = 7f;
    }
}
