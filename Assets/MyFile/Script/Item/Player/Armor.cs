using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    private void Awake()
    {
        isGood = true;
        itemName = "°©¿Ê";
        description = "µÎ²¨¿î °©¿ÊÀ» ÀÔ¾î\n°¡½Ã¿¡ µ¥¹ÌÁö¸¦ ´ú ¹Þ´Â´Ù";
    }

    public override void effect()
    {
        Thorn.thornDamage /= 2;
    }
}
