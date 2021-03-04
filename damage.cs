using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class damage : MonoBehaviour
{
    Rigidbody rigid;

    Growth_1 grow;
    
    public float health_apple = 100;

    public ParticleSystem par;
    

    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        grow = GameObject.Find("Trees").GetComponent<Growth_1>();

    }

    void Update()
    {
        //Debug.Log("확인");
        if(health_apple <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage) // 체력치 감소 함수
    {
        health_apple -= damage;
        par.Play(); // 파티클 효과
    }

    public void fallDown()  // 다 성장하고 난 후 20초 뒤 사과 떨어지는 함수
    {
        Debug.Log("호출");
        StartCoroutine("Wait_20");
        
        // StartCoroutine("Wait_10");
    }

    IEnumerator Wait_20()
    {
        yield return new WaitForSeconds(3.0f);
        rigid.useGravity = true; //20초뒤 떨어지고
    }

    IEnumerator Wait_10()
    {
        yield return new WaitForSeconds(3.0f);
        // gameObject.SetActive(false); //10초뒤 사라져

    }
}
