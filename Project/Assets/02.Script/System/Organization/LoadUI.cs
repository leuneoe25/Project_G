using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUI : MonoBehaviour
{
    [SerializeField] Image ui;
    void Start()
    {
        
    }
    public void LoadButton()
    {
        if(ui.gameObject.active)
        {
            ui.gameObject.SetActive(false);
        }
        else
        ui.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
