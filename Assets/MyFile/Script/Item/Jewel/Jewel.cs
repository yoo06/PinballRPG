using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : Item
{
    private void Awake()
    {
        isGood = false;
        itemName = "����";
        description = "�Ƹ��ٿ� ����������\n���迡�� ���� ����";
    }

    public override void effect()
    {
    }
}
