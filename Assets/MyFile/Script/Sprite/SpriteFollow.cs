using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollow : MonoBehaviour
{
    public Transform character;
    void Update()
    {
        transform.position = character.position;
    }
}
