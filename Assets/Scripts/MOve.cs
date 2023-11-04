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
        else if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left * Time.deltaTime * power);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right * Time.deltaTime * power);
        }
        
    }
}
