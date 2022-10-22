using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string  itemName;
    public string  description;
    protected bool isGood;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isGood) SoundManager.instance.PlayMusic(SoundManager.SoundList.ACHIEVEMENT_SOUND);
            else SoundManager.instance.PlayMusic(SoundManager.SoundList.LOSE_SOUND);
            effect();
            gameObject.SetActive(false);
        }
    }

    public virtual void effect() { }


}
