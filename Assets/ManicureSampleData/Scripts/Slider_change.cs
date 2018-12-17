using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slider_change : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public GameObject scroll;
    // Use this for initialization
    private Vector2 touchPoint;
    public Vector3 pos;
    public Vector3 tmppos;
    public int direction;

    int canvaswidth = 800;
    int maxcolornum = 3;
    
    public static int colornum = 0;

    void Start()
    {
        pos = scroll.transform.position;
        tmppos=scroll.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void OnBeginDrag(PointerEventData eventData)
    {
        touchPoint = eventData.position;
        Debug.Log(touchPoint);
        
    }
    public void OnEndDrag(PointerEventData eventData) {
        if (direction == 1) {
            if (colornum > 0) colornum -= 1;

            pos.x = canvaswidth*colornum*(-1);
            
            if (pos.x >= 0) pos.x = 0; 

            Debug.Log(pos.x);
            scroll.GetComponent<RectTransform>().anchoredPosition3D= pos;
        }
        if (direction == -1) {
            if (colornum < maxcolornum) colornum += 1;

            pos.x = canvaswidth * colornum * (-1);
            
            if (pos.x <= canvaswidth * maxcolornum*(-1)) pos.x = canvaswidth * maxcolornum*(-1); 
            Debug.Log(pos.x);
            scroll.GetComponent<RectTransform>().anchoredPosition3D = pos;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.x > touchPoint.x) {
            tmppos.x = eventData.position.x - touchPoint.x;
            touchPoint.x = eventData.position.x;
            pos.x += tmppos.x;
            scroll.GetComponent<RectTransform>().anchoredPosition3D = pos;
            direction = 1;
        }

        if (eventData.position.x < touchPoint.x) {
            tmppos.x = eventData.position.x - touchPoint.x;
            touchPoint.x = eventData.position.x;
            pos.x += tmppos.x;
            scroll.GetComponent<RectTransform>().anchoredPosition3D = pos;
            direction = -1;
        }
            
       
    }

}
