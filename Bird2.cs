using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2 : MonoBehaviour
{
    public int birdCount;

    //public Transform[] randomPos;
    public Transform looktarget;
    public int hit_cnt = 0;
    public bool hit_check = false;
    Vector3 pos;
    Vector3 random_position;
    float x,y,z;
    public float speed = 2f;

    private void Start()
    {
        pos = GetComponent<Transform>().position;
    }

    void Update()
    {
        Vector3 vec = looktarget.position - transform.position;
        vec.Normalize();
        Quaternion q = Quaternion.LookRotation(vec);
        transform.rotation = q;

        transform.LookAt(looktarget);
        
        if (hit_check)
        {
            transform.position = Vector3.MoveTowards(transform.position, random_position, speed * Time.deltaTime);
        }
        else
        {
            x = Random.Range(-2f,2f);
            y = Random.Range(-2f,2f);
            z = Random.Range(-2f,2f);

            random_position = new Vector3(pos.x + x, pos.y + y, pos.z + z);
        }
        if(transform.position == random_position)
        {
            hit_check = false;
            pos = random_position;
            
           gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }


    //void MinusCount()
    //{
    //    birdCount--;
    //}

    //void SwitchPos()
    //{
    //    int i = Random.Range(0, randomPos.Length);
    //    //birdPos.position = new Vector3( randomPos[i].position.x, randomPos[i].position.y, randomPos[i].position.z) ;

    //    birdPos.position = new Vector3(randomPos[i].position.x, randomPos[i].position.y, randomPos[i].position.z);



    //}


    void onTriggerEnter(Collider other)
    {
        if(other.tag == "Fruit")
        {
            other.GetComponent<damage>().TakeDamage(5);// 체력치 5감소
            other.transform.localScale -= new Vector3(0.01f,0.01f,0.01f); //사과 사이즈 줄어든다
        }
    }

    
    void clickEnemy()
    {
            hit_cnt++;
            if (hit_cnt >= 3)
                gameObject.SetActive(false);
            else
            {
                hit_check = true;
            }
        
    }
}
