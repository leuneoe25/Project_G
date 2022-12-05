using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToActive : MonoBehaviour
{
    [SerializeField] GameObject Level2;
    [SerializeField] GameObject Level3;
    [SerializeField] GameObject Wall2;
    [SerializeField] GameObject Wall3;

    private void Start()
    {
        int level = GoodsSystem.Instance.GSetCouncilLv();

        if (level >= 3)
        {
            Level2.SetActive(true);
            Level3.SetActive(true);
            Wall2.SetActive(false);
            Wall3.SetActive(false);
        }
        else if (level >= 2)
        {
            Level2.SetActive(true);
            Wall2.SetActive(false);
        }
    }
}
