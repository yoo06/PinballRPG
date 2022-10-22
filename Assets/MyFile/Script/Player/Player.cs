using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  int            hp;
    public  int            atk;
    public  float          dashForce;
    private int            combo;
    public  int            comboLevel;
    [HideInInspector]
    public bool            isDashAble;
    [HideInInspector]
    public  static bool    isInvincible = false;
    private LineRenderer   lineRenderer;


    private float          nearestDis;
    private float          angle = 0;
    private Vector3        lastVelocity;
    private Vector3        expectedLocation;
    private LayerMask      mask;
    private Rigidbody2D    playerRigid;
    private Transform      nearestTarget;
    private GameObject     childObject;
    private SpriteRenderer childRenderer;
    private Animator       animator;

    public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            UIManager.instance.healthSlider.value = hp;

            if (hp <= 0)
            {
                GameManager.instance.GameOver();
                Debug.Log("Game Over");
            }
            else if (hp <=  20 && hp >  0) UIManager.instance.healthColor.color = GameManager.instance.colorDictionary[(int)GameManager.ColorCode.RED];
            else if (hp <=  66 && hp > 20) UIManager.instance.healthColor.color = GameManager.instance.colorDictionary[(int)GameManager.ColorCode.LIGHT_YELLOW];
            else if (hp <= 100 && hp > 66) UIManager.instance.healthColor.color = GameManager.instance.colorDictionary[(int)GameManager.ColorCode.LIGHT_GREEN];
        }
    }

    public int Combo
    {
        get { return combo; }
        set 
        {
            combo = value;
            if (Combo == 0) UIManager.instance.comboText.text = "";
            else UIManager.instance.ComboUpFunc();

            if      (combo >=  0 && combo <  5) comboLevel = 0;
            else if (combo >=  5 && combo < 10) comboLevel = 1;
            else if (combo >= 10 && combo < 15) comboLevel = 2;
            else if (combo >= 15)               comboLevel = 3;
        }
    }

    private void Awake()
    {
        //초기화
        lineRenderer  = GetComponent<LineRenderer>();
        mask          = 1 << (int)GameManager.Layer.BUMPER | 1 << (int)GameManager.Layer.ENEMY;
        playerRigid   = GetComponent<Rigidbody2D>();
        childObject   = transform.GetChild(0).gameObject;
        childRenderer = childObject.GetComponent<SpriteRenderer>();
        isDashAble    = true;
        animator      = childObject.transform.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (transform.position.y > 0)
            lineRenderer.enabled = false;


        lastVelocity = playerRigid.velocity;
        //서클 레이캐스트를 쏴 검출되는 적 중 가장 가까운 적에게 화살표 표시
        Collider2D[] nearTarget = Physics2D.OverlapCircleAll(transform.position, 4f, mask);
        if (nearTarget.Length  <= 0 || isDashAble == false)
        {
              childRenderer.color = new Color(1, 1, 1, 0.0f);
        }
        else
        {
              childRenderer.color = new Color(1, 1, 1, 0.4f);
              nearestDis          = 4;
              nearestTarget       = nearTarget[0].transform;

            for (int i = 0; i < nearTarget.Length; i++)
            {
                float tempDis = Vector3.Distance(nearTarget[i].transform.position, transform.position);
                if (tempDis  <= nearestDis)
                {
                    nearestDis    = tempDis;
                    nearestTarget = nearTarget[i].transform;
                }
            }
            //2D게임에서는 LookAt이 제대로 작동되지 않아 대신 삼각함수로 좌표값 계산 후 회전 적용
            angle = Mathf.Atan2(nearestTarget.position.y - transform.position.y, nearestTarget.position.x - transform.position.x) * Mathf.Rad2Deg;

            childObject.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            if (Input.GetMouseButtonDown(0))
                if(isDashAble == true) StartCoroutine(Dash());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        ////적이나 범퍼에 닿을때 콤보 up
        if (collision.gameObject.layer == (int)GameManager.Layer.BUMPER || collision.gameObject.layer == (int)GameManager.Layer.ENEMY)
        {
            SoundManager.instance.PlayMusic(SoundManager.SoundList.HIT_SOUND);
            Combo++;
        }

        //벽에 닿을때 살짝 튕김
        if(collision.gameObject.layer == (int)GameManager.Layer.STRUCT)
        {
            float speed = lastVelocity.magnitude * 0.8f;
            Vector3 dir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            playerRigid.velocity = dir * Mathf.Max(speed, 0f);
        }
    }
    //방향 예측 그려주기
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)GameManager.Layer.FLIPPER)
        {
            lineRenderer.enabled = true;
            expectedLocation = (transform.position - new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, 0)) * 14;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, expectedLocation);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        lineRenderer.enabled = false;
        if (collision.gameObject.layer == (int)GameManager.Layer.FLIPPER)
        {
            //콤보를 초기화해주며 파워플립 실행
            GameObject.FindObjectOfType<PowerFlipManager>().PowerFlipFunc(comboLevel);
            Combo = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color   = new Color(1, 1, 1, 0.4f);
        Gizmos.DrawSphere(transform.position, 4f);
    }

    //대쉬
    IEnumerator Dash()
    {
            isDashAble = false;
        if(isDashAble == false)
        {
            childRenderer.color  = new Color(1, 1, 1, 0.0f);
            animator.SetTrigger("Dash");
            playerRigid.velocity = Vector3.zero;
            playerRigid.AddForce((nearestTarget.transform.position - transform.position) * dashForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);
            animator.SetTrigger("Idle");
            childRenderer.color  = new Color(1, 1, 1, 0.4f);
            isDashAble = true;
        }
    }
}

