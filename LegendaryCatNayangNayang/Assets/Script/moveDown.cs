using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDown : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator movDown()
    {
        while (true)
        {
        gameObject.transform.Translate(Vector3.back);
        yield return new WaitForSeconds(1.0f);
        }
        
    }
    private void Start()
    {
        StartCoroutine("movDown");
    }
    // Update is called once per frame
    void Update()
    {

       
    }
}
