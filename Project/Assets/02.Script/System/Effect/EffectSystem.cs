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
}
