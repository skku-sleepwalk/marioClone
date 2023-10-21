using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOve : MonoBehaviour
{
    public float power;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * power, ForceMode2D.Impulse);  
            
        }

    }
}
