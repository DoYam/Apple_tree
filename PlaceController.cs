using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceController : MonoBehaviour
{
    
    public Camera mainCamera;
    public ARRaycastManager raycastManager;
    public GameObject placementIndicator;
    public GameObject[] prefab;
    private Dictionary<int, GameObject> _instancedPrefab = new Dictionary<int, GameObject>();

    //가구 버튼 boolean 연산자
    bool Item0;
    bool Item1;
    bool Item2;
    bool Item3;
    bool Item4;


    void Update()
    {
        var hits = new List<ARRaycastHit>();
        var center = mainCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        raycastManager.Raycast(center, hits, TrackableType.PlaneWithinBounds);
        placementIndicator.SetActive(hits.Count > 0);
        if (hits.Count == 0) return;

        var cameraForward = mainCamera.transform.TransformDirection(Vector3.forward);
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        var pose = hits[0].pose;
        pose.rotation = Quaternion.LookRotation(cameraBearing);
        placementIndicator.transform.SetPositionAndRotation(pose.position, pose.rotation);



        // 버튼이 눌러지면 발생
        if (Item0 && TouchHelper.IsDown)
        {

            var obj = Instantiate(prefab[0], pose.position, pose.rotation, transform);
            obj.SetActive(true);
            _instancedPrefab[obj.GetInstanceID()] = obj;
            RefreshSelection(obj);

            
        }

        if (Item1 && TouchHelper.IsDown)
        {
            var obj = Instantiate(prefab[1], pose.position, pose.rotation, transform);
            obj.SetActive(true);
            _instancedPrefab[obj.GetInstanceID()] = obj;
            RefreshSelection(obj);


        }

        if (Item2 && TouchHelper.IsDown)
        {
            var obj = Instantiate(prefab[2], pose.position, pose.rotation, transform);
            obj.SetActive(true);
            _instancedPrefab[obj.GetInstanceID()] = obj;
            RefreshSelection(obj);


        }

        if (Item3 && TouchHelper.IsDown)
        {
            var obj = Instantiate(prefab[3], pose.position, pose.rotation, transform);
            obj.SetActive(true);
            _instancedPrefab[obj.GetInstanceID()] = obj;
            RefreshSelection(obj);


        }

        if (Item4 && TouchHelper.IsDown)
        {
            var obj = Instantiate(prefab[4], pose.position, pose.rotation, transform);
            obj.SetActive(true);
            _instancedPrefab[obj.GetInstanceID()] = obj;
            RefreshSelection(obj);


        }

        //if (TouchHelper.Touch3)
        //{
        //    var index = Random.Range(0, prefab.Length);
        //    var obj = Instantiate(prefab[index], pose.position, pose.rotation, transform);
        //    obj.SetActive(true);
        //    _instancedPrefab[obj.GetInstanceID()] = obj;
        //    RefreshSelection(obj);
        //}


        Item0 = false;
        Item1 = false;
        Item2 = false;
        Item3 = false;
        Item4 = false;
        
        if (Input.touchCount == 0) return;

        if (TouchHelper.IsDown)
        {
            if(Physics.Raycast(mainCamera.ScreenPointToRay(TouchHelper.TouchPosition), out var raycastHits, mainCamera.farClipPlane))
            {
                if (raycastHits.transform.gameObject.tag.Equals("Player"))
                {
                    RefreshSelection(raycastHits.transform.gameObject);
                }

            }
        }
    }




    // 생성한 오브젝트를 _instancedPrefab 변수에 기록을 하여 같은 물체라도 고유의 인스턴스ID를 갖게하는 함수
    private void RefreshSelection(GameObject select)
    {
        foreach (var obj in _instancedPrefab)
        {
 
            var item = obj.Value.GetComponent<Item>();

            if (item)
            {
                item.IsSelected =  obj.Key == select.GetInstanceID();   //선택 아이콘 활성화

            }


        }
    }





    // 버튼 관련 코드
    //유니티에서 버튼에 있는 EventTrigger 컴포넌트의 함수명과 아래 코드상의 "  " 안이 동일해야함
    //아래의 ButtonDown, ButtonUp 함수들은 Update() 안에 없어도 된다. 유니티 상에서 EventTrigger 컴포넌트안에서 함수를 불러서 사용한다.
    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "Item0":
                Item0 = true;
                break;
            case "Item1":
                Item1 = true;
                break;
            case "Item2":
                Item2 = true;
                break;
            case "Item3":
                Item3 = true;
                break;
            case "Item4":
                Item4 = true;
                break;
        }

    }


    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "Item0":
                Item0 = false;
                break;
            case "Item1":
                Item1 = false;
                break;
            case "Item2":
                Item2 = false;
                break;
            case "Item3":
                Item3 = false;
                break;
            case "Item4":
                Item4 = false;
                break;

        }

    }

}
