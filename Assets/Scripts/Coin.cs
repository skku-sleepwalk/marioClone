using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float jumpForce; // 점프 힘 설정
    private float jumpStartTime;
    private float destroyDelay = 0.5f; // 사라질 때까지의 지연 시간
    private bool flag=true;
    public static bool flag2=false;
    private Rigidbody2D rb;
    private QBox qBox;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        qBox = GetComponent<QBox>(); // 스크립트를 가져옴
  
    }

    private void Update()
    {
    
        if (flag2&&flag)
        {
            flag=false;
            Debug.Log("작동");
          StartJump();
           
        }
    }

    public void StartJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
      

        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        DestroyCoin();
        Debug.Log("작동");
    }

    private void DestroyCoin()
    {
        // Coin 오브젝트를 파괴
        Destroy(gameObject);
    }
}