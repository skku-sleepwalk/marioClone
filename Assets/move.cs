using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravityPower;
    bool isHorizontalDirectionChanged = false;
    bool isRight = true;
    public float baseSpeed = 2f; // �⺻ �̵� �ӵ�
    public float accelerationRate = 0.1f; // ���ӵ� ������ ���� ���
    private float timeElapsed = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * gravityPower);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            timeElapsed += Time.deltaTime;
            float speed = baseSpeed + Mathf.Log(1 + accelerationRate * timeElapsed);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.right = Vector3.right;
        }
        
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            timeElapsed += Time.deltaTime;
            float speed = baseSpeed + Mathf.Log(1 + accelerationRate * timeElapsed);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.right = Vector3.left;
        }
        else
        {
            // ����Ű�� ���� ���ӵ� �ʱ�ȭ
            timeElapsed = 0f;
        }
    }
}
