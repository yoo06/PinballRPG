using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 location;
    public int hp;
    public int atk;
    public int Hp
    {
        get { return hp; }
        set 
        { 
            hp = value;
            if (hp <= 0)
                Debug.Log("Game Over");
        }
    }

    private void Update()
    {
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Flipper")
        {
            Debug.Log("flipper");
            Debug.Log(transform.position - transform.parent.transform.position);
            location = transform.position - transform.parent.transform.position - new Vector3(collision.contacts[0].normal.x, collision.contacts[0].normal.y, 0);
            Debug.DrawRay(transform.position, -location, Color.blue, 0.1f);
        }
    }
}
