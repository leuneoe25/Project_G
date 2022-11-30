using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private void Start()
    {

    }
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (pos.y < -1.8f)
            pos.y = -3.5f;
        else
            pos.y = 1.7f;
        transform.position = new Vector3(Mathf.Clamp(pos.x, -6f, 6f), pos.y, 0f);
    }
}
    