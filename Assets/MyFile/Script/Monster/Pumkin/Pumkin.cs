using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumkin : Monster
{

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animationLength = this.GetAnimLength("Die");

    }
    private void Start()
    {
        StartCoroutine(Idle());
    }
    public override int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                if (isCounted == false)
                {
                    isCounted = true;
                    StopAllCoroutines();
                    StartCoroutine(Die(animationLength*1.25f));
                    count++;
                }
            }
        }
    }


    IEnumerator Pattern()
    {
        int num = Random.Range(0, 2);
        switch (num)
        {
            case 0:
                StartCoroutine(Idle());
                break;
            case 1:
                StartCoroutine(Move());
                break;
        }
        yield return null;
    }

    IEnumerator Idle()
    {
        animator.SetTrigger("Idle");
        yield return null;
        StartCoroutine(Pattern());
    }

    IEnumerator Move()
    {

        int rand = Random.Range(0, 5);
        animator.SetTrigger("Move");
        yield return new WaitForSeconds(rand);
        StartCoroutine(Pattern());
    }
}
