using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glow : MonoBehaviour
{
    private Text  text;
    private Color currentColor;
    private Color glowColor;
    public  float glowTime;
    
    void Start()
    {
        
        text = GetComponent<Text>();
        currentColor = text.color;
        glowColor = new Color(currentColor.r, currentColor.g, currentColor.b, 0.8f);
        StartCoroutine(GlowCo());
    }


    IEnumerator GlowCo()
    {
        while (true)
        {
            text.color = glowColor;
            yield return new WaitForSeconds(glowTime * Time.deltaTime);
            text.color = currentColor;
            yield return new WaitForSeconds(glowTime * Time.deltaTime);
        }
    }
}
