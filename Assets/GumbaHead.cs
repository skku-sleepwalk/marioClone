using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbaHead : MonoBehaviour
{
    public static bool isDead;
    void Start(){
        isDead=false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("dd");

        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "MainMarioBody")
        {

           isDead = true;
        Debug.Log("d");
        }
    }

}
    
