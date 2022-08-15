using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{
    private float speed;
    private int   damage;
    private bool  isCoolTime = false;

    private void Awake()
    {
        damage = FindObjectOfType<Pumking>().atk;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(FlameAttack(collision));
    }

    IEnumerator FlameAttack(Collider2D collision)
    {
        if (isCoolTime == false)
        {
            if (collision.GetComponent<Player>() != null)
            {
                isCoolTime = true;
                GameManager.instance.PlayerDamageFunc(damage);
                yield return new WaitForSeconds(0.25f);
                isCoolTime = false;
            }
        }
    }
}
