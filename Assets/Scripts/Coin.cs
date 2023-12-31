using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    private float destroyDelay = 1f;

    void Start()
    {
	    rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
	    if (collision.gameObject.CompareTag("MainMarioBody")){
            Debug.Log("tt");
		    rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
		    StartCoroutine(DestroyAfterDelay());
	    }
    }

    private IEnumerator DestroyAfterDelay()
    {
	    yield return new WaitForSeconds(destroyDelay);
	    Destroy(gameObject);
    }
}



