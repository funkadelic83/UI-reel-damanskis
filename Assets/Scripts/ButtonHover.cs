using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class ButtonHover : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{ 

    [SerializeField] private VideoData_SO videoInfoToDisplay;

    //private bool mouse_over = false;

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    mouse_over = true;
    //    Debug.Log("test");
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    mouse_over = false;
    //    Debug.Log("Do nothing");
    //}



    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (mouse_over)
    //    {
    //        Debug.Log("MouseOver");
    //    }
    //}
}
