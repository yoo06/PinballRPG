using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private int pageNumber = 0;
    [SerializeField]
    private Button leftButton;
    private void Update()
    {
        if (pageNumber == 0)
        {
            leftButton.interactable = false;
            
        }
        else
        {
            leftButton.interactable = true;

        }
    }

    public void LeftButtonClick()
    {
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        if (transform.GetChild(pageNumber - 1) != null)
        {
            transform.GetChild(pageNumber).gameObject.SetActive(false);
            pageNumber--;
        }
    }

    public void RightButtonClick()
    {
        SoundManager.instance.PlayMusic(SoundManager.SoundList.CLICK_SOUND);
        if(pageNumber < 2)
        {
            transform.GetChild(pageNumber + 1).gameObject.SetActive(true);
            pageNumber++;
        }
        else
        {
            gameObject.SetActive(false);
            GameManager.instance.player.GetComponent<Rigidbody2D>().gravityScale = 1;
            Time.timeScale = 1;
        }
    }



}
