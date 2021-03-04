using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사과-
// 말벌, 새에 의해 피해 -> 60초 이후로 60초에 하나씩 등장?
// 피해 횟수 1번, 2번
// 1번= 말벌에게 20초 이상 공격받았다(collider)-> 색이 검게 변함
// 2번= 새에게 20초 이상 공격받았다(collider) -> rigidbody 10초뒤 소멸

public class Health_apple : MonoBehaviour
{
    public float health_apple = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(Recover());
    }

    IEnumerator Recover()
    {   
        if(health_apple <= 99)
        {
            health_apple++; 
            yield return new WaitForSeconds(3.0f); //3초마다 체력 1 회복
        }
               
    }

}