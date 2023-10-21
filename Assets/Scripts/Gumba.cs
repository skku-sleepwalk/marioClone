using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumba : MonoBehaviour
{
    public float minX = 31.8f;
    public float maxX = 36.3f;
    public float moveSpeed;

    private bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        if (movingRight){
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else{
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= maxX){
            movingRight = false;
        }
        else if (transform.position.x <= minX){
            movingRight = true;
        }

    }
}
