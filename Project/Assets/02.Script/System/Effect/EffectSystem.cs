using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Typing(Text text, string s, float takeTime)
    {
        StopAllCoroutines();
        StartCoroutine(TypingEffect(text, s, takeTime));
    }
    IEnumerator TypingEffect(Text text,string s,float takeTime)
    {
        text.text = "";
        float time = takeTime / s.Length;
        for (int i = 0;i < s.Length+1;i++)
        {
            if (i == 0)
                continue;
            text.text += s[i-1];
            yield return new WaitForSeconds(time);
        }
    }

    public void Guide(Text text, string s, float takeTime)
    {
        StopAllCoroutines();
        StartCoroutine(GuideEffect(text, s, takeTime));
    }
    IEnumerator GuideEffect(Text text, string s, float takeTime)
    {

        text.gameObject.SetActive(true);
        text.text = s;
        float time = takeTime / 10 /2 ;
        Color c = new Color(1,1,1,0);
        float add = 1f / 10f;
        for (int i = 0; i < 10; i++)
        {
            text.color = c;
            c = new Color(c.r,c.g, c.b,c.a+add);
            yield return new WaitForSeconds(time);
        }
        for (int i = 0; i < 10; i++)
        {
            text.color = c;
            c = new Color(c.r, c.g, c.b, c.a - add);
            yield return new WaitForSeconds(time);
        }
        text.gameObject.SetActive(false);
    }
}
