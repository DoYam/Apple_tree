using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Item : MonoBehaviour
{
    public Camera mainCamera;

    public Transform selectedIcon;
    //public Transform y_axle;

    private LeanDragTranslate _translate;
    private LeanPinchScale _pinch;
    private LeanTwistRotateAxis _axis;

    //터치로 물체 선택시 IsSelected가 true 값이 되고 SelectedIcon 오브젝트가 활성화 된다.
    public bool IsSelected
    {
        get => selectedIcon.gameObject.activeSelf;
        set
        {
            _translate.enabled = _pinch.enabled = _axis.enabled = value;
            selectedIcon.gameObject.SetActive(value);
            
            
        }

    }



    //// 두번 터치 시 IsSelected가 true 값이 된다.
    //// 아직은 한 번 터치시로 구현
    //public bool IsSelectedTwice
    //{
    //    get => y_axle.gameObject.activeSelf;
    //    set
    //    {
    //        y_axle.gameObject.SetActive(value);
    //    }

    //}




    void Start()
    {
        _translate = gameObject.AddComponent<LeanDragTranslate>();
        _pinch = gameObject.AddComponent<LeanPinchScale>();
        _axis = gameObject.AddComponent<LeanTwistRotateAxis>();
        mainCamera = Camera.main;

    }


    void Update()
    {
        selectedIcon.transform.LookAt(mainCamera.transform);
    }
}
