using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.RainMaker;



public class BySensored : MonoBehaviour
{
    public GameObject Tree;
    public float health_Tree = 100; //체력수치

    Renderer TreeColor;

    public float Humidity; //강수량(습도) 300-700 적정 500부터 시작하여 1초에 1씩 줄어든다. 실제 습도 40%이상이면 1초에 5씩 증가, 화면에 비
    public float Tempereture = 20; //온도 15-25 적정 범위 이탈시 체력 수치 감소
    public float Sunshine = 900; //일조량 0 - 1000 -> 배경 밝기 달라짐

    public GameObject RainPrefab;
    public RainScript raining;

    public GameObject DirectionalLight;
    public Light lightIntensity;
    
  

    void Start()
    {
        raining = GameObject.Find("RainPrefab").GetComponent<RainScript>();
        raining.RainIntensity = 0;
        TreeColor = gameObject.GetComponent<Renderer>();
        lightIntensity = GameObject.Find("DirectionalLight").GetComponent<Light>();
    }

    void Update()
    {
        ByHumidity(Humidity);
        ByTempereture(Tempereture);
        BySunshine(Sunshine);
    }

    void ByHumidity(float Humidity)
    {
        if (60 > Humidity && Humidity >= 40f)
        {
            raining.RainIntensity = 0.8f;
            healthPlus(health_Tree);
            // TreeColor.GetComponent<Renderer>().material.color = new Color(0);
        }
        else if (100f > Humidity && Humidity >= 60f)
        {
            raining.RainIntensity = 1;
            healthPlus(health_Tree);
        }
        else if (Humidity <= 10f)
        {
            raining.RainIntensity = 0;
        }
        else
        {
            raining.RainIntensity = 0;
        }
        
    }

     void ByTempereture(float Tempereture)
     {
        if (15 <= Tempereture && Tempereture <= 25)
        {
            return;
        }
        else
        {
            health_Tree -= 3;
        }
     }

     void BySunshine(float Sunshine)
     {
        if (Sunshine >= 1000)
        {
            lightIntensity.intensity = 1.3f;
        }
        else if (1000 > Sunshine && Sunshine >= 800)
        {
            lightIntensity.intensity = 1f;
        }
        else if (800 > Sunshine && Sunshine >= 500)
        {
            lightIntensity.intensity = 0.7f;
        }
        else
        {
            lightIntensity.intensity = 0.3f;
        }

     }

    void healthPlus(float health_Tree)
    {
        if (0 <= health_Tree && health_Tree < 200)
        {
            health_Tree += 5;
        }
        else
        {
            return;
        }
    }


}