using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomController : MonoBehaviour
{
    public GameObject[] enemies;
    private BoxCollider area;

    public GameObject enem;

    public float activeRange = 5;

    void Start()
    {
        StartCoroutine("Activate");

        area = GetComponent<BoxCollider>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // foreach(GameObject ene in enemies)
        // {
        //     ene.SetActive(false);
        // }
    }

    IEnumerator Activate() // 랜덤으로 등장하게 한다
    {

        float x = Random.Range(10.0f,20.0f); //60~90초 사이 어딘가에서 enemy등장
        yield return new WaitForSeconds(x); 

        int enemyIndex = Random.Range(0,enemies.Length);

        Vector3 activePos = GetRandomPos();

        GameObject enem = (GameObject)Instantiate(enemies[enemyIndex], 
            activePos,
            Quaternion.identity);   

    }

    private Vector3 GetRandomPos()
    {
        Vector3 basePos = transform.position;
        Vector3 size = area.size; //  boxcollider사이즈

        float posX = basePos.x + Random.Range(-size.x/2f, size.x/2f);
        float posY = basePos.y + Random.Range(-size.y/2f, size.y/2f);
        float posZ = basePos.z + Random.Range(-size.z/2f, size.z/2f);

        Vector3 enemyPos = new Vector3(posX,posY,posZ);

        return enemyPos;
    }
}
