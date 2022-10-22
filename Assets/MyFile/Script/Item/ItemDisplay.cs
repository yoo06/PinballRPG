using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject display;
    [SerializeField]
    private Text titleDisplay;
    [SerializeField]
    private Text infoDisplay;
    [SerializeField]
    private Image imageDisplay;

    private void Start()
    {
        display.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        display.SetActive(true);
        titleDisplay.text = collision.gameObject.GetComponent<Item>().itemName;
        infoDisplay.text = collision.gameObject.GetComponent<Item>().description;
        imageDisplay.sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public void NextScene()
    {
        MainMenu.NextScene();
    }
}
