using UnityEngine;

public class FloorManagement : MonoBehaviour
{
    public GameObject player;
    public GameObject upFloor;
    public GameObject downFloor;
    public GameObject leftStair;
    public GameObject rightStair;

    void Start()
    {

    }


    void Update()
    {
        if (player.transform.position.y > upFloor.transform.position.y + 0.7f)
        {
            Physics2D.IgnoreLayerCollision(6, 9, false);
        }

        if (Input.GetKey(KeyCode.W)&&player.transform.position.y < downFloor.transform.position.y + 1f)
        {
            Physics2D.IgnoreLayerCollision(6, 7, false);
            Physics2D.IgnoreLayerCollision(6, 8, false);
        }
        else if (player.transform.position.y < downFloor.transform.position.y + 1f)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Physics2D.IgnoreLayerCollision(6, 8, true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(6, 9, true);
        }
    }
}
