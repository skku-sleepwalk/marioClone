using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject mario;
    void Update()
    {
        if (mario.transform.position.x > gameObject.transform.position.x) gameObject.transform.position = new Vector3(mario.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        
    }
}
