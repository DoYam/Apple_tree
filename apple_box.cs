using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple_box : MonoBehaviour
{

    Growth_1 gro;

    public bool toy_apple;
    public bool cloth_tree;
    public bool light_tree;

    void Start()
    {
        gro = GameObject.FindWithTag("Tree").GetComponent<Growth_1>();
    }

    void onTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        while(other.tag == "Fruit")
        {
            if(gro.growth_apple >= 50 && gro.growth_apple <=199)
            {
                cloth_tree = true;    // 성장치 50~199 사과일때
            }
            else if( gro.growth_apple == 200)
            {
                light_tree = true;  // 성장치 200 사과일떄
            }
            // else 
            // //바닥에 떨어진 사과라면
            // toy_apple = true;
        }
    }
}
