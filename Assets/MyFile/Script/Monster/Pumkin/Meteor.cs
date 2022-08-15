using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private float speed;
    private int damage;

    private void Awake()
    {
        damage = FindObjectOfType<Pumking>().atk;
        speed = 3.5f * Time.deltaTime;
    }
    void Update()
    {
        transform.position += new Vector3(1, -1, 0) * speed;
    }
    private void OnEnable()
    {
        transform.position += new Vector3(-4f, 4f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)GameManager.Layer.PLAYER)
            GameManager.instance.PlayerDamageFunc(damage);
    }
}
