using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public  Transform   target;
    public  float       lerpSpeed = 1.0f;
    private Vector3     offset;
    private Vector3     targetPos;
    [SerializeField]
    private GameObject  bonusRound;
    public  GameObject  beforeShootText;
    public  static bool isReady = false;
    private IEnumerator bonusRoundShow;


    private void Start()
    {
        isReady = false;
        bonusRoundShow = BonusRoundShow();
        StartCoroutine(bonusRoundShow);
    }

    private void Update()
    {
        if (isReady)
        {
            targetPos          = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, targetPos.y, -30), lerpSpeed * Time.deltaTime);
            if(Input.GetMouseButtonDown(0))
                beforeShootText.SetActive(false);
        }

    }
    private IEnumerator BonusRoundShow()
    {
        Debug.Log("2초전");
        transform.position = new Vector3(0, -60, -30);
        yield return new WaitForSeconds(2f);
        Debug.Log("2초후");
        bonusRound.SetActive(false);
        yield return StartCoroutine(CameraDisplay());
    }


    private IEnumerator CameraDisplay()
    {

        for (int i = 0; i < 450; i++)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0,2,-10), lerpSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        offset = transform.position - target.position;
        
        isReady = true;
        beforeShootText.SetActive(true);
    }
}

