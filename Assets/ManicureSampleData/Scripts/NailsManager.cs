using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NailsManager : MonoBehaviour {
    private TouchImageControl modifyingNail;
    public GameObject SaveButton;
    public GameObject UndoButton;
    public GameObject MainPanel;
    bool modifying = false;
    Stack<GameObject> Nails = new Stack<GameObject>();
    // Use this for initialization
    void Start () {
        //SaveButton.SetActive(false);
        //Screen.SetResolution(1080, 1920, true);
    }

    public bool IsModifying()
    {
        return modifying;
    }

    public TouchImageControl GetModifyingNail()
    {
        if (modifyingNail == null)
            return null;
        else
            return modifyingNail;
    }

    public void NailModifyStart(TouchImageControl nail)
    {
        if (!modifying)
        {
            modifyingNail = nail;
            modifying = true;
            modifyingNail.ActiveModifyMode();
            SaveButton.SetActive(true);
        }
        else if(!(modifyingNail == nail))
        {
            NailModifyEnd();
            modifyingNail = nail;
            modifying = true;
            modifyingNail.ActiveModifyMode();
            SaveButton.SetActive(true);
        }
    }

    public void NailModifyEnd()
    {
        if (modifyingNail != null)
        {
            modifyingNail.UnActiveModifyMode();
            modifyingNail = null;
        }
        modifying = false;
        SaveButton.SetActive(false);
    }

    public void MakeNewNail(Image nail)
    {
        if (modifying)
            NailModifyEnd();
        //GameObject nailImage = Instantiate(Resources.Load("NailImage") as GameObject, MainPanel.transform.position, MainPanel.transform.rotation, MainPanel.transform);
        GameObject nailImage = Instantiate(Resources.Load("NailImage") as GameObject, MainPanel.transform);
        nailImage.GetComponent<Image>().color = nail.color;
        nailImage.GetComponent<TouchImageControl>().SetNailManager(this);
        nailImage.GetComponent<TouchImageControl>().ModifyingStart();

        Nails.Push(nailImage);
    }

    //현재 안쓰임
    public void DestroyAllNails()
    {
        foreach(GameObject Nail in Nails)
        {
            Destroy(Nail);
        }
    }

    public void RollBack()
    {
        //Nails.Peek();
        if(modifying)
            NailModifyEnd();
        if (Nails.Count > 0)
            Destroy(Nails.Pop());
    }

    // Update is called once per frame
    void Update () {
        if (Nails.Count > 0)
            UndoButton.SetActive(true);
        else
            UndoButton.SetActive(false);

    }
}
