using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothAR : MonoBehaviour {

    public GameObject ObjectRoot;
    public GameObject AREventObj;
    MeshRenderer TrackingCheck;
    float Distance = 0;
    float positionSpeed = 0;
    bool IsEnabledBefore = false;

    // Use this for initialization
    void Start () {
        TrackingCheck = ObjectRoot.GetComponent<MeshRenderer>();
    }

    void SmoothFollowing()
    {

        Distance = Vector3.Distance(AREventObj.transform.position, ObjectRoot.transform.position);
        //debugtext.text = Distance.ToString();
        if (Distance >= 1.0f) positionSpeed = 30.0f;
        else
        {
            positionSpeed = Distance * 30.0f;
        }

        if (IsEnabledBefore)
            AREventObj.transform.position = Vector3.Lerp(AREventObj.transform.position, ObjectRoot.transform.position, Time.deltaTime * positionSpeed);// 15.0f);
        else
        {
            AREventObj.transform.position = ObjectRoot.transform.position;
            IsEnabledBefore = true;
        }
    }

    void SmoothRotation()
    {

    }

    //안씀 위에꺼 참고용
    //void LookingPlayerRotation()
    //{

    //    _3DObject.transform.rotation = Quaternion.LookRotation(
    //        Vector3.Slerp(_3DObject.transform.forward,
    //                      (ARCamera.transform.position - _3DObject.transform.position).normalized,
    //                      Time.deltaTime * 1.0f)
    //        );
    //}

    // Update is called once per frame
    void Update () {
		if(TrackingCheck.enabled)
        {
            if (!IsEnabledBefore)
            {
                AREventObj.transform.SetParent(null);
                AREventObj.SetActive(true);
            }
            SmoothFollowing();
            SmoothRotation();
        }
        else
        {
            AREventObj.SetActive(false);
            IsEnabledBefore = false;
        }
	}
}
