using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEditorPanels : MonoBehaviour {
    public GameObject editor1;
    public GameObject editor2;

    // Use this for initialization
    void Start () {
		
	}

    public void Editor1On()
    {
        editor1.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Editor2On()
    {
        editor2.SetActive(true);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
