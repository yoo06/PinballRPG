using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "신발";
        description = "몸이 가벼워져\n몬스터에게 더 밀려난다";
    }

    public override void effect()
    {
        Monster.pushForce = 7f;
    }
}
