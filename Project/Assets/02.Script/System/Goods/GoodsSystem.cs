using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsSystem : MonoBehaviour
{
    #region Singleton
    private static GoodsSystem instance = null;
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
    public static GoodsSystem Instance
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
    //School Point
    int sp = 0;

    int[] buildingGoods = new int[3];
    //[0] : Wood
    //[1] : Glass
    //[2] : Iron

    int[] crystals = new int[3];

    #region Council
    
    int CouncilLv = 1;

    int HpUpLv;

    int ReduceTimeLv;

    int DeflaultCostLv;

    public int GSetCouncilLv(int Lv = 0)
    {
        CouncilLv += Lv;
        return CouncilLv;
    }

    public int GSetHpLv(int Lv = 0)
    {
        HpUpLv += Lv;
        return HpUpLv;
    }
    public int GSetReduceLv(int Lv = 0)
    {
        ReduceTimeLv += Lv;
        return ReduceTimeLv;
    }
    public int GSetDefault(int Lv = 0)
    {
        DeflaultCostLv += Lv;
        return DeflaultCostLv;
    }

    #endregion

    /// <summary>
    /// Get building goods
    /// </summary>
    /// <param name="index">
    /// index : 0 / Wood || index : 1 / Glass || index : 2 / Iron
    /// </param>
    /// <returns></returns>
    public int GetBuildingGoods(int index)
    {
        return buildingGoods[index];
    }
    public int GetSP()
    {
        return sp;
    }
    /// <summary>
    /// Get crystals
    /// </summary>
    /// <param name="index">
    /// index : 0 / Attack || index : 1 / Debuff || index : 2 / Support
    /// </param>
    /// <returns></returns>
    public int GetCrystals(int index)
    {
        return crystals[index];
    }
    public void SetBuildingGoods(int _Wood,int _Glass, int _Iron)
    {
        buildingGoods[0] += _Wood;
        buildingGoods[1] += _Glass;
        buildingGoods[2] += _Iron;
    }
    public void SetSP(int _sp)
    {
        sp += _sp;
    }
    public void SetCrystals(int _Attack, int _DeBuff, int Support)
    {
        crystals[0] += _Attack;
        crystals[1] += _DeBuff;
        crystals[2] += Support;
    }
}
