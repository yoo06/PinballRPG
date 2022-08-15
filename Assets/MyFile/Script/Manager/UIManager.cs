using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager        instance = null;
    public        TextMeshProUGUI  comboText;
    public        Image            healthColor;
    public        Slider           healthSlider;
    public        Text             enemyCount;
    private       GameObject       pauseUI;
    private       CanvasGroup      pauseCanvasGroup;
    private       GameObject       gameOverUI;
    private       CanvasGroup      gameOverCanvasGroup;
    private       bool             isOptionOpen;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            UIManager.instance.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        pauseUI = SoundManager.instance.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        pauseCanvasGroup = pauseUI.GetComponent<CanvasGroup>();

        gameOverUI = transform.GetChild(0).GetChild(1).gameObject;
        gameOverCanvasGroup = gameOverUI.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOptionOpen == false)
            {
                OpenPause();
                isOptionOpen = true;
            }
            else
            {
                ClosePause();
                isOptionOpen = false;
            }
        }
    }


    public void ComboUpFunc()
    {
        StartCoroutine(ComboUp());
    }

    public IEnumerator ComboUp()
    {
        comboText.faceColor = Color.yellow;
        comboText.outlineColor = new Color32(255, 255, 255, 255);
        comboText.text = GameManager.instance.player.Combo.ToString();
        comboText.transform.position += new Vector3(0, 10, 0);
        yield return new WaitForSeconds(0.1f);
        comboText.outlineColor = new Color32(0, 0, 0, 255);
        comboText.transform.position -= new Vector3(0, 10, 0);
    }


    //장면 전환
    public void OpenPause()
    {
        Time.timeScale = 0;
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        pauseCanvasGroup.alpha             = 1;
        pauseCanvasGroup.interactable      = true;
        pauseCanvasGroup.blocksRaycasts    = true;
    }
    public void ClosePause()
    {
        Time.timeScale = 1;
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        pauseCanvasGroup.alpha = 0;
        pauseCanvasGroup.interactable = false;
        pauseCanvasGroup.blocksRaycasts = false;
    }



    public void GameOverScene()
    {
        Time.timeScale = 0;
        gameOverCanvasGroup.alpha          = 1;
        gameOverCanvasGroup.interactable   = true;
        gameOverCanvasGroup.blocksRaycasts = true;
    }
    public void CloseScene()
    {
        Time.timeScale = 1;
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        gameOverCanvasGroup.alpha          = 0;
        gameOverCanvasGroup.interactable   = false;
        gameOverCanvasGroup.blocksRaycasts = false;
    }

    public void StageClearFunc()
    {
        StartCoroutine(StageClear());
    }

    IEnumerator StageClear()
    {
        bool isPlayed = false;
        if(isPlayed == false)
        {
            Player.isInvincible = true;
            SoundManager.instance.PlayMusic(SoundManager.SoundList.WIN_SOUND);
            transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            MainMenu.NextScene();

        }
    }
}
