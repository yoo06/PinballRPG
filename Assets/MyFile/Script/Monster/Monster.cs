using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    protected int          hp;
    public    static int   count;   
    public    static float pushForce;
    protected Animator     animator;
    protected float        animationLength;
    protected bool         isCounted = false;


    private void Awake()
    {
        animationLength = this.GetAnimLength("Die");
        animator = GetComponent<Animator>();
    }
    public virtual int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                if(isCounted == false)
                {
                    isCounted = true;
                    StopAllCoroutines();
                    StartCoroutine(Die(animationLength));
                    count++;
                }
            }
        }
    }
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.Push(gameObject, collision, pushForce);
        Hp -= 1 * GameManager.instance.player.atk;
    }

    public IEnumerator Die(float length)
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(length);
        gameObject.SetActive(false);
    }


    public float GetAnimLength(string animName)
    {
        float time = 0;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;

        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == animName)
            {
                time = ac.animationClips[i].length;
            }
        }

        return time;
    }


}
