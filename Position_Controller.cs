using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Controller : MonoBehaviour
{

    public GameObject target;


    Vector3 Before_Touch;

    void Update()
    {
        //if(Input.touchCount> 0)
        //{

        //    //움직일 물체의 위치를 받아옴
        //    Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);

        //    //화면을 터치할때 터치의 위치를 받아옴
        //    Vector2 pos2 = Input.GetTouch(0).position;
        //    Vector3 theTouch = new Vector3(pos2.x, pos2.y, 0.0f);


        //    // 터치가 처음 시작될때
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        Before_Touch = new Vector3(pos.x, pos.y, pos.z);

        //    }
        //    else if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //    {

        //        target.transform.position = new Vector3(Before_Touch.x, Before_Touch.y + theTouch.y, Before_Touch.z);

        //    }

        //}
        
    }
}
