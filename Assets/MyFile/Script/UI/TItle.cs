using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TItle : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }
    private void OnEnable()
    {
        transform.position = startPosition;
        StartCoroutine(TitleMove());
    }

    IEnumerator TitleMove()
    {
        for(int i = 0; i < 120; i++)
        {
            if(gameObject.name == "TITLE")
            {
                transform.position -= Vector3.up*10;
                yield return new WaitForSeconds(speed*Time.deltaTime);
            }
            else
            {
                transform.position += Vector3.up * 10;
                yield return new WaitForSeconds(speed * Time.deltaTime);
            }

        }
    }
}
