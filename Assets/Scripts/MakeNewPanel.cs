using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeNewPanel : MonoBehaviour {

    //private GameObject thismother;
    private GameObject newpanel;

	// Use this for initialization
	void Start () {
        //thismother = this.transform.parent.gameObject;
	}
	
    public void MakeNewPanelButtonClick()
    {
        newpanel = Instantiate(Resources.Load("SubPanel"), GetComponentInParent<Canvas>().transform) as GameObject;
        //newpanel = Instantiate(Resources.Load("SubPanel"), thismother.transform) as GameObject;
        //newpanel = new GameObject();
        //newpanel = Resources.Load("SubPanel") as GameObject;
        //newpanel.transform.parent = thismother.transform;
        //newpanel.transform.SetParent(thismother.transform);
        newpanel.GetComponent<Image>().color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f), 0.5f);        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
