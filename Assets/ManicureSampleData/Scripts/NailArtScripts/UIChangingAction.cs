using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChangingAction : MonoBehaviour {

    Vector3 ActivePosition = new Vector3(0, 100.0f, 0);
    Vector3 UnActicePostion = new Vector3(0, -100.0f, 0);
    RectTransform thisTr;

    bool IsActive;
	// Use this for initialization
	void Start () {
        thisTr = GetComponent<RectTransform>();
        thisTr.anchoredPosition3D = UnActicePostion;
    }

    private void OnEnable()
    {
        if(thisTr == null)
            thisTr = GetComponent<RectTransform>();
        thisTr.anchoredPosition3D = UnActicePostion;
        IsActive = true;
    }

    private void OnDisable()
    {
        IsActive = false;
    }

    public void UnActiveThisUI()
    {
        IsActive = false;
    }

    // Update is called once per frame
    void Update () {
        if (IsActive)
        {
            thisTr.anchoredPosition3D = Vector3.Lerp(thisTr.anchoredPosition3D, ActivePosition, Time.deltaTime * 6.0f);
        }
        else
        {
            if (thisTr.anchoredPosition3D.y > -90.0f)
                thisTr.anchoredPosition3D = Vector3.Lerp(thisTr.anchoredPosition3D, UnActicePostion, Time.deltaTime * 10.0f);
            else
            {
                thisTr.anchoredPosition3D = UnActicePostion;
                this.gameObject.SetActive(false);
            }
        }
    }
}
