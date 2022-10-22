using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance=null;

    [SerializeField]
    private Texture2D   mouseImage;
    public  AudioClip[] audioClip = new AudioClip[0];
    private AudioSource audioSource;
    public  Slider      soundSlider;
    private bool isFullScreen;
    [SerializeField]
    private GameObject check;

    public enum SoundList
    {
        MAIN_BGM,
        STAGE_BGM,
        BOSS_BGM,
        HIT_SOUND,
        ACHIEVEMENT_SOUND,
        WIN_SOUND,
        LOSE_SOUND,
        CLICK_SOUND,
        NONE,
        FLIP_SOUND_ONE,
        FLIP_SOUND_TWO,
        FLIP_SOUND_THREE,
        PUMKINKING_FIRE,
        PUMKINKING_METEOR,
        PLAYER_HIT,
        BONUS_STAGE_BGM,
        PROLOGUE_BGM,
        PUSH_SOUND,
        ENDING_BGM,
    }

    private void Awake()
    {
        
        if (instance == null)
            instance = this;
        else
        {
            SoundManager.instance.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        Cursor.SetCursor(mouseImage, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Start()
    {
        Screen.SetResolution(608, 1080, false);
    }

    public void FullScreen()
    {
        if (isFullScreen == false)
        {
            Screen.SetResolution(608, 1080, true);
            check.SetActive(true);
            isFullScreen = true;
        }
        else
        {
            Screen.SetResolution(608, 1080, false);
            check.SetActive(false);
            isFullScreen = false;
        }
    }


    private void Update()
    {
        audioSource.volume = soundSlider.value / 10f;   
    }

    public void PlayMusic(SoundList number)
    {
        audioSource.PlayOneShot(audioClip[(int)number], audioSource.volume);
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
}
