using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFlipManager : MonoBehaviour
{
    private int  leftEffect = 4;
    private int rightEffect = 5;
    public void PowerFlipFunc(int num)
    {
        StartCoroutine(PowerFlipCo(num));
        StartCoroutine(PowerFlipEffect(num));
    }
    public IEnumerator PowerFlipCo(int num)
    {
        PowerFlip.isCoolTime = false;
        transform.GetChild(num).gameObject.SetActive(true);
        yield return new WaitForSeconds(num * 1.2f);
        transform.GetChild(num).gameObject.SetActive(false);
    }

    public IEnumerator PowerFlipEffect(int num)
    {
        if(num >= 1)
        {
            transform.GetChild( leftEffect).GetComponent<SpriteRenderer>().color = GameManager.instance.colorDictionary[GameManager.instance.player.comboLevel];
            transform.GetChild(rightEffect).GetComponent<SpriteRenderer>().color = GameManager.instance.colorDictionary[GameManager.instance.player.comboLevel];

            SoundManager.instance.PlayMusic(SoundManager.SoundList.FLIP_SOUND_ONE + (num-1));
            transform.GetChild( leftEffect).gameObject.SetActive(true);
            transform.GetChild(rightEffect).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            transform.GetChild( leftEffect).gameObject.SetActive(false);
            transform.GetChild(rightEffect).gameObject.SetActive(false);

        }
    }
}
