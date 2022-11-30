using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

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

[System.Serializable]
class Data
{
    public int stage;

    /// <summary>
    /// Save method: character name + character class (Enum) & N line = N Stars (ex : 4line "kokoko, Science" = star : 4 roll : science name : kokoko)
    /// </summary>
    public string[,] character = new string[4, 20];

    /// <summary>
    /// 0 : wood
    /// 1 : iron
    /// 2 : glass
    /// </summary>
    public int[] bulidEle = new int[3];

    /// <summary>
    /// 0 : coin
    /// 1 : SchoolPoint(SP)
    /// 2 : Budget
    /// </summary>
    public int[] CommonGoods = new int[3];

    /// <summary>
    /// 0 : Attack
    /// 1 : Support
    /// 2 : Debuff
    /// </summary>
    public int[] GemOftTranscendence = new int[3];

    public float[] CharacterStat = new float[20];

    public int LevelOFCastle;
    
    /// <summary>
    /// int : Serial number which tutorial have
    /// bool : tutorial was finded by player
    /// </summary>
    public Queue<KeyValuePair<int, bool>> tuto = new Queue<KeyValuePair<int, bool>>();
}

public class SaveALoadManager : MonoBehaviour
{
    Data player = new Data() { stage = 1, character = { }, bulidEle = { }, CommonGoods = { }, CharacterStat = { }, LevelOFCastle = 1  };

    void Start()
    {
        string JsonData = JsonUtility.ToJson(player);

        print(JsonData);

    }

    public void LoadJson(string data)
    {
        player = JsonUtility.FromJson<Data>(data);
    }

    public void StageClear()
    {
        player.stage++;
    }

    public void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(player);
        string path = Application.dataPath + "/player.json";
        File.WriteAllText(path, jsonData);
    }

    public void GetChar()
    {

    }

    void Update()
    {
        
    }
}
