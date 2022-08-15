using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeKing : Monster
{ 
    public int         atk;
    [Header("Components")] 
    public  GameObject slime;
    public  GameObject ball;
    private bool       isSummonAble;
    
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
        isSummonAble = false;
        animator     = GetComponent<Animator>();

        animationLength = this.GetAnimLength("Die");
        
        StartCoroutine(Idle());

        Instantiate(slime, new Vector3(transform.position.x    , transform.position.y - 3, 0), transform.rotation, transform);
        Instantiate(slime, new Vector3(transform.position.x + 2, transform.position.y - 2, 0), transform.rotation, transform);
        Instantiate(slime, new Vector3(transform.position.x - 3, transform.position.y    , 0), transform.rotation, transform);
        Instantiate(slime, new Vector3(transform.position.x + 3, transform.position.y    , 0), transform.rotation, transform);
        Instantiate(slime, new Vector3(transform.position.x - 2, transform.position.y + 2, 0), transform.rotation, transform);
        Instantiate(slime, new Vector3(transform.position.x    , transform.position.y + 3, 0), transform.rotation, transform);
        Instantiate(slime, new Vector3(transform.position.x + 2, transform.position.y + 2, 0), transform.rotation, transform);
        Instantiate(slime, new Vector3(transform.position.x - 2, transform.position.y - 2, 0), transform.rotation, transform);

        for (int i = 1; i <= 8; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }


    IEnumerator Pattern()
    {
        int num = Random.Range(0, 2);

        switch (num)
        {
            case 0:
                StartCoroutine(Summon());
                break;
            case 1:
                StartCoroutine(Shoot());
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

    IEnumerator Summon()
    {
        bool flag = true;
        Debug.Log("소환시작");
        for (int i = 1; i <= 8; i++)
        {
            if (transform.GetChild(i).gameObject.activeInHierarchy == false) isSummonAble = true;
            else isSummonAble = false;
            flag &= isSummonAble;
        }
        if (flag == true)
        {
            animator.SetTrigger("Summon");
            StartCoroutine(SkillDisplay(3f, "슬라임 분열"));
            yield return new WaitForSeconds(1.5f);

            for (int i = 1; i <= 8; i++)
                transform.GetChild(i).gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(3f);

        StartCoroutine(Idle());
    }

    IEnumerator Shoot()
    {
        animator.SetTrigger("Shoot");
        StartCoroutine(SkillDisplay(3f, "에너지 볼"));
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(ball,transform);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(3f);
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


