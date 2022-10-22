using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{

    private Rigidbody2D  rewardRigid;
    private LineRenderer lineRenderer;
    private Vector2      clickPoint;
    [SerializeField]
    private GameObject   predictedPosition;
    private bool         isClickAble;
    private Vector3      lastVelocity;

    void Start()
    {
        isClickAble = true;
        rewardRigid = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        rewardRigid.gravityScale = 0;

    }
    // Update is called once per frame
    void Update()
    {
        lastVelocity = rewardRigid.velocity;
        if(CameraFollow.isReady)
        {
            if(isClickAble)
            {
                if (Input.GetMouseButton(0))
                {
                    clickPoint = Input.mousePosition;
                    clickPoint = Camera.main.ScreenToWorldPoint(clickPoint);

                    predictedPosition.transform.position = clickPoint;
                    predictedPosition.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);

                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, clickPoint);
                    
                }

                if (Input.GetMouseButtonUp(0))
                {
                    lineRenderer.SetPosition(0, Vector3.zero);
                    lineRenderer.SetPosition(1, Vector3.zero);

                    predictedPosition.SetActive(false);

                    rewardRigid.gravityScale = 1;
                    rewardRigid.AddForce(clickPoint, ForceMode2D.Impulse);
                    isClickAble = false;
                }
            }

        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //º®¿¡ ´êÀ»¶§ »ìÂ¦ Æ¨±è
        if (collision.gameObject.layer == (int)GameManager.Layer.STRUCT)
        {
            float speed = lastVelocity.magnitude * 0.2f;
            Vector3 dir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rewardRigid.velocity = dir * Mathf.Max(speed, 0f);
        }
    }
}
