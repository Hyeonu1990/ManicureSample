using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAction : MonoBehaviour {

    private RectTransform thisTransform;
    public GameObject Contents; 
    private bool IsEnable = false;
    private bool IsFull = false;
    private float times = 0.5f;
    private float MaxTime = 0.9f;
    public bool IsSubPanel = true;

    // Use this for initialization
    void Start () {
        thisTransform = GetComponent<RectTransform>();
        if (gameObject.tag != "SubPanel")
        {
            Image thisImage = GetComponent<Image>();        
            thisImage.material = new Material(Resources.Load("UIBlurShader") as Material);
            thisImage.material.SetColor("_Color", thisImage.color);
        }
        UIoffsetControl(times);
    }

    private void OnEnable()
    {
        if (IsSubPanel) MaxTime = 0.9f;
        else MaxTime = 1.0f;
        IsEnable = true;
        Contents.SetActive(false);
    }
    private void OnDisable()
    {
        IsEnable = false;
        Contents.SetActive(false);
        times = 0.5f;
        UIoffsetControl(times);
        IsFull = false;
    }

    public void ImgChange(Sprite drugimg)
    {
        Contents.GetComponent<Image>().sprite = drugimg;
    }

    void UIoffsetControl(float t)
    {
        thisTransform.offsetMin = new Vector2(Screen.width / 2 * (1 - t), Screen.height / 2 * (1 - t)); // new Vector2(left, bottom); 
        thisTransform.offsetMax = new Vector2(-Screen.width / 2 * (1 - t), -Screen.height / 2 * (1 - t)); // new Vector2(-right, -top)
    }

    // Update is called once per frame
    void Update () {
        if (IsEnable)
        {
            if (times < MaxTime)
            {
                times += Time.deltaTime * 2.0f;
                UIoffsetControl(times);
                //thistransform.rect.Set(0, 0, Screen.width * times / 100, Screen.height * times / 100);
                //Debug.Log("Times : " + times.ToString());
            }
            else
            {
                if (!IsFull)
                {
                    times = MaxTime;
                    UIoffsetControl(times);
                    Contents.SetActive(true);
                    IsFull = true;
                }
            }
        }
        
	}
}
