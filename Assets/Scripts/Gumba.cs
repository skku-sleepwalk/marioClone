using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gumba : MonoBehaviour
{
    public float speed;
    BoxCollider2D collider;
    void Start(){
        collider=GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        gameObject.transform.Translate(Vector3.right*speed*Time.deltaTime);

        if (GumbaHead.isDead == true)
        {
            Debug.Log("d");
            //istrigger 체크 및 화면 밖으로 추락
            collider.isTrigger = true;
            StartCoroutine(FallOffScreen());
        }
    }

    private IEnumerator FallOffScreen()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            speed = -speed;
        }
    }
        

}