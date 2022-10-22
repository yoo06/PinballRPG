using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    [SerializeField] 
    private float thornPushForce;
    public static int thornDamage;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("가시 충돌");
        GameManager.instance.player.Combo = 0;
        collision.rigidbody.AddForce(Vector3.up * thornPushForce, ForceMode2D.Impulse);
        StartCoroutine(GameManager.instance.PlayerDamage(thornDamage));
    }

}
