using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeadsAddTest : MonoBehaviour {
    public Button btn;
    public NailsManager nailm;
    //비즈 수정모드 사이즈
    Vector3 BeadsAddAngles = new Vector3(0 ,0 ,0);
    Vector3 BeadsAddlocalPos = new Vector3(0, 120.0f, 0);
    Vector3 BeadsAddScale = new Vector3(5.0f, 5.0f, 5.0f);

    //비즈 수정모드 들어가기 전 사이즈
    Vector3 OriginAngles;
    Vector3 OriginlocalPos;
    Vector3 OriginScale;
    int OriginIndex;

    TouchImageControl thisNail;
    NailOptionsControl thisOptionsControl;

    bool BeadsModifyOn = false;
    float moveSpeed = 1.0f;

    // Use this for initialization
    void Start() {
        thisNail = GetComponent<TouchImageControl>();
        thisOptionsControl = GetComponentInChildren<NailOptionsControl>();
        //btn.onClick.AddListener(delegate (){ BeadsNailModifyEnd(); }); //버튼 onclick이벤트에 할당
    }

    public void BeadsNailModifyStart()
    {
        if (!nailm.IsModifying())
        {
            btn.gameObject.SetActive(true);
            Debug.Log("BeadsNailModifyStart");
            //OriginQuat = this.transform.localRotation;
            OriginAngles = this.transform.localEulerAngles; // localEulerAngles
            OriginlocalPos = this.transform.localPosition;
            OriginScale = this.transform.localScale;
            OriginIndex = this.transform.GetSiblingIndex();
            BeadsModifyOn = true;
            thisNail.ModifyingStart();
            btn.onClick.AddListener(delegate () { BeadsNailModifyEnd(); });

            thisOptionsControl.ButtonOnOff(true);
            this.transform.SetAsLastSibling();
        }
    }

    public void BeadsNailModifyEnd()
    {
        BeadsModifyOn = false;
        nailm.NailModifyEnd();
        thisOptionsControl.ButtonOnOff(false);
        this.transform.SetSiblingIndex(OriginIndex);
        btn.gameObject.SetActive(false);
    }

    void MoveToBeadsModifyLocation()
    {
        if (this.transform.localPosition != BeadsAddlocalPos
            && this.transform.localEulerAngles != BeadsAddAngles
            && this.transform.localScale != BeadsAddScale)
        {
            //if (Input.GetKeyDown(KeyCode.Escape)) break;
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, BeadsAddlocalPos, Time.deltaTime * moveSpeed);
            this.transform.localEulerAngles = Vector3.Lerp(this.transform.localEulerAngles, BeadsAddAngles, Time.deltaTime * moveSpeed);
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, BeadsAddScale, Time.deltaTime * moveSpeed);
            moveSpeed += 0.2f;
        }
        else
        {
            moveSpeed = 1.0f;
        }
    }

    void MoveToOriginLocation()
    {
        if (this.transform.localPosition != OriginlocalPos
            && this.transform.localEulerAngles != OriginAngles
            && this.transform.localScale != OriginScale)
        {
            //if (Input.GetKeyDown(KeyCode.Escape)) break;
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, OriginlocalPos, Time.deltaTime * moveSpeed);
            this.transform.localEulerAngles = Vector3.Lerp(this.transform.localEulerAngles, OriginAngles, Time.deltaTime * moveSpeed);
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, OriginScale, Time.deltaTime * moveSpeed);
            moveSpeed += 0.2f;
        }
        else
        {
            moveSpeed = 1.0f;
        }
    }

    // Update is called once per frame
    void Update () {
		if(BeadsModifyOn)
        {
            MoveToBeadsModifyLocation();
        }
        else
        {
            if(OriginlocalPos != new Vector3())
                MoveToOriginLocation();
        }
	}
}
