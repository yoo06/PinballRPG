using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "����";
        description = "�β��� ������ �Ծ�\n���ÿ� �������� �� �޴´�";
    }

    public override void effect()
    {
        Thorn.thornDamage /= 2;
    }
}
