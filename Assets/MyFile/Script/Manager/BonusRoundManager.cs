using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRoundManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPosition = new Transform[5];
    public  GameObject  item;
    private GameObject[] itemLists = new GameObject[11];

    private enum ItemEnum
    {
        SMALL_POTION,
        MEDIUM_POTION,
        LARGE_POTION,
        SCULL,
        RUBY,
        EMERALD,
        SAPPHIRE,
        CRYSTAL,
        ATTACK_UP,
        LIGHTER,
        ARMOR,
    }


    private void Start()
    {
        SoundManager.instance.StopMusic();
        SoundManager.instance.PlayMusic(SoundManager.SoundList.BONUS_STAGE_BGM);


        for (int i = 0; i < itemLists.Length; i++)
        {
            itemLists[i] = item.transform.GetChild(i).gameObject;
            Debug.Log(itemLists[i].name);
        }


        for (int i = 0; i < 5; i++)
        {
            int randomNum = Random.Range(0, 52);
            switch(randomNum)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    Instantiate(itemLists[(int)ItemEnum.SMALL_POTION], spawnPosition[i].position, transform.rotation);
                    break;
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                    Instantiate(itemLists[(int)ItemEnum.MEDIUM_POTION], spawnPosition[i].position, transform.rotation);
                    break;
                case 18:
                case 19:
                    Instantiate(itemLists[(int)ItemEnum.LARGE_POTION], spawnPosition[i].position, transform.rotation);
                    break;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    Instantiate(itemLists[(int)ItemEnum.SCULL], spawnPosition[i].position, transform.rotation);
                    break;
                case 30:
                case 31:
                case 32:
                    Instantiate(itemLists[(int)ItemEnum.RUBY], spawnPosition[i].position, transform.rotation);
                    break;
                case 33:
                case 34:
                case 35:
                    Instantiate(itemLists[(int)ItemEnum.SAPPHIRE], spawnPosition[i].position, transform.rotation);
                    break;
                case 36:
                case 37:
                case 38:
                    Instantiate(itemLists[(int)ItemEnum.EMERALD], spawnPosition[i].position, transform.rotation);
                    break;
                case 39:
                case 40:
                case 41:
                case 42:
                    Instantiate(itemLists[(int)ItemEnum.CRYSTAL], spawnPosition[i].position, transform.rotation);
                    break;
                case 43:
                case 44:
                case 45:
                    Instantiate(itemLists[(int)ItemEnum.ATTACK_UP], spawnPosition[i].position, transform.rotation);
                    break;
                case 46:
                case 47:
                case 48:
                    Instantiate(itemLists[(int)ItemEnum.LIGHTER], spawnPosition[i].position, transform.rotation);
                    break;
                case 49:
                case 50:
                case 51:
                    Instantiate(itemLists[(int)ItemEnum.ARMOR], spawnPosition[i].position, transform.rotation);
                    break;
            }
            Debug.Log((i+1) + " È¸ »Ì±â ¿Ï·á" + randomNum);
        }
        
    }

}
