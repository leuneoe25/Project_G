using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSpText : MonoBehaviour
{
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(text.text != GoodsSystem.Instance.GetSP().ToString())
        {
            text.text = GoodsSystem.Instance.GetSP().ToString();
        }
    }
}
