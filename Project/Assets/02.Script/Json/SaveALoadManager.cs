using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public enum characterClass
{
    Archery,
    Kendo,
    Clean,
    MarineSports,
    Science,
    Boxing,
    Band,
    Cooking,
    Library
}

class Data
{
    int money;
    int NumberOfLockedCharacter = 0;
    
    string[,] character = new string[4, 20];
    
    

    //가지고 있는 캐릭터 bool 1 2 3 4
}

public class SaveALoadManager : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
