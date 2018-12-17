using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class BackGroundCopy : MonoBehaviour
{

    private GameObject Saved;
    public GameObject Background;
    public VuforiaBehaviour vuforiaMain;
    private MeshRenderer SavedRenderer;
    public string SavePlaneName;
    private bool check = true;

    //솔루션2
    //public WebCamTexture mCamera = null;
    //private bool cameracheck = false;

    // Use this for initialization
    void Start()
    {
        Saved = this.gameObject;
        SavedRenderer = GetComponentInChildren<MeshRenderer>();
        SavePlaneName = SavedRenderer.gameObject.name;
        //check = vuforiaMain.enabled;
        //Saved.transform.SetParent(null);
        //thisTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        //mCamera = new WebCamTexture();
        //mCamera = new WebCamTexture(WebCamTexture.devices[0].name);
        //mCamera.Play();
    }

    public void OffVuforia()
    {
        //if (!check) mCamera = null;
        check = !check;
        vuforiaMain.enabled = check;
        // cameracheck = true;
        //ScreenCapture.CaptureScreenshot("mnt / sdcard / DCIM / Screenshots / ScreenCapture_" + Time.time.ToString() + ".png");
        //StartCoroutine(CaptureScreen());
    }

    IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();

        byte[] imageByte;
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
        tex.Apply();
        imageByte = tex.EncodeToPNG();
        DestroyImmediate(tex);
        File.WriteAllBytes("mnt/sdcard/DCIM/Screenshots/number_" + Time.time.ToString() + ".png", imageByte);
    }

    // Update is called once per frame
    void Update()
    {
        //thisImage.material = new Material(Background.GetComponent<MeshRenderer>().material);
        //Texture2D BGtexture = Background.GetComponent<MeshRenderer>().material.GetTexture("_MainTex") as Texture2D;
        //Rect BGrect = new Rect(0, 0, BGtexture.width, BGtexture.height);
        //thisImage.sprite = Sprite.Create(BGtexture, BGrect, new Vector2(0.5f, 0.5f));
        ///////////Background.GetComponent<MeshRenderer>().enabled = false;
        if (vuforiaMain.enabled || true)//(Background.GetComponent<MeshRenderer>().enabled)
        {
            SavedRenderer.enabled = false;
            if (Background.GetComponent<MeshFilter>() != null)
            {
                if (SavedRenderer.GetComponent<MeshFilter>().mesh != Background.GetComponent<MeshFilter>().mesh)
                    SavedRenderer.GetComponent<MeshFilter>().mesh = Background.GetComponent<MeshFilter>().mesh;
            }
            SavedRenderer.material = new Material(Background.GetComponent<MeshRenderer>().material);
            Saved.transform.SetPositionAndRotation(Background.transform.position, Background.transform.rotation);
            Saved.transform.localScale = Background.transform.localScale;

        }

        else
        {
            SavedRenderer.enabled = true;
        }

        //if(cameracheck)
        //{
        //    TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        //    if (mCamera == null)
        //    {
        //        mCamera = new WebCamTexture(WebCamTexture.devices[0].name);
        //        mCamera.Stop();
        //    }

        //    if (!mCamera.isPlaying)
        //        mCamera.Play();

        //    SavedRenderer.material.mainTexture = mCamera;

        //}
    }


}
