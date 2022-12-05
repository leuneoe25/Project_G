using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMember : MonoBehaviour
{
    [SerializeField] Text[] text;
    [SerializeField] string[] str;
    [SerializeField] InputField inputField;
    [SerializeField] Image FriendImage;
    string name;
    
    public void GetFriendName()
    {
        if(inputField.text != null)
        {
            name = inputField.text;
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
