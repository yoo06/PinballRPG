using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.isEnding == true)
            transform.GetChild(0).gameObject.SetActive(true);
    }

}
