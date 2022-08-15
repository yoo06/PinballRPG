using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{
    private float speed;
    private int   damage;

    private void Awake()
    {
        damage = FindObjectOfType<SlimeKing>().atk;
        speed  = 3 * Time.deltaTime;
    }
    void Update()
    {
        transform.position += Vector3.down*speed;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
             if (collision.gameObject.layer == (int)GameManager.Layer.PLAYER)
        {
            GameManager.instance.PlayerDamageFunc(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == (int)GameManager.Layer.ENEMY)
        {

        }
        else
            Destroy(gameObject);

    }
}
