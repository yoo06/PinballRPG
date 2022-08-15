using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isOptionOpen;
    [SerializeField]
    private CanvasGroup sound;
    [SerializeField]
    private CanvasGroup main;

    public void Start()
    {
        SoundManager.instance.StopMusic();
        SoundManager.instance.PlayMusic(SoundManager.SoundList.MAIN_BGM);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isOptionOpen == false)
            {
                OpenCanvas(sound);
                CloseCanvas(main);
                ClickSound();
                isOptionOpen = true;
            }
            else
            {
                OpenCanvas(main);
                CloseCanvas(sound);
                ClickSound();
                isOptionOpen = false;
            }
        }
    }

    public static void NextScene()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.gameObject.SetActive(false);
        }
        if (UIManager.instance != null)
        {
            UIManager.instance.gameObject.SetActive(false);
        }

        Time.timeScale = 1;
        SoundManager.instance.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void SceneMove(string sceneName)
    {
        StopAllCoroutines();
        if (GameManager.instance != null)
        {
                GameManager.instance.gameObject.SetActive(false);
        }
        if (UIManager.instance != null)
        {
                UIManager.instance.gameObject.SetActive(false);
        }

        Time.timeScale = 1;
        SoundManager.instance.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        SceneManager.LoadScene(sceneName);
        if(sceneName == "MainMenu")
        {
            SoundManager.instance.StopMusic();
            if (GameManager.isEnding == false) SoundManager.instance.PlayMusic(SoundManager.SoundList.MAIN_BGM);
            else                               SoundManager.instance.PlayMusic(SoundManager.SoundList.ENDING_BGM);

        }
    }
    public void OpenCanvas(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable   = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void CloseCanvas(CanvasGroup canvasGroup)
    {
        Time.timeScale = 1;
        canvasGroup.alpha          = 0;
        canvasGroup.interactable   = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void ClickSound()
    {
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
    }

    public void Quit()
    {
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        Application.Quit();
    }
}
