using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectListView : MonoBehaviour, IPageTurnObject
{
    public PageTurnCtr _PageTurnCtr;

    List<string> iDList = new List<string>();

    public List<string> IdList
    {
        get
        {
            return iDList;
        }

        set
        {
            iDList = value;
        }
    }

    Transform ListParent;

    private void Awake()
    {
        ListParent = transform.Find("ListParent");
    }

    public void OnReFreshList()
    {
        if (DataManager.Instance == null)
        {
            return;
        }

        if (DataManager.Instance.ListAspect == null)
        {
            MainUICtr.Instance?.OnMessageBox("DataManager.Instance.ListAspect data error");
            return;
        }

        foreach (Transform item in ListParent)
        {
            item.GetComponent<AspectItemBtnCtr>().OnInitProperty();
        }

        iDList.Clear();

        foreach (var item in DataManager.Instance.CurDataSelectState.AspectList)
        {
            iDList.Add(item.Id);
        }

        _PageTurnCtr.OnInitData();

        foreach (Transform item in ListParent)
        {
            if (DataManager.Instance.ListAspectComplete.Contains(item.GetComponent<AspectItemCtr>().Id))
            {
                Debug.Log("Complete" + item.GetComponent<AspectItemCtr>().Id);
                item.GetComponent<AspectItemBtnCtr>().OnIsOver(true);
            }
        }
    }
}
