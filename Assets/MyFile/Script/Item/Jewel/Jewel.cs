using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : Item
{
    private void Awake()
    {
        isGood = false;
        itemName = "보석";
        description = "아름다운 보석이지만\n모험에는 쓸모가 없다";
    }

    public override void effect()
    {
    }
}
