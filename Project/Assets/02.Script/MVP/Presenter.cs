using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    #region Singleton
    private static Presenter instance = null;
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
    public static Presenter Instance
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
    //public GameObject store;

    void Start()
    {
        //store = GameObject.Find("Canvases").transform.Find("Store").gameObject;
    }

    public void OpenMenu()
    {

    }
    public void OpenUpgrade()
    {

    }
    public void OpenFriendUpgrade()
    {

    }
    public void OpenGetFriend()
    {

    }

    public void OpenStore()
    {

        // Go to 'Store Model'

        //store.SetActive(true);

    }

    public void OpenProtect()
    {
        /*
        SceneController -> InGame Scene
        
        */
    }
}
