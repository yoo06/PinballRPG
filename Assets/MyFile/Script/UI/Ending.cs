using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject endingText;

    private void Start()
    {
        GameManager.isEnding = true;
        SoundManager.instance.StopMusic();
        SoundManager.instance.PlayMusic(SoundManager.SoundList.ENDING_BGM);
    }

    void Update()
    {
        endingText.GetComponent<RectTransform>().anchoredPosition += Vector2.up * speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
            speed *= 2.5f;
        if (Input.GetMouseButtonUp(0))
            speed /= 2.5f;
        if (endingText.GetComponent<RectTransform>().anchoredPosition.y > 530)
            GameObject.FindObjectOfType<MainMenu>().SceneMove("MainMenu");
    }
}
