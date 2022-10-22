using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public  static GameManager instance = null;

    [Header("Gameplay References")]
    public         Rigidbody2D leftFlipper;
    public         Rigidbody2D rightFlipper;
    public         GameObject  character;
    public         float       flipForce;
    public         Player      player;
    [SerializeField]
    private        Renderer    characterRenderer;
    public static  bool        isEnding;
    private        GameObject  powerFlipEffect;

    public enum Layer
    {
        FLIPPER = 6,
        BUMPER  = 7,
        ENEMY   = 8,
        MAP     = 9,
        STRUCT  = 10,
        PLAYER  = 11,
    }

    public enum ColorCode
    {
        RED,
        YELLOW,
        GREEN,
        SKY_BLUE,
        LIGHT_GREEN,
        LIGHT_YELLOW,
    }

    public Dictionary <int, Color> colorDictionary = new Dictionary<int,Color>();
 

    private void Awake()
    {
        colorDictionary.Add((int)ColorCode.RED,              Color.red);
        colorDictionary.Add((int)ColorCode.YELLOW,           Color.yellow);
        colorDictionary.Add((int)ColorCode.GREEN,            Color.green);
        colorDictionary.Add((int)ColorCode.SKY_BLUE,     new Color(0.1006289f, 0.9290854f,         1f, 1f));
        colorDictionary.Add((int)ColorCode.LIGHT_GREEN,  new Color(0.6911458f, 0.9528302f, 0.3745401f, 1f));
        colorDictionary.Add((int)ColorCode.LIGHT_YELLOW, new Color(0.9890286f,         1f, 0.4119496f, 1f));
        isEnding = false;

        if (instance == null)
            instance = this;
        else
        {
            GameManager.instance.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        player = character.GetComponentInChildren<Player>();
        powerFlipEffect = transform.GetChild(1).gameObject;
    }

    private void OnEnable()
    {
        //ÃÊ±âÈ­
        player.transform.position        = new Vector3(-2, -6, 0);
        player.isDashAble                = true;
        Player.isInvincible              = false;
        characterRenderer.material.color = Color.white;
        player.Combo                     = 0;

        for(int i = 0; i < 6; i++)
        {
            powerFlipEffect.transform.GetChild(i).gameObject.SetActive(false);
        }

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            player.Hp                    = 100;
            player.atk                   = 1;
            Monster.pushForce            = 5f;
            Thorn.thornDamage            = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
             leftFlipper.AddTorque( flipForce);
            rightFlipper.AddTorque(-flipForce);
        }

         leftFlipper.GetComponent<SpriteRenderer>().color = colorDictionary[player.comboLevel];
        rightFlipper.GetComponent<SpriteRenderer>().color = colorDictionary[player.comboLevel];
    }
    
    public void PlayerDamageFunc(int damage)
    {
        StartCoroutine(PlayerDamage(damage));
    }

    public IEnumerator PlayerDamage(int damage)
    {
        if(Player.isInvincible == false)
        {
            Player.isInvincible = true;
            characterRenderer.material.color = Color.red;
            player.Hp -= damage;
            SoundManager.instance.PlayMusic(SoundManager.SoundList.PLAYER_HIT);
            yield return new WaitForSeconds(1f);
            characterRenderer.material.color = Color.white;
            Player.isInvincible = false;
        }
        else
        {

        }
    }
    public void Push(GameObject pushTarget, Collision2D collision,float pushForce)
    {
        collision.rigidbody.velocity = Vector2.zero;
        collision.rigidbody.AddForce((collision.rigidbody.gameObject.transform.position - pushTarget.transform.position) * pushForce, ForceMode2D.Impulse);
    }

    public void GameOver()
    {
        SoundManager.instance.PlayMusic(SoundManager.SoundList.LOSE_SOUND);
        UIManager.instance.GameOverScene();
        Debug.Log("Á×À½");
    }
}