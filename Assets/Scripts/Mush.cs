using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mush : MonoBehaviour
{
    public float uppower = 0.5f;
    public float rightpower = 2f;
    public float maxHeight = 0.41f;
    public string targetTag = "MainMarioBody";
    private bool isMovingUp = true;  // 충돌 여부를 나타내는 변수

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag && isMovingUp)
        {
            isMovingUp = false;
        }
    }
    
    void Update()
    {
        if (isMovingUp)
        {
            if (transform.position.y < maxHeight)
            {
                transform.Translate(Vector3.up * uppower * Time.deltaTime, Space.World);
            }
            
            else
            {
                isMovingUp = false;
            }
        }

        else
        {
            transform.Translate(Vector3.right * rightpower * Time.deltaTime, Space.World); 
        }
            
        
    }
    

}
