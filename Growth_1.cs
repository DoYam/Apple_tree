using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth_1 : MonoBehaviour
{
    public float growth_tree;
    public float growth_apple;

    float waitTime;
    float timer;

    public bool canHarvest;

    public GameObject[] tree;
    public GameObject[] bloss;
    public GameObject[] fruits;
    bool isPause;

    private damage dam;



    void Start()
    {
        growth_tree = 0;
        growth_apple = 0;

        //isPause = true;

        waitTime = 0.3f;
        timer = 0f;

        tree = GameObject.FindGameObjectsWithTag("Tree");
        bloss = GameObject.FindGameObjectsWithTag("Apple blossom");
        fruits = GameObject.FindGameObjectsWithTag("Fruit");
        dam = GameObject.Find("apple").GetComponent<damage>();

    }

    public void GrowPlay()
    {
        isPause = false;
    }

    public void GrowStop()
    {
        isPause = true;
    }

    IEnumerator WaitAdd()
    {
        growth_tree+= 1;
        growth_apple+= 1;

        yield return null;
    }

    public void Update()
    {
        if (!isPause)
        {
            timer += Time.deltaTime;

            if(timer > waitTime)
            {
                StartCoroutine("WaitAdd");
                timer = 0;
            }
            

        }

            if (growth_tree >= 0 && growth_tree < 5)
            {
                tree[1].SetActive(false);
                tree[2].SetActive(false);

            }
            else if (growth_tree >= 5 && growth_tree < 10)
            {
                tree[0].SetActive(false);
                tree[1].SetActive(true);

            }
            else if (growth_tree >= 10 && growth_tree < 30)
            {
                tree[1].SetActive(false);
                tree[2].SetActive(true);

                canHarvest = true;
            }
            else if (growth_apple == 30)
            {
                dam.fallDown();

            }
        
    }
}




