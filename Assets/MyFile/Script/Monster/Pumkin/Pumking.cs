using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pumking : Monster
{
    public  int        atk;
    private GameObject meteor;
    private GameObject flame;

    [Header("UI")]
    [SerializeField]
    private Slider     slider;
    [SerializeField]
    private GameObject skillUi;
    [SerializeField]
    private Text       skillText;

    public override int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            slider.value = hp;
            Debug.Log(gameObject.name + " " + hp);

            if (hp <= 0)
            {
                if (isCounted == false)
                {
                    isCounted = true;
                    StopAllCoroutines();
                    StartCoroutine(Die(this.animationLength));
                    count++;
                }
            }
        }
    }

    private void Awake()
    {
        meteor          = transform.GetChild(0).gameObject;
        flame           = transform.GetChild(1).gameObject;
        animator        = GetComponent<Animator>();

        animationLength = this.GetAnimLength("Die");

        StartCoroutine(Idle());
    }



    IEnumerator Pattern()
    {
        int num = Random.Range(0, 3);

        switch (num)
        {
            case 0:
                StartCoroutine(Meteor());
                break;
            case 1:
                StartCoroutine(Shoot());
                break;
            case 2:
                StartCoroutine(Move());
                break;
        }
        yield return null;
    }

    IEnumerator Idle()
    {
        animator.SetTrigger("Idle");
        yield return new WaitForSeconds(3f);
        StartCoroutine(Pattern());
    }

    IEnumerator Meteor()
    {
        animator.SetTrigger("Attack");
        StartCoroutine(SkillDisplay(3f, "메테오"));
        yield return new WaitForSeconds(1.5f);
        SoundManager.instance.PlayMusic(SoundManager.SoundList.PUMKINKING_METEOR);
        meteor.SetActive(true);
        meteor.transform.position = new Vector3(-2, 0, 0);
        yield return new WaitForSeconds(1.5f);
        meteor.SetActive(false);

        yield return new WaitForSeconds(3f);

        StartCoroutine(Idle());
    }

    IEnumerator Shoot()
    {
        animator.SetTrigger("Attack");
        StartCoroutine(SkillDisplay(3f, "지옥불"));
        flame.SetActive(true);
        SoundManager.instance.PlayMusic(SoundManager.SoundList.PUMKINKING_FIRE);
        flame.transform.position = transform.position + Vector3.down*5;
        yield return new WaitForSeconds(2f);
        flame.SetActive(false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Idle());
    }

    IEnumerator Move()
    {
        if(transform.position.x > 1)
        {
            Debug.Log("왼쪽이동");
            for(int i = 0; i < 20; i++)
            {
                transform.position += Vector3.left * 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else if(transform.position.x < -1)
        {
            Debug.Log("오른쪽이동");
            for (int i = 0; i < 20; i++)
            {
                transform.position += Vector3.right * 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            int rand = Random.Range(0, 2);
            Debug.Log("random"+rand);
            if(rand == 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    transform.position += Vector3.left * 0.1f;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    transform.position += Vector3.right * 0.1f;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }

        Debug.Log("이동 실행");
        StartCoroutine(Idle());
    }

    private IEnumerator SkillDisplay(float time, string text)
    {
        skillUi.SetActive(true);
        skillText.text = text;
        yield return new WaitForSeconds(time);
        skillUi.SetActive(false);
    }
}
