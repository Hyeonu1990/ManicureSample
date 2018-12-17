using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchImageControl : MonoBehaviour
{

    // 손가락 2개
    float pastDistance = 0; // update 전 터치0, 터치1 간 거리
    //float pastAngle = 0;
    Vector2 past0; // update 전 터치0 좌표
    Vector2 past1; // update 전 터치1 좌표
    Vector2 pastVector; // update 전 터치1 - 터치0 방향벡터

    //손가락 1개
    Vector2 pastTouch;
    bool btndown = false;

    RectTransform rect; // 이녀석 UI transform
    bool ModifyMode = false;
    Image SeletedImage;
    NailsManager nailm;
    Button thisButton;

    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
        thisButton = GetComponent<Button>();
        if (SeletedImage == null)
        {
            Image[] images = GetComponentsInChildren<Image>();
            SeletedImage = images[1];
        }
        if(nailm == null)
            nailm = FindObjectOfType<NailsManager>();
    }

    public void SetNailManager(NailsManager nm)
    {
        nailm = nm;
    }

    public void ModifyingStart()
    {
        if(SeletedImage == null)
        {
            Image[] images = GetComponentsInChildren<Image>();
            SeletedImage = images[1];
        }

        if(thisButton == null)
            thisButton = GetComponent<Button>();

        if (thisButton.enabled)
            nailm.NailModifyStart(this);   
    }

    public void ActiveModifyMode()
    {
        ModifyMode = true;
        SeletedImage.enabled = true;
    }

    public void UnActiveModifyMode()
    {
        ModifyMode = false;
        SeletedImage.enabled = false;
    }

    public void ButtonDown()
    {
        if (!ModifyMode) ModifyingStart();
         btndown = true;
        pastTouch = Input.touches[0].position;
        Debug.Log("buttondown");
    }

    public void ButtonUp()
    {
        btndown = false;
        Debug.Log("buttonup");
    }

	// Update is called once per frame
	void Update () {
        if (ModifyMode)
        {
            if (Input.touchCount == 2)
            {
                //rect Scale 변경
                if (pastDistance == 0)
                    pastDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                else if (past0 != new Vector2() && past1 != new Vector2())
                {
                    float rate = Vector2.Distance(Input.touches[0].position, Input.touches[1].position) / pastDistance;
                    pastDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    if (rate > 0.8f && rate < 1.2f && rect.localScale.x <= 10)
                        rect.localScale = rect.localScale * rate;
                }

                //rect 회전
                if (pastVector == new Vector2())
                    pastVector = (Input.touches[1].position - Input.touches[0].position).normalized;
                else if (past0 != new Vector2() && past1 != new Vector2())
                {
                    Vector2 nowVector = (Input.touches[1].position - Input.touches[0].position).normalized;

                    float angle = Vector2.Angle(pastVector, nowVector);

                    Vector2 difference = nowVector - pastVector;

                    if (Input.touches[1].position.y >= Input.touches[0].position.y && difference.x >= 0
                        || Input.touches[1].position.y <= Input.touches[0].position.y && difference.x <= 0)
                        rect.Rotate(new Vector3(0, 0, -angle));
                    else
                        rect.Rotate(new Vector3(0, 0, angle));

                    pastVector = nowVector;
                }

                past0 = Input.touches[0].position;
                past1 = Input.touches[1].position;

            }

            else if (Input.touchCount == 1)
            {
                if (pastTouch == new Vector2())
                    pastTouch = Input.touches[0].position;
                else
                {
                    Vector2 difference = Input.touches[0].position - pastTouch;
                    if (btndown)
                    {
                        //rect.anchoredPosition += difference;
                        rect.position += new Vector3(difference.x, difference.y, 0);
                    }
                    pastTouch = Input.touches[0].position;
                }
            }

            else
            {
                past0 = past1 = pastVector = new Vector2();
                pastDistance = 0;
            }
        }
    }
}
