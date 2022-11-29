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
    int stage;

    /// <summary>
    /// Save method: character name + character class (Enum) & N line = N Stars (ex : 4line "kokoko, Science" = star : 4 roll : science name : kokoko)
    /// </summary>
    string[,] character = new string[4, 20];

    /// <summary>
    /// 0 : wood
    /// 1 : iron
    /// 2 : glass
    /// </summary>
    int[] bulidEle = new int[3];

    /// <summary>
    /// 0 : coin
    /// 1 : SchoolPoint(SP)
    /// 2 : Budget
    /// </summary>
    int[] CommonGoods = new int[3];

    /// <summary>
    /// 0 : Attack
    /// 1 : Support
    /// 2 : Debuff
    /// </summary>
    int[] GemOftTranscendence = new int[3];

    float[] CharacterStat = new float[20];

    int LevelOFCastle;
    
    /// <summary>
    /// int : Serial number which tutorial have
    /// bool : tutorial was finded by player
    /// </summary>
    Queue<KeyValuePair<int, bool>> tuto = new Queue<KeyValuePair<int, bool>>();
}

public class SaveALoadManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
