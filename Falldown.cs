using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//성장치 200이 되면 사과들은 20초 뒤 떨어지고  10초뒤 소멸한다
public class Falldown : MonoBehaviour
{
    Rigidbody rigid;

    public void falling()
    {
        StartCoroutine(Rigid());
        rigid = GetComponent<Rigidbody>();
    }

    IEnumerator Rigid()
    {
        yield return new WaitForSeconds(20.0f);
        rigid.useGravity = true;
        Debug.Log("떨어진다");
        yield return new WaitForSeconds(10.0f);
        gameObject.SetActive(false); 
        Debug.Log("사라진다");       
    }
}
