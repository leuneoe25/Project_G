using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCamMove : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x >= 0)
        {
            transform.Translate(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 72)
        {
            transform.Translate(Vector3.right);
        }
    }

}
