using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumba : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.right*speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            speed = -speed;
        }
    }
}