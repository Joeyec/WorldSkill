using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCriteriaListViewCtr : MonoBehaviour, IPageTurnObject {

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

    public void OnReFreshList()
    {
        if (DataManager.Instance == null)
        {
            return;
        }
        if (DataManager.Instance == null)
        {
            return;
        }
        if (DataManager.Instance.ListSubCriteria == null)
        {
            MainUICtr.Instance?.OnMessageBox("DataManager.Instance.ListSubCriteria data error");
            return;
        }
        iDList.Clear();
        foreach (var item in DataManager.Instance.CurDataSelectState.SubCriteriaList)
        {
            iDList.Add(item.Id);
        }
        _PageTurnCtr.OnInitData();
    }

}
