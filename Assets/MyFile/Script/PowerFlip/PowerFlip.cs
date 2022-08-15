using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFlip : MonoBehaviour
{
    [SerializeField]
    private float       spinSpeed;
    public  static bool isCoolTime = false;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * spinSpeed * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(FlipAttack(collision));
    }
    IEnumerator FlipAttack(Collider2D collision)
    {
        if (isCoolTime == false)
        {
            if (collision.GetComponent<Monster>() != null)
            {
                isCoolTime = true;
                Debug.Log("파워플립 공격");
                SoundManager.instance.PlayMusic(SoundManager.SoundList.HIT_SOUND);
                GameManager.instance.player.Combo++;
                collision.GetComponent<Monster>().Hp -= 1 * GameManager.instance.player.atk;
                yield return new WaitForSeconds(0.45f);
                isCoolTime = false;
            }
        }
    }
}
