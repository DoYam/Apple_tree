using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 온도 – 적정 범위를 넘어갈 경우 1초마다 1씩 감소한다. :프로퍼티
// 강수량 – 적정 범위를 넘어갈 경우1초마다 1씩 감소한다. : 프로퍼티?

//  강수량을 측정하기 어려우므로,습도 감지 센서를 활용한다.
//  강수량은 500부터 시작하여 1초에 1씩 줄어든다.
//  300~700ml 사이가 적정 강수량이며,범위를 이탈하면 체력 수치가 감소한다.
//  실제 습도가 40% 이상으로 올라가면강수량이 1초에 5씩 증가한다.
//  화면 상에 비가 내린다.

// 체력에 따른 나무줄기, 이파리 색 변화 구현

public class Health_tree : MonoBehaviour
{
    public float health_tree = 100;

    private float temperature;
    private float rainFall; 


    
    public float Temp
    {
        get
        {
            return temperature;
        }
        set
        {
            if(value > 25 || value < 15)
            {
                StartCoroutine(TempProblem());
            }
            else
            {
                temperature = value; // 온도 감지..?
            }
            
        }
    }

    public float Rain
    {
        get
        {
            return rainFall;
        }
        set
        {
            //강수량 범위 측정
        }
    }

    // void Start()
    // {
    //     value = 30;
    // }

    void Update()
    {
        StartCoroutine(Recover());
        // if(health_tree == 0)
        // {
        //     Destroy();
        //     Debug.Log("나무가 죽었습니다...");
        // }
    }
    

    IEnumerator TempProblem()
    {
        while(true)
        {
            health_tree--;  
            //GetComponent<Renderer>().material.color = new Color(0, , );//점점 검게 변하는 코드 추가
            yield return new WaitForSeconds(1.0f); // 1초마다 체력 1 감소

            // if(value <= 25 || value >= 15)
            // {
            //     break;
            // }
        }
    }
    
    
    IEnumerator Recover()
    {   
        if(health_tree <= 99)
        {
            health_tree++; 
            yield return new WaitForSeconds(3.0f); //3초마다 체력 1 회복
        }
               
    }
}