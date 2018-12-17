using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManicureRotation : MonoBehaviour {

    SpriteRenderer mncImg;
    float defaultZ = 2.15f;
    float mncZ = 2.15f;
    float rotationSpeed = 1.0f;
	// Use this for initialization
	void Start () {
        mncImg = GetComponentInChildren<SpriteRenderer>();

    }

    private void OnDisable()
    {
        TurnoffRotation();
    }

    public void TurnoffRotation()
    {
        mncImg.transform.localPosition = new Vector3(0, 0, defaultZ);
        mncZ = defaultZ;
        this.transform.rotation = new Quaternion();
    }
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.activeInHierarchy)
        {
            mncZ += Time.deltaTime / 3.0f;
            mncImg.transform.localPosition = new Vector3(0, 0, mncZ);
            this.transform.Rotate(0, rotationSpeed, 0);
        }
	}
}
