using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCatMove : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float slowSpeed;
    [SerializeField] Shoot shoot;
    Coroutine shootingCoroutine;
    
    void FixedUpdate()
    {
        Vector3 vector3 = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(KeyCode.RightArrow))
        {
           vector3 += Vector3.right; 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            vector3 += Vector3.left;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vector3 += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vector3 += Vector3.back;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot.bulletType = 1;
        }
        if(Input.GetKeyUp(KeyCode.Space)) {

            shoot.bulletType = 0;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.transform.Translate(vector3 * slowSpeed);
        }
        else
        {
            gameObject.transform.Translate(vector3 * Speed);
        }
    }
}
