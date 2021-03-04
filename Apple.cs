using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //public GameObject giantApple;
    public bool isSpawn;

    public int cnt = 0;
    
    void Start()
    {
        isSpawn = true;
    }

    void makerigidbody()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        
        //Destroy(gameObject, 30);

        if (coll.gameObject.tag == ("Fruit"))
        {

                SpawnGiantApple(coll);
                gameObject.SetActive(false);
            
        }
    }

    void SpawnGiantApple(Collision coll)
    {
        
        AppleMaster.Instance.spawnPos = coll.contacts[0].point;
        AppleMaster.Instance.spawnCount++;
        AppleMaster.Instance.SpawnGiantApple();

        //Instantiate(giantApple, coll.contacts[0].point, Quaternion.identity);

    }







}
