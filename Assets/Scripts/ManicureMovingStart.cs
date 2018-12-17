using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManicureMovingStart : MonoBehaviour {

    //매니큐어들
    public GameObject[] manicures;

    public MeshRenderer TrackingCheck;
    public GameObject NailPart;

    float times = 0;
    int rollingNum = 0;
    bool EventTimeDone = false;
    
	// Use this for initialization
	void Start () {
        //TrackingCheck = GetComponentInParent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(TrackingCheck.enabled && !EventTimeDone)
        {
            if(times > 0.5)
            {
                if (rollingNum == manicures.Length - 1)
                {
                    if(times > 10.0f)
                    {
                        NailPart.SetActive(true);
                        EventTimeDone = true;
                    }
                    //return;
                }
                else
                {
                    rollingNum++;
                    times = 0;
                }
            }

            if (!manicures[rollingNum].activeInHierarchy) manicures[rollingNum].SetActive(true);

            times += Time.deltaTime;
        }
        else
        {
            times = 0;
            foreach(GameObject mani in manicures)
            {                
                mani.SetActive(false);
            }
        }
	}
}
