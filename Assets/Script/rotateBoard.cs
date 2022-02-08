using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBoard : MonoBehaviour
{

    float speed = 5f;
    public void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * speed;
       // float rotY = Input.GetAxis("Mouse Y") * speed;

        transform.Rotate(Vector3.down,  rotX);
       // transform.Rotate(Vector3.right,  rotY);
    }

    private void Update()
    {
       


    }

}
