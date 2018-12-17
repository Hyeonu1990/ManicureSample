using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSubPanel : MonoBehaviour {

    private GameObject subpanel;
    public bool BackButtonIsDestroy = true;

	// Use this for initialization
	void Start () {
        subpanel = this.gameObject;
	}
    
    public void OnButtonClick()
    {
        subpanel.SetActive(true);
    }
	
    public void OnBackButtonClick()
    {
        if (subpanel.name == "InsertSubPanel") //태그로 변경해야함
            subpanel.SetActive(false);
        else
        {
            if (BackButtonIsDestroy)
                Destroy(subpanel);
            else
                subpanel.SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnBackButtonClick();
	}
}
