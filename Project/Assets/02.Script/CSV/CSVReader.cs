using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSVReader : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void test()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/" + "stage.csv");

        bool ReadingEnded = false;

        while (true)
        {
            string str = reader.ReadLine();
            if (str == null)
            {
                ReadingEnded = true;
                break;
            }
            var value = str.Split(',');
            for (int i = 0; i < str.Length; ++i)
            {
                Debug.Log("v: " + i.ToString() + " " + value[i].ToString());
            }
        }
    }
}
