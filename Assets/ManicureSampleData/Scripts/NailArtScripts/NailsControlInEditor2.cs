using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NailsControlInEditor2 : MonoBehaviour {
    public NailsManager nailm;
    public GameObject[] Nails;
    public GameObject[] Panels = new GameObject[4];

	// Use this for initialization
	void Start () {
		
	}

    ////////////////////////////컬러부분//////////////////////////////////
    public void SetColor(Image img)
    {
        if (nailm.GetModifyingNail() == null)
            SetColorAll(img);
        else
            SetColorAlone(img);

    }

    void SetColorAll(Image img)
    {
        foreach(GameObject nail in Nails)
        {
            nail.GetComponent<Image>().color = img.color;
        }
    }

    void SetColorAlone(Image img)
    {
        nailm.GetModifyingNail().GetComponent<Image>().color = img.color;
    }
    //////////////////////////////////////////////////////////////


    //////////////////////////패턴(그림)부분////////////////////////////////////
    public void SetPattern(Image Patternimg)
    {
        
        if (nailm.GetModifyingNail() != null)
        {
            GameObject NewPattern = Instantiate(Resources.Load("PatternImage") as GameObject,
                                                nailm.GetModifyingNail().GetComponentInChildren< NailOptionsControl>().PatternsRoot.transform);
            NewPattern.GetComponent<Image>().sprite = Patternimg.sprite;
            NewPattern.GetComponent<Image>().color = Patternimg.color;
            NewPattern.transform.localPosition = new Vector3();
        }        
    }
    //////////////////////////////////////////////////////////////


    //////////////////////////비즈 부분////////////////////////////////////
    public void SetBeads(Image Beadsimg)
    {
        
        if (nailm.GetModifyingNail() != null)
        { 
            GameObject NewPattern = Instantiate(Resources.Load("비즈1") as GameObject, nailm.GetModifyingNail().GetComponentInChildren<NailOptionsControl>().BeadsRoot.transform);
            NewPattern.GetComponent<Image>().sprite = Beadsimg.sprite;
            NewPattern.GetComponent<Image>().color = Beadsimg.color;
            NewPattern.transform.localPosition = new Vector3();
        }
    }
    //////////////////////////////////////////////////////////////
    
    /////////////////////////툴 패널 변경/////////////////////////////////////
    int ActivePanelNum = 0;
    public void ChangeToolPanel(int num) // 0 color, 1 pattern, 2 beads
    {
        if ((ActivePanelNum + num) > 3) return;
        else if ((ActivePanelNum + num) < 0) return;
        Panels[ActivePanelNum].GetComponent<UIChangingAction>().UnActiveThisUI();
        StartCoroutine(WaitWhileUIActionDone(ActivePanelNum + num));
        
    }

    IEnumerator WaitWhileUIActionDone(int num)
    {
        yield return new WaitWhile(() => Panels[ActivePanelNum].activeInHierarchy);
        ActivePanelNum = num;
        Panels[ActivePanelNum].SetActive(true);
    }

    public void CaptureButtonOn()
    {
        Panels[ActivePanelNum].SetActive(false);
        ActivePanelNum = 0;
        Panels[ActivePanelNum].SetActive(true);
    }
    //////////////////////////////////////////////////////////////

    // Update is called once per frame
    void Update () {
		
	}
}
