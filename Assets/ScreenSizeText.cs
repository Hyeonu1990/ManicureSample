using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSizeText : MonoBehaviour {

    Text txt;
    public GameObject bgri2;
    Canvas canvas;
    
	// Use this for initialization
	void Start () {
        canvas = GetComponentInParent<Canvas>();
        txt = GetComponent<Text>();
        txt.text = "Screen : " + Screen.width.ToString() + " x " + Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = "Screen : " + Screen.width.ToString() + " x " + Screen.height + "\n" +
                    "Canvas : " + bgri2.GetComponent<RectTransform>().sizeDelta.ToString();

    }
}
