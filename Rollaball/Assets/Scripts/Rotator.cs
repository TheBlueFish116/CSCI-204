using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("PickUp"))
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }else if (gameObject.CompareTag("zRotate"))
        {
            transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(-30, 0, 0) * Time.deltaTime);
        }
    }
}
