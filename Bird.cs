using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int birdCount;

    public Transform[] randomPos;
    Transform birdPos;
    public Transform looktarget;

    private void Start()
    {
        birdCount = 4;
        birdPos = GetComponent<Transform>();
        birdPos.position = new Vector3();


    }

    void MinusCount()
    {
        birdCount--;
    }

    void SwitchPos()
    {
        int i = Random.Range(0, randomPos.Length);
        //birdPos.position = new Vector3( randomPos[i].position.x, randomPos[i].position.y, randomPos[i].position.z) ;

        birdPos.position = new Vector3(randomPos[i].position.x, randomPos[i].position.y, randomPos[i].position.z);



    }

    void onTriggerEnter(Collider other)
    {
       
    }

    private void Update()
    {
        Vector3 vec = looktarget.position - transform.position;
        vec.Normalize();
        Quaternion q = Quaternion.LookRotation(vec);
        transform.rotation = q;

        transform.LookAt(looktarget);


        if (birdCount == 0)
        {
            gameObject.SetActive(false);
        }
    }


}
