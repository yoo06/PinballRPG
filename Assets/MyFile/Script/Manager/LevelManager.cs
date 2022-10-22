using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public  bool        isBossLevel;
    private bool        isEndingPlayed;
    public  GameObject  Tutorial;
    private static bool isFirstTime = true;
    [TextArea]
    public  string      levelName;
    public  int         enemyTotal;
    private int         enemyleft;
    public  GameObject  targetMonster;

    private void Start()
    {
        if(Tutorial != null)
        {
            Debug.Log("null 아님");
            if (isFirstTime == true)
            {
                Debug.Log("처음임");
                Time.timeScale = 0;
                GameManager.instance.player.GetComponent<Rigidbody2D>().gravityScale = 0;
                Tutorial.SetActive(true);
                isFirstTime = false;
            }
            else
            {
                Debug.Log("처음 아님");
                Tutorial.SetActive(false);
            }
        }
        isEndingPlayed = false;
        StartCoroutine(StageDisplay(levelName));
        SoundManager.instance.StopMusic();
        if(isBossLevel)
            SoundManager.instance.PlayMusic(SoundManager.SoundList.BOSS_BGM);
        else
            SoundManager.instance.PlayMusic(SoundManager.SoundList.STAGE_BGM);

        Monster.count = 0;
        enemyleft = enemyTotal;
    }

    private void Update()
    {
        if(!isBossLevel)
        {
            enemyleft = enemyTotal - Monster.count;
            UIManager.instance.enemyCount.text = "X " + enemyleft.ToString();
            if (enemyleft == 0)
            {
                Debug.Log("스테이지 클리어");
                Monster.count = 0;
                enemyleft = enemyTotal;
                if(isEndingPlayed == false)
                {
                    UIManager.instance.StageClearFunc();
                    isEndingPlayed = true;
                }
            }
        }
        else
        {
            UIManager.instance.enemyCount.text = "X 1";
            if(targetMonster.GetComponent<Monster>().Hp <= 0)
            {
                Debug.Log("보스 클리어");
                Monster.count = 0;
                if (isEndingPlayed == false)
                {
                    UIManager.instance.StageClearFunc();
                    isEndingPlayed = true;
                }
            }
            
        }


    }
    IEnumerator StageDisplay(string name)
    {
        UIManager.instance.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
        UIManager.instance.gameObject.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>().text = name;
        yield return new WaitForSeconds(2f);
        UIManager.instance.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
    }

}
