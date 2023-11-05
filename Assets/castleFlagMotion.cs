using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class castleFlagMotion : MonoBehaviour
{
    public GameObject castleFlag;
    float originY;
    int flag = 0;
    public float downSpeed = 0.15f;
    private void Start()
    {
        originY = castleFlag.transform.position.y;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Mario")
        {
            flag = 1;
        }
    }
    private void Update()
    {   if (flag==1&& originY - castleFlag.transform.position.y < 7.5)
       castleFlag.transform.Translate(Vector3.down*downSpeed);
    }

}
