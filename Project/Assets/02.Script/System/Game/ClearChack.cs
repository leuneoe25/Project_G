using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChack : MonoBehaviour
{
    #region Singleton
    private static ClearChack instance = null;
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
    public static ClearChack Instance
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

    private bool[] open = new bool[7];
    
    private void Start()
    {
        open[0] = true;    
    }
    public void OpenStage(int idx)
    {
        open[idx] = true;
    }

    public bool IsOpen(int idx)
    {
        return open[idx];
    }
}
