using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPosition : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector3(-2,0,0);
    }
}
