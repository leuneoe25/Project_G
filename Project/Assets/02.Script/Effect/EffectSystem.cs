using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSystem : MonoBehaviour
{
#region Singleton
    private static EffectSystem instance = null;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static EffectSystem Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExcutTyping(Text textUI, string text, float taketime)
    {
        StartCoroutine(TypingEffect(textUI, text, taketime));
    }
    IEnumerator TypingEffect(Text textUI,string text ,float taketime)
    {
        float time = taketime/ text.Length; 
        textUI.text = "";
        for(int i=0;i<text.Length+1;i++)
        {
            if (i == 0)
                continue;
            textUI.text += text[i-1];
            yield return new WaitForSeconds(time);
        }
    }
}
