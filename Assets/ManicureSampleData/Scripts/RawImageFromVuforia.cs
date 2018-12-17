using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RawImageFromVuforia : MonoBehaviour {

    //public GameObject Background;
    public CameraImageAccess CIA;
    public GameObject CaptureIcon;
    public GameObject SaveImg;
    public GameObject nailUI;
    public RawImage CapturedImg;
    public NailsManager nailm;
    public GameObject SubPanel;

    RawImage img;
    //Material bgMaterial;
    RectTransform rectrf;
    //VuforiaBehaviour vufo;
    MeshRenderer BGP;
    bool check = true;

	// Use this for initialization
	void Start () {
        img = GetComponent<RawImage>();
        //bgMaterial = Background.GetComponent<MeshRenderer>().material;
        rectrf = GetComponent<RectTransform>();
        //vufo = CIA.GetComponent<VuforiaBehaviour>();
        BGP = CIA.GetComponentInChildren<MeshRenderer>();

    }

    public void OffVuforia()
    {
        nailm.NailModifyEnd();
        check = !check;
        if (check)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SaveImg.SetActive(false);
            nailUI.SetActive(false);
            StartCoroutine(CaptureScreen());
            //BGP.enabled = check;
            //CIA.Init();
        }
        else
        {
            CaptureIcon.SetActive(false);
            nailUI.SetActive(true);
            SaveImg.SetActive(true);
            StartCoroutine(TakeRawImage());
        }
    }

    IEnumerator TakeRawImage()
    {
        CIA.rawImage = img;
        CIA.VuforiaOnOff = false;
        yield return new WaitUntil(() => CIA.VuforiaOnOff); // 0.5
        CIA.VuforiaOnOff = true;
        BGP.enabled = check;

        
    }

    IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();

        //Capturing
        byte[] imageByte;
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
        tex.Apply();        
        imageByte = tex.EncodeToPNG();
        File.WriteAllBytes("mnt/sdcard/DCIM/Screenshots/number_" + Time.time.ToString() + ".png", imageByte);
        //CapturedImg.texture = tex as Texture;
        //CapturedImg.GetComponent<RectTransform>().sizeDelta = new Vector2(tex.height, tex.width);
        //
        Texture2D newtex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        newtex.LoadImage(imageByte);
        CapturedImg.texture = newtex as Texture;
        CapturedImg.GetComponent<RectTransform>().sizeDelta = new Vector2(newtex.width, newtex.height);
        //
        BGP.enabled = check;
        //nailUI.SetActive(true);
        CaptureIcon.SetActive(true);
        DestroyImmediate(tex);
        //CapturedImg.enabled = true;
        SubPanel.SetActive(true);
        
    }
	
	// Update is called once per frame
	void Update () {
        //Texture BGtexture = bgMaterial.GetTexture("_MainTex");

        //img.texture = BGtexture;

        //rectrf.sizeDelta = new Vector2(BGtexture.width, BGtexture.height);
        img.enabled = !BGP.enabled;

        //if(CapturedImg.enabled)
        //{
        //    CapturedImg.transform.localScale -= new Vector3(Time.deltaTime / 3.0f, Time.deltaTime / 3.0f, Time.deltaTime / 3.0f);
        //    if(CapturedImg.transform.localScale.x <= 0)
        //    {
        //        CapturedImg.enabled = false;
        //        CapturedImg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //    }
        //}

    }
}
