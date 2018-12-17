using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NailOptionsControl : MonoBehaviour {

    Button[] Options;

    public GameObject PatternsRoot;
    public GameObject BeadsRoot;

	// Use this for initialization
	void Start () {
        Options = GetComponentsInChildren<Button>();
        ButtonOnOff(false);
    }

    public void ButtonOnOff(bool OnOff)
    {
        foreach(Button btn in Options)
        {
            btn.GetComponent<Image>().raycastTarget = OnOff;
            btn.enabled = OnOff;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
