using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NailsColorChangeAll : MonoBehaviour {

    Button[] Nails;
    public GameObject ContentRoot;
    Button[] products;
    int post;
    int New;
	// Use this for initialization
	void Start () {
        Nails = GetComponentsInChildren<Button>();
        products = ContentRoot.GetComponentsInChildren<Button>();
        post = Slider_change.colornum;
        SetAllNailColor(products[post].GetComponentsInChildren<Image>()[1]);
    }

    public void SetAllNailColor(Image img)
    {
        foreach(Button btn in Nails)
        {
            btn.GetComponent<Image>().color = img.color;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    New = Slider_change.colornum;
        if(post != New)
        {
            SetAllNailColor(products[New].GetComponentsInChildren<Image>()[1]);
            post = New;
        }
    }
}
