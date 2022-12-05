using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private bool playerDeceted;
    public Transform doorPos;
    public float width;
    public float height;

    public LayerMask whatIsPlayer;

    [SerializeField]
    private string sceneName;

    SceneSwitcher sceneSwitch;

    private void Start() 
    {
        sceneSwitch = FindObjectOfType<SceneSwitcher>();
    }

    private void Update() 
    {
        playerDeceted = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);
        
        if(playerDeceted == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                sceneSwitch.SwitchScene(sceneName);
            }
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }

}
