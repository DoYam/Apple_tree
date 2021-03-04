using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hornet_ : MonoBehaviour
{
    
    
    void onTriggerEnter(Collider other)
    {
        if(other.tag == "Fruit")
        {
            other.GetComponent<damage>().TakeDamage(3); //체력치  3감소
            other.GetComponent<Renderer>().material.color = Color.black; //색이 검게 변한다
        }
    }
}
