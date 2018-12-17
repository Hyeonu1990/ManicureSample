using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageLeftRightMoving : MonoBehaviour {
    Scrollbar horizontal;
    Vector2 location;
    RectTransform tf;
    Image thisimg;
    float times;

	// Use this for initialization
	void Start () {
        horizontal = GetComponentInParent<Scrollbar>();
        tf = GetComponent<RectTransform>();
        location = tf.anchoredPosition;
        thisimg = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		if( (horizontal.value < 1.0f && this.name == "RightImage") || 
            (horizontal.value > 0.0f && this.name == "LeftImage")   )
        {
            if(!thisimg.enabled)
                thisimg.enabled = true;

            //둠칫둠칫
            times += Time.deltaTime * 2.0f;
            tf.anchoredPosition = new Vector2(location.x + Mathf.Sin(times) * 20.0f, location.y);
        }
        else
        {
            thisimg.enabled = false;
        }
	}
}
