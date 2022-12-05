using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CostControl : MonoBehaviour
{
    [SerializeField] private Text CostText;

    private float nowCost;

    void Start()
    {
        nowCost = 0;
        GSCost(1);
    }

    public bool UseCost(float value)
    {
        if (nowCost >= value)
        {
            GSCost(-value);
            return true;
        }
        return false;
    }

    public float GSCost(float value = 0f)
    {
        nowCost += value;
        CostText.text = "Cost : " + (int)nowCost;
        return nowCost;
    }
}
