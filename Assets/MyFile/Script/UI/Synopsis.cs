using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Synopsis : MonoBehaviour
{
    [SerializeField]
    private float      speed;
    [SerializeField]
    private GameObject synopsisText;

    private void Start()
    {
        SoundManager.instance.StopMusic();
        SoundManager.instance.PlayMusic(SoundManager.SoundList.PROLOGUE_BGM);
    }

    void Update()
    {
        synopsisText.GetComponent<RectTransform>().anchoredPosition += Vector2.up * speed*Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
            speed *= 2.5f;
        if(Input.GetMouseButtonUp(0))
            speed /= 2.5f;
        if (synopsisText.GetComponent<RectTransform>().anchoredPosition.y > 550)
            MainMenu.NextScene();
    }

}
