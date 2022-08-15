using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperPush : MonoBehaviour
{
    [SerializeField]
    private float       pushForce;
    private bool        isBumping;
    private Animator    animator;
    private Rigidbody2D myBody;
    private Vector2     homePosition;

    private void Awake()
    {
        myBody       = GetComponent<Rigidbody2D>();
        homePosition = transform.position;
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();


    }
    private void Update()
    {
        Vector2 tempVec = (homePosition - (Vector2)transform.position) * 2;
        if(GetComponent<Rigidbody2D>() != null)
            myBody.velocity = tempVec;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GetComponent<Animator>() == null)
            {
                if (transform.position.x < 0)
                {
                    SoundManager.instance.PlayMusic(SoundManager.SoundList.PUSH_SOUND);
                    collision.rigidbody.velocity = Vector2.zero;
                    collision.rigidbody.AddForce(new Vector2(1, 0.6f) * pushForce, ForceMode2D.Impulse);
                }
                else
                {
                    SoundManager.instance.PlayMusic(SoundManager.SoundList.PUSH_SOUND);
                    collision.rigidbody.velocity = Vector2.zero;
                    collision.rigidbody.AddForce(new Vector2(-1, 0.6f) * pushForce, ForceMode2D.Impulse);
                }

            }
            else
            {
                if (isBumping == false)
                {
                    SoundManager.instance.PlayMusic(SoundManager.SoundList.PUSH_SOUND);
                    GameManager.instance.Push(gameObject, collision, pushForce);
                    StartCoroutine(BumpingAnimation());
                }
            }
        }
    }

    IEnumerator BumpingAnimation()
    {
        isBumping = true;
        animator.SetTrigger("Bumping");
        yield return new WaitForSeconds(0.2f);
        isBumping = false;
        animator.SetTrigger("Idle");

    }
}
